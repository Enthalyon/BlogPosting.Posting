
using BlogPosting.Posting.Api.Options;
using BlogPosting.Posting.Application.Commands;
using BlogPosting.Posting.Application.Interfaces;
using BlogPosting.Posting.Application.Services;
using BlogPosting.Posting.Infrastructure.Context;
using BlogPosting.Posting.Infrastructure.Interface;
using BlogPosting.Posting.Infrastructure.Models;
using BlogPosting.Posting.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace BlogPosting.Posting.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(PublishPostCommand).Assembly));

            // Obtenemos las configuraciones de mongo desde el appSettings al modelo mongo options
            MongoOptions mongoOptions = new();
            builder.Configuration.GetSection(mongoOptions.SectionName)
                .Bind(mongoOptions);

            // Crear el cliente de mongo y obtener la base de datos que vamos a usar
            MongoClient mongoClient = new(mongoOptions.ConnectionString);
            IMongoDatabase dataBase = mongoClient.GetDatabase(mongoOptions.DatabaseName);

            // Configuramos en el inyector de dependencias la instancia a la base de datos de mongo
            builder.Services.AddSingleton(service => dataBase.GetCollection<PublishPostModel>(mongoOptions.Collections?.Posting));

            // Configuramos entity framework
            SqlOptions sqlOptions = new();
            builder.Configuration.GetSection(sqlOptions.SectionName)
                .Bind(sqlOptions);
            builder.Services.AddDbContext<BlogPostingDBContext>(options=> 
                options.UseSqlServer(sqlOptions.ConnectionString), ServiceLifetime.Singleton);

            builder.Services.AddSingleton<IPostingService, PostingService>();

            builder.Services.AddSingleton<IPostingRepository, MongoPostingRepository>();
            builder.Services.AddSingleton<IPostingRepository, SqlPostingRepository>();

            builder.Services.AddSingleton<Func<IEnumerable<IPostingRepository>>>(x =>
                () => x.GetService<IEnumerable<IPostingRepository>>()!);

            builder.Services.AddSingleton<IPostingRepositoryFactory, PostingRepositoryFactory>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

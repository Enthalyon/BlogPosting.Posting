using BlogPosting.Posting.Domain.Entities;
using BlogPosting.Posting.Infrastructure.Interface;
using BlogPosting.Posting.Infrastructure.Models;
using BlogPosting.Posting.Utilities.Statics.Enums;
using Mapster;
using MongoDB.Driver;

namespace BlogPosting.Posting.Infrastructure.Repository
{
    public class MongoPostingRepository : IPostingRepository
    {
        public DbType Type => DbType.MongoDb;
        private readonly IMongoCollection<PublishPostModel> _mongoCollection;

        public MongoPostingRepository(IMongoCollection<PublishPostModel> mongoCollection) 
        {
            _mongoCollection = mongoCollection;
        }


        public async Task<bool> SavePostAsync(PublishPost publishPost)
        {
            // Mapear el modelo de dominio al modelo de la base de datos
            PublishPostModel publishPostModel = publishPost.Adapt<PublishPostModel>();
            publishPost.Id = publishPostModel.Id;

            try
            {
                await _mongoCollection.InsertOneAsync(publishPostModel);

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<PublishPost> FindByIdAsync(Guid postGuid)
        {
            var result = await _mongoCollection
                .Find(posting => posting.Id == postGuid)
                .FirstOrDefaultAsync();

            return result.Adapt<PublishPost>();
        }
    }
}

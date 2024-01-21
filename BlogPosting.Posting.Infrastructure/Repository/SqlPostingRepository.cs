using BlogPosting.Posting.Domain.Entities;
using BlogPosting.Posting.Infrastructure.Context;
using BlogPosting.Posting.Infrastructure.Interface;
using BlogPosting.Posting.Infrastructure.Models;
using BlogPosting.Posting.Utilities.Statics.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogPosting.Posting.Infrastructure.Repository
{
    public class SqlPostingRepository : IPostingRepository
    {
        public DbType Type => DbType.SqlServer;
        private readonly BlogPostingDBContext _context;
        private readonly DbSet<PublishPostModel> _dbSet;

        public SqlPostingRepository(BlogPostingDBContext context)
        {
            _context = context;
        }


        public async Task<bool> SavePostAsync(PublishPost publishPost)
        {
            PublishPostModel publishPostModel = publishPost.Adapt<PublishPostModel>();
            await _context.Posting.AddAsync(publishPostModel);
            int result = await _context.SaveChangesAsync();
            publishPost.Id = publishPostModel.Id;
            return result > 0;
        }

        public async Task<PublishPost> FindAsync(Expression<Func<PublishPostModel, bool>> expression)
        {
            PublishPostModel? result = await _context
                .Posting.FirstOrDefaultAsync(expression);

            return result.Adapt<PublishPost>(); 
        }
    }
}

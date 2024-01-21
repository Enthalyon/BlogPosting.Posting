using BlogPosting.Posting.Domain.Entities;
using BlogPosting.Posting.Infrastructure.Models;
using BlogPosting.Posting.Utilities.Statics.Enums;
using System.Linq.Expressions;

namespace BlogPosting.Posting.Infrastructure.Interface
{
    public interface IPostingRepository
    {
        public DbType Type { get; }
        Task<bool> SavePostAsync(PublishPost publishPost);
        Task<PublishPost> FindAsync(Expression<Func<PublishPostModel, bool>> expression);
    }
}

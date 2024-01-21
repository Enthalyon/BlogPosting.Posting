using BlogPosting.Posting.Domain.Entities;
using BlogPosting.Posting.Utilities.Statics.Enums;

namespace BlogPosting.Posting.Infrastructure.Interface
{
    public interface IPostingRepository
    {
        public DbType Type { get; }
        Task<bool> SavePostAsync(PublishPost publishPost);
        Task<PublishPost> FindByIdAsync(Guid postGuid);
    }
}

using BlogPosting.Posting.Domain.Entities;

namespace BlogPosting.Posting.Application.Interfaces
{
    public interface IPostingService
    {
        Task<PublishPost> SaveAsync(PublishPost publishPost);
    }
}

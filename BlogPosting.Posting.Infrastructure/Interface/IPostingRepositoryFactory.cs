using BlogPosting.Posting.Utilities.Statics.Enums;

namespace BlogPosting.Posting.Infrastructure.Interface
{
    public interface IPostingRepositoryFactory
    {
        IPostingRepository CreateRepository(DbType type);
    }
}

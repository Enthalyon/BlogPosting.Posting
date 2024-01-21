using BlogPosting.Posting.Infrastructure.Interface;
using BlogPosting.Posting.Utilities.Statics.Enums;

namespace BlogPosting.Posting.Infrastructure.Repository
{
    public class PostingRepositoryFactory: IPostingRepositoryFactory
    {
        private readonly Func<IEnumerable<IPostingRepository>> _postingRepositories;

        public PostingRepositoryFactory(Func<IEnumerable<IPostingRepository>> postingRepositories)
        {
            _postingRepositories = postingRepositories;
        }

        public IPostingRepository CreateRepository(DbType type)
        {
            IEnumerable<IPostingRepository> repository = _postingRepositories();
            IPostingRepository repositoryFound = repository.First(x => x.Type == type);
            return repositoryFound;
        }

    }
}

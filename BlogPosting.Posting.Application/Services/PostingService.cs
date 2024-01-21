using BlogPosting.Posting.Application.Interfaces;
using BlogPosting.Posting.Domain.Entities;
using BlogPosting.Posting.Infrastructure.Interface;
using BlogPosting.Posting.Utilities.Statics.Enums;

namespace BlogPosting.Posting.Application.Services
{
    public class PostingService : IPostingService
    {
        private readonly IPostingRepository _mongoRepository;
        private readonly IPostingRepository _sqlRepository;

        public PostingService(IPostingRepositoryFactory postingRepositoryFactory) 
        {
            _mongoRepository = postingRepositoryFactory.CreateRepository(DbType.MongoDb);
            _sqlRepository = postingRepositoryFactory.CreateRepository(DbType.SqlServer);
        }
        public async Task<PublishPost> SaveAsync(PublishPost publishPost)
        {
            bool isCreated = await _sqlRepository.SavePostAsync(publishPost);
            if (isCreated is false)
            {
                throw new Exception("Error al crear el post");
            }

            PublishPost createdPost = await _sqlRepository.FindByIdAsync(publishPost.Id);

            await _mongoRepository.SavePostAsync(publishPost);


            return createdPost;
        }
    }
}

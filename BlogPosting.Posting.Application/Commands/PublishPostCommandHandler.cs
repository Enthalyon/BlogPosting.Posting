using BlogPosting.Posting.Application.Interfaces;
using BlogPosting.Posting.Application.ViewModels;
using BlogPosting.Posting.Domain.Entities;
using Mapster;
using MediatR;

namespace BlogPosting.Posting.Application.Commands
{
    public class PublishPostCommandHandler : IRequestHandler<PublishPostCommand, PostingViewModel>
    {
        private readonly IPostingService _postingService;

        public PublishPostCommandHandler(IPostingService postingService)
        {
            _postingService = postingService;
        }
        public async Task<PostingViewModel> Handle(PublishPostCommand request, CancellationToken cancellationToken)
        {
            // Validar el request


            // Mapear el request a un objeto de dominio
            PublishPost publishPost = request.Adapt<PublishPost>();

            // Guardar la publicacion
            PublishPost result = await _postingService.SaveAsync(publishPost);
            

            // Mapear el objeto de dominio a un objeto de vista
            return result.Adapt<PostingViewModel>();
        }
    }
}

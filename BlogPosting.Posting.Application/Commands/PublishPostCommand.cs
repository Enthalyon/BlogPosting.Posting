using BlogPosting.Posting.Application.ViewModels;
using MediatR;

namespace BlogPosting.Posting.Application.Commands
{
    public class PublishPostCommand : IRequest<PostingViewModel>
    {
        public required string UserId { get; init; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime PublishedDate { get; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; } = null;
    }
}

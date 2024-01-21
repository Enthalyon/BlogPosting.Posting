namespace BlogPosting.Posting.Application.ViewModels
{
    public class PostingViewModel
    {
        public required string UserId { get; init; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string? ImageUrl { get; set; }
        public required long Likes {  get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

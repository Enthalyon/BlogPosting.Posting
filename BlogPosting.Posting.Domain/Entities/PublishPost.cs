namespace BlogPosting.Posting.Domain.Entities
{
    public class PublishPost
    {
        public required string UserId { get; init; }
        public long? postId { get; set; }
        public Guid Id { get; set; }= Guid.NewGuid();
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string? ImageUrl { get; set; }
        public required long Likes { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

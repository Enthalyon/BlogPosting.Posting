using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPosting.Posting.Infrastructure.Models
{
    public class PublishPostModel
    {

        [Key]        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PostingId { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        //[ForeignKey("User")]
        public required string UserId { get; init; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public string? ImageUrl { get; set; }
        public required long Likes { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

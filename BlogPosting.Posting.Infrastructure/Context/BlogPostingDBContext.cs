using BlogPosting.Posting.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPosting.Posting.Infrastructure.Context
{
    public class BlogPostingDBContext: DbContext
    {
        public BlogPostingDBContext()
        {
        }

        public BlogPostingDBContext(DbContextOptions<BlogPostingDBContext> options)
            :base(options)
        {
        }

        public DbSet<PublishPostModel> Posting {  get; set; }
    }
}

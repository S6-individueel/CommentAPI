using Microsoft.EntityFrameworkCore;

namespace CommentAPI.Models
{
    public class CommentsContext : DbContext
    {
        public CommentsContext(DbContextOptions<CommentsContext> options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
    }
}

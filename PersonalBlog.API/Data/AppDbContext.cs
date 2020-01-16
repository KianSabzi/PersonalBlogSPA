
using Microsoft.EntityFrameworkCore;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<CommentReply> CommentReplies { get; set; }
        public DbSet<Message> Messages { get; set; }

        // protected override void  OnModelCreating(ModelBuilder builder)
        // {
               
        // }   
    }
}
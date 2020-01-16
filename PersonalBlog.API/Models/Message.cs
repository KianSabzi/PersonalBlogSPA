using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.API.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80,MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(200,MinimumLength = 3)]
        public string Content { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool IsAnswered { get; set; }
    }
}
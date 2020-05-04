using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.API.Models
{
   public enum MediaType{
        [Display(Name = "تصویر")]
        image = 1,
        [Display(Name = "ویدئو")]
        video = 2,
        [Display(Name = "سایر")]
        other = 3
    }
    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MediaType Type { get; set; }
        public int Size { get; set; }
        public string Path { get; set; }
        public bool IsIndex { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}
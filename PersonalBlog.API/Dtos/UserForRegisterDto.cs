using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد نمایید")]
        [StringLength(15,MinimumLength=5,ErrorMessage ="نام کاربری باید بین حداقل 5 و حداکثر 15 کاراکتر باشد")]
        public string Username { get; set; }
        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد نمایید")]
        [StringLength(15,MinimumLength=5,ErrorMessage ="رمز عبور باید بین حداقل 5 و حداکثر 10 کاراکتر باشد")]
        public string Password { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace CoreDemo1.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string password { get; set; }
    }
}

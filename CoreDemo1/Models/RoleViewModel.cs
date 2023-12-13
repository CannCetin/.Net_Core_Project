using System.ComponentModel.DataAnnotations;

namespace CoreDemo1.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lütfen rol adı giriniz")]
        public string Name { get; set; }
    }
}

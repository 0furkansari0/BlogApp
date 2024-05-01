using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BlogApp.Entity;

namespace BlogApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Eposta")]
        public string? Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage ="{0} alanı, {2} ile {1} karakter arasında olmalıdır. ", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password { get; set; }
    }
}
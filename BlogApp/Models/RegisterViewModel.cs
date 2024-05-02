using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BlogApp.Entity;

namespace BlogApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="Kullanıcı Adı")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name ="Ad Soyad")]
        public string? Name { get; set; }
  

        [Required]
        [EmailAddress]
        [Display(Name ="Eposta")]
        public string? Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage ="{0} alanı, {2} ile {1} karakter arasında olmalıdır. ", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola Tekrar")]
        [Compare(nameof(Password), ErrorMessage ="Parolanız eşleşmiyor.")]
        public string? ConfirmPassword { get; set; }
    }
}
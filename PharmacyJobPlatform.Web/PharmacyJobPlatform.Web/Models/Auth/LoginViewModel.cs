using System.ComponentModel.DataAnnotations;

namespace PharmacyJobPlatform.Web.Models.Auth
{
    public class LoginViewModel
    {
        [Display(Name = "E-posta")]
        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni hatırla")]
        public bool RememberMe { get; set; }
    }
}

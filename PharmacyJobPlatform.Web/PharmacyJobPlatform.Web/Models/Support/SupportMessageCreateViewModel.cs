using System.ComponentModel.DataAnnotations;

namespace PharmacyJobPlatform.Web.Models.Support
{
    public class SupportMessageCreateViewModel
    {
        [Display(Name = "Konu")]
        [Required(ErrorMessage = "Mesaj başlığı zorunludur.")]
        [StringLength(100, ErrorMessage = "Mesaj başlığı en fazla 100 karakter olabilir.")]
        public string Subject { get; set; } = string.Empty;

        [Display(Name = "Mesajınız")]
        [Required(ErrorMessage = "Mesaj içeriği zorunludur.")]
        [StringLength(2000, ErrorMessage = "Mesaj içeriği en fazla 2000 karakter olabilir.")]
        public string Content { get; set; } = string.Empty;
    }
}

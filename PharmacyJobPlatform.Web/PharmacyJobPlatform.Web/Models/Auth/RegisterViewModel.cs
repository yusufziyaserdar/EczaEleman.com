using PharmacyJobPlatform.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PharmacyJobPlatform.Web.Models.Auth
{
    public class RegisterViewModel
    {
        [Display(Name = "Ad")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "E-posta")]
        [Required, EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre zorunludur")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,}$", ErrorMessage = "Şifre en az 8 karakter olmalı; büyük harf, küçük harf, rakam ve noktalama işareti içermelidir")]
        public string Password { get; set; }

        [Display(Name = "Şifre (Tekrar)")]
        [Required(ErrorMessage = "Şifre tekrarı zorunludur")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifreler eşleşmiyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Telefon numarası zorunludur")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Telefon numarası 10 haneli olmalıdır")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Doğum tarihi zorunludur")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "E-posta profilimde görünsün")]
        public bool IsEmailVisible { get; set; } = true;

        [Display(Name = "Telefon profilimde görünsün")]
        public bool IsPhoneNumberVisible { get; set; } = true;
        public string? About { get; set; }
        public IFormFile? ProfileImage { get; set; }

        public IFormFile? CvFile { get; set; }

        public bool IsCvVisible { get; set; } = true;

        public string? PharmacyName { get; set; }

        public AddressInputViewModel Address { get; set; } = new();

        public List<WorkExperienceInputModel> WorkExperiences { get; set; } = new();

        [Range(1, 5)]
        public int? DrugKnowledgeLevel { get; set; }

        [Range(1, 5)]
        public int? DermocosmeticKnowledgeLevel { get; set; }

        [Range(1, 5)]
        public int? CrossSellingSkillLevel { get; set; }

        public List<string> PharmacyPrograms { get; set; } = new();

        [Range(1, 5)]
        public int? PrescriptionPreparationLevel { get; set; }

        [Range(1, 5)]
        public int? ReportControlLevel { get; set; }

        [Range(1, 5)]
        public int? PrescriptionControlLevel { get; set; }

        [Range(1, 5)]
        public int? SutKnowledgeLevel { get; set; }

        [Display(Name = "Hesap Türü")]
        [Required]
        public string Role { get; set; }
    }
}

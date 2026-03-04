using PharmacyJobPlatform.Web.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PharmacyJobPlatform.Web.Models.Profile
{
    public class ProfileEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Doğum tarihi zorunludur")]
        public DateTime? BirthDate { get; set; }

        public bool IsEmailVisible { get; set; }

        public bool IsPhoneNumberVisible { get; set; }

        public string? About { get; set; }

        public string? PharmacyName { get; set; }

        public AddressInputViewModel Address { get; set; } = new();

        public string? ExistingProfileImagePath { get; set; }
        public IFormFile? ProfileImage { get; set; }

        public string? ExistingCvFilePath { get; set; }
        public IFormFile? CvFile { get; set; }

        public bool IsCvVisible { get; set; }

        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Yeni şifre en az 6 karakter olmalıdır.")]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Yeni şifreler birbiriyle aynı olmalıdır.")]
        public string? ConfirmNewPassword { get; set; }


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

        public List<WorkExperienceEditModel> WorkExperiences { get; set; }
            = new();
    }

    public class WorkExperienceEditModel
    {
        public int? Id { get; set; }
        public string PharmacyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

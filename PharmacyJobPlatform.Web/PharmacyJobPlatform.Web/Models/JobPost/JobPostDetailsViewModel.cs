using PharmacyJobPlatform.Domain.Enums;

namespace PharmacyJobPlatform.Web.Models.JobPost
{
    public class JobPostDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public JobType JobType { get; set; }

        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;

        public decimal? DailyWage { get; set; }
        public DateTime? WorkDate { get; set; }

        public decimal? MonthlySalary { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PharmacyOwnerId { get; set; }
        public string PharmacyOwnerFullName { get; set; } = null!;
        public string PharmacyName { get; set; } = null!;
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }
        public string? AddressDescription { get; set; }

        public bool AlreadyApplied { get; set; }
    }
}

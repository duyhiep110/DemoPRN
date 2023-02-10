using System.ComponentModel.DataAnnotations;

namespace DemoPRN.Dtos.Company
{
    public abstract class CompanyForManipulationDto
    {
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the name is 60 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the name is 60 characters.")]
        public string? Address { get; set; }

        public string? Country { get; set; }
    }
}

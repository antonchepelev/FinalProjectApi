using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectApi.Models
{
    public class TeamMember
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [StringLength(200)]
        public string CollegeProgram { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [RegularExpression("^(Freshman|Sophomore|Junior|Senior|Graduate)$",
            ErrorMessage = "YearInProgram must be Freshman, Sophomore, Junior, Senior or Graduate.")]
        public string YearInProgram { get; set; } = string.Empty;
    }
}
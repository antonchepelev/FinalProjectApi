using System.ComponentModel.DataAnnotations;

namespace FinalProjectApi.Models
{
    public class FavoriteGame
    {
        public int Id { get; set; }

        [Required]
        public int Rank { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Genre { get; set; } = string.Empty;

        public int HoursPlayed { get; set; }

        [StringLength(100)]
        public string? FavoriteCharacter { get; set; }

        [StringLength(300)]
        public string? WhyILikeIt { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MyAssessment.WebMVC.Models
{
    public class HomeProduct
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Des { get; set; }

        public string? ImgUrl { get; set; }

        public double UnitPrice { get; set; }

        public int Likes { get; set; }

        public int Quantity { get; set; }

        // Add this new property
        [MaxLength(50)]
        public string? Category { get; set; }  // "Anniversary", "Birthday", "Grand Gestures"
    }
}

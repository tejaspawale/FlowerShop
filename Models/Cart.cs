using System.ComponentModel.DataAnnotations;

namespace MyAssessment.WebMVC.Models
{
    public class Cart
    {
        public List<CartItem>? Items { get; set; }
    }
}
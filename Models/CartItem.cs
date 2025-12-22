using System.ComponentModel.DataAnnotations;

namespace MyAssessment.WebMVC.Models
{
    public class CartItem
    {
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
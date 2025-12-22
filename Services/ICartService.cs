using System.ComponentModel.DataAnnotations;
using MyAssessment.WebMVC.Models;

namespace MyAssessment.WebMVC.Services
{
    public interface ICartService
    {
        List<CartItem> GetCart();
        void AddToCart(Product product);
        void RemoveFromCart(int id);
    }
}
using MyAssessment.WebMVC.Models;
using Microsoft.AspNetCore.Http;
using MyAssessment.WebMVC.Helpers;

namespace MyAssessment.WebMVC.Services
{
    public class CartService : ICartService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public List<CartItem> GetCart()
        {
            var session = _httpContextAccessor.HttpContext!.Session;
            var cart = session.GetObject<List<CartItem>>("CART")
              ?? new List<CartItem>();
            return cart;
        }
        public void AddToCart(Product product)
        {
            var session = _httpContextAccessor.HttpContext!.Session;
            var cart = session.GetObject<List<CartItem>>("CART")
              ?? new List<CartItem>();

            var item = cart.FirstOrDefault(c => c.Product.Id == product.Id);

            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    Product = product,
                    Quantity = 1
                });
                session.SetObject("CART", cart);
            }
        }
        public void RemoveFromCart(int id)
        {
            var session = _httpContextAccessor.HttpContext!.Session;
            List<CartItem> cart = session.GetObject<List<CartItem>>("CART")
              ?? new List<CartItem>();

            var item = cart.FirstOrDefault(c => c.Product.Id == id);
            if (item != null)
            {
                cart.Remove(item);
                session.SetObject("CART", cart);
            }

        }
    }
}
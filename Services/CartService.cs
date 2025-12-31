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

         private ISession Session => _httpContextAccessor.HttpContext!.Session;
        public List<CartItem> GetCart()
        {
            var session = _httpContextAccessor.HttpContext!.Session;
            var cart = session.GetObject<List<CartItem>>("CART") ?? new List<CartItem>();
            return cart;
        }
       
            public void AddToCart(Product product, int qty = 1)
{
    var session = _httpContextAccessor.HttpContext!.Session;
    var cart = session.GetObject<List<CartItem>>("CART")
              ?? new List<CartItem>();

    var item = cart.FirstOrDefault(c => c.Product!.Id == product.Id);

    if (item != null)
    {
        item.Quantity += qty;        // increase by qty
    }
    else
    {
        cart.Add(new CartItem
        {
            Product = product,
            Quantity = qty
        });
    }

    session.SetObject("CART", cart); // always save after change
}



        public void RemoveFromCart(int id)
        {
            var session = _httpContextAccessor.HttpContext!.Session;
            List<CartItem> cart = session.GetObject<List<CartItem>>("CART")
              ?? new List<CartItem>();

           var item = cart.FirstOrDefault(c => c.Product!.Id == id);

            if (item != null)
            {
                cart.Remove(item);
                session.SetObject("CART", cart);
            }

        }

        // public void AddToCart(Product product, int qty = 1)
        // {
        //     throw new NotImplementedException();
        // }

        public void IncreaseQuantity(int id)
{
    var cart = GetCart();
    var item = cart.FirstOrDefault(c => c.Product != null && c.Product.Id == id);
    
    if (item != null)
    {
        item.Quantity++;
        Session.SetObject("CART", cart);
    }
}

public void DecreaseQuantity(int id)
{
    var cart = GetCart();
    var item = cart.FirstOrDefault(c => c.Product != null && c.Product.Id == id);
    
    if (item != null)
    {
        item.Quantity--;
        if (item.Quantity <= 0)
            cart.Remove(item);

        Session.SetObject("CART", cart);
    }
}

    }
}
using Microsoft.AspNetCore.Mvc;
using WEB.Extensions;
using WEB.Models;

namespace WEB.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Cart _cart;
        public CartViewComponent(Cart cart) => _cart = cart;
        
        public IViewComponentResult Invoke() => View(_cart);
        
    }
}

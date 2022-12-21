using Microsoft.AspNetCore.Mvc;
using AbodeBoutiqueStore.Models;
namespace AbodeBoutiqueStore.Components
{
    
    // method that returns the a view component which is populated with the cart details
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
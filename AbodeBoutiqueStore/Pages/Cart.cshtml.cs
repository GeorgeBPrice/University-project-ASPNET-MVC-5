using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AbodeBoutiqueStore.Infrastructure;
using AbodeBoutiqueStore.Models;
using System.Linq;

namespace AbodeBoutiqueStore.Pages
{
    // this class is the logic used to access product data using the IStoreRepository
    // to retrieve the products data
    // with the provided methods to add/remove
    // and also a return URL
    public class CartModel : PageModel
    {
        // define repo
        private IStoreRepository repository;

        // initialise and access repo and cart
        public CartModel(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        // getters and setters
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        // The add-to-cart button causes POST event on submit, and adds product line 
        
        public IActionResult OnPost(long productId, int quantity, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            // make sure user has added a product with at a quantity of at least 1
            if (quantity > 0)
            {
                Cart.AddItem(product, quantity);
                return RedirectToPage(new { returnUrl = returnUrl });
            }

            // otherwise return user back to catalog. Ideally validation would prevent posting entirely
            return Redirect(returnUrl);

        }

        // removes the line the the cart, and reloads its to update removal and total
        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Product.ProductID == productId).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
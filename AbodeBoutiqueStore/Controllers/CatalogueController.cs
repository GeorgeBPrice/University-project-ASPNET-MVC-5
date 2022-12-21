using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AbodeBoutiqueStore.Models;

namespace AbodeBoutiqueStore.Controllers
{
    public class CatalogueController : Controller
    {

        // initialise local access to repository of products
        private IStoreRepository repository;

        public CatalogueController(IStoreRepository repo)
        {
            repository = repo;
        }

        // default index view and routing for catalog pages, populating with products drawn from the repo/database
        [Route("Catalogue")]
        [Route("Catalogue/{category}")]
        public IActionResult Index(string category = null)
        {
            ViewBag.pageName = "Catalogue";

            return View(repository.Products
                .Where(p => category == null || p.Category == category));

        }

        // routing and view for each single product detail page, with info drawn from the repo/database
        [Route("Product/{productId}")]
        public IActionResult ProductDetails(int productId)
        {

            ViewBag.pageName = "Product";

            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            return View(product);
        }


    }
}

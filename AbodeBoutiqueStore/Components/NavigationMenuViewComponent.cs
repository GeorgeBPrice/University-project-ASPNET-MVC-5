using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using AbodeBoutiqueStore.Models;

namespace AbodeBoutiqueStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        
        // access the products database table repository
        private IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        
        // populate the category side bar menu, drawn from product categories in the Product database
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
            );
        }
    }
}
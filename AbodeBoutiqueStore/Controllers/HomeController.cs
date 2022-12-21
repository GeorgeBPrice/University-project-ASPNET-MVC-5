using Microsoft.AspNetCore.Mvc;

namespace AbodeBoutiqueStore.Controllers
{
    public class HomeController : Controller
    {
        
        // default index view for the homepage
        public IActionResult Index()
        {
            ViewBag.pageName = "Home";

            return View();
        }
    }
}
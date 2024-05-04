using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class DbContext : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult About()
        {
            return View("About");
        }
        public IActionResult Contact()
        {
            return View("Contact");
        }
        public IActionResult Category()
        {
            return View("Category");
        }

    }
}

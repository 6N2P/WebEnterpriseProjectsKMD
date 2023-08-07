using Microsoft.AspNetCore.Mvc;

namespace WebEnterpriseProjectsKMD.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}

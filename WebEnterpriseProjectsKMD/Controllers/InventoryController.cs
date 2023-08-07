using Microsoft.AspNetCore.Mvc;

namespace WebEnterpriseProjectsKMD.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

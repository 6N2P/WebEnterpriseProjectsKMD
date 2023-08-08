using Microsoft.AspNetCore.Mvc;
using WebEnterpriseProjectsKMD.Interfaces;
using WebEnterpriseProjectsKMD.ViewModels;
using WebEnterpriseProjectsKMD.Repository;

namespace WebEnterpriseProjectsKMD.Controllers
{
    public class InventoryController : Controller
    {
        private KMDContext db = new KMDContext();
        private IALLInvetorys _inventorys;

        public InventoryController()
        {

            _inventorys = new InventoryRepository(db);
        }
        //public InventoryController(IALLInvetorys invetorys)
        //{

        //    _inventorys = invetorys;
        //}

        public IActionResult Index()
        {
            var inventorysView = new InventoryViewModel
            {
                inventories = _inventorys.Inventories,
            };
            return View(inventorysView);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}

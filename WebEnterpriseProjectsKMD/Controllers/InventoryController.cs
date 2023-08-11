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
        private IInvetorysWorker _invetorysWorker;

        public InventoryController()
        {
            InventoryRepository inventoryRepository = new InventoryRepository(db);
            _inventorys = inventoryRepository;
            _invetorysWorker = inventoryRepository;
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

        public IActionResult InventoryEdit(int idInventory, string codeInventory)
        {
            ViewBag.Id = idInventory;
            ViewBag.Code = codeInventory;
            return View();
        }

        [HttpPost]
        public IActionResult InventoryEdit(Inventory inventory)
        {
            _invetorysWorker.EditInventory(inventory.Id, inventory.Name);
            return  RedirectToAction("Index");
        }


    }
}

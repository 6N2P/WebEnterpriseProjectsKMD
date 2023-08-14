using Microsoft.AspNetCore.Mvc;
using WebEnterpriseProjectsKMD.Interfaces;
using WebEnterpriseProjectsKMD.ViewModels;
using WebEnterpriseProjectsKMD.Repository;

namespace WebEnterpriseProjectsKMD.Controllers
{
    public class InventoryController : Controller
    {
        private KMDContext db;
        private IALLInvetorys _inventorys;
        private IInvetorysWorker _invetorysWorker;

        public InventoryController()
        {
            db = new KMDContext();
            InventoryRepository inventoryRepository = new InventoryRepository(db);
            _inventorys = inventoryRepository;
            _invetorysWorker = inventoryRepository;
        }       

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

        public IActionResult DeletInventory(int idInventory, string codeInventory)
        {
            ViewBag.InventoryId=idInventory;
            ViewBag.Code = codeInventory;
            return View();
        }
        [HttpPost]
        public IActionResult DeletInventory(Inventory inventory)
        {
            _invetorysWorker.DeleteInventory(inventory.Id);
            return RedirectToAction("Index");
        }
    }
}

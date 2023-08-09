using Microsoft.AspNetCore.Mvc;
using WebEnterpriseProjectsKMD.Interfaces;
using WebEnterpriseProjectsKMD.Repository;

namespace WebEnterpriseProjectsKMD.Controllers
{
    public class CreateInventoryController : Controller
    {
        private readonly Inventory inventory;
        private readonly IInvetorysWorker invetorysWorker;
        private readonly KMDContext appDB;

        public CreateInventoryController ()
        {
            appDB = new KMDContext ();
            invetorysWorker = new InventoryRepository(appDB);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Inventory inventory)
        {
            invetorysWorker.CreateInventory(inventory);
            return RedirectToAction("Complete");
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Инвентарный успешно создан";
            return View();
        }
    }
}

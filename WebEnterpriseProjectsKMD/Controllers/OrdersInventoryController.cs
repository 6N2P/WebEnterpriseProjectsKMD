using Microsoft.AspNetCore.Mvc;
using WebEnterpriseProjectsKMD.Interfaces;
using WebEnterpriseProjectsKMD.Repository;
using WebEnterpriseProjectsKMD.ViewModels;

namespace WebEnterpriseProjectsKMD.Controllers
{
    public class OrdersInventoryController : Controller
    {
      
        
        
        private readonly IALLOrders _allOrders;
        private readonly IOrdersWorker _ordersWorker;
        private readonly KMDContext _appDB;
        private int _idSelectInventory;

       

        public OrdersInventoryController()
        {
            _appDB = new KMDContext();
            _allOrders = new OrderRepository(_appDB);
            _ordersWorker = new OrderRepository(_appDB);
          
        }
        public IActionResult Orders(int IdinventorySelect)
        {
            ViewBag.Id = IdinventorySelect;

            var items = _allOrders.GetOrdersFromInventory(IdinventorySelect);
            OrdersInventoryViewModel ordersFromInvenory = new OrdersInventoryViewModel();
            if (items != null) 
            { 
                ordersFromInvenory.orders = items;
            }
          
            return View(ordersFromInvenory);
        }
        public IActionResult CreateOrder(int IdinventorySelect)
        {           
            ViewBag.Id = IdinventorySelect;
            return View(); 
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            
            _ordersWorker.CreateOrdery(order);
            return RedirectToAction("Complete",new { IdinventorySelect = order.InvenoryId } );
        }

        public IActionResult Complete(int IdinventorySelect)
        {            
            ViewBag.Id = IdinventorySelect;
            ViewBag.Message = "Заказ успешно создан";
            return View();
        }

        public IActionResult OrderEdit(int idInventory, int idOrder, string codeOrder)
        {
            ViewBag.InventoryId = idInventory;
            ViewBag.OrderId = idOrder;
            ViewBag.Code = codeOrder;
            return View();
        }

        [HttpPost]
        public IActionResult OrderEdit(Order order)
        {
            _ordersWorker.EditOrder(order.Id, order.Name);
            return RedirectToAction("Orders",new { IdinventorySelect = order.InvenoryId });
        }

        public IActionResult DeletOrder(int idInventory,int idOrder, string codeOrder)
        {
            ViewBag.OrderId = idOrder;
            ViewBag.InventoryId = idInventory;
            ViewBag.Code = codeOrder;
            return View();
        }
        [HttpPost]
        public IActionResult DeletOrder(Order order)
        {
            _ordersWorker.DeleteOrder(order.Id);
            return RedirectToAction("Orders", new { IdinventorySelect = order.InvenoryId });
        }
    }
   
}

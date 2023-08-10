using Microsoft.AspNetCore.Mvc;
using WebEnterpriseProjectsKMD.Interfaces;
using WebEnterpriseProjectsKMD.Repository;
using WebEnterpriseProjectsKMD.ViewModels;

namespace WebEnterpriseProjectsKMD.Controllers
{
    public class OrdersInventoryController : Controller
    {
      
        private readonly Inventory Inventory;
        private readonly IALLOrders AllOrders;
        private readonly KMDContext appDB;

        public OrdersInventoryController() 
        {            
            appDB = new KMDContext();
            AllOrders = new OrderRepository(appDB);
        }
        public IActionResult Orders(int IdinventorySelect)
        {
            
            var items = AllOrders.GetOrdersFromInventory(IdinventorySelect);
            OrdersInventoryViewModel ordersFromInvenory = new OrdersInventoryViewModel();
            if (items != null) 
            { 
                ordersFromInvenory.orders = items;
            }
            //else
            //{
            //    Order order = new Order();
            //    order.Id = 0;
            //    order.Number = "Пусто";
            //    order.Name = "нет значения";

            //    IEnumerable<Order> ordersEnum = new IEnumerable<Order>();
            //    ordersEnum.add(order);
            //    ordersFromInvenory.orders= ordersEnum;
            //}
            return View(ordersFromInvenory);
        }
    }
}

using WebEnterpriseProjectsKMD.Interfaces;

namespace WebEnterpriseProjectsKMD.Repository
{
    public class OrderRepository : IALLOrders, IOrdersWorker
    {
        private readonly KMDContext _appDBcontext;

        public OrderRepository(KMDContext appDBcontext)
        {
            _appDBcontext = appDBcontext;
        }

        public IEnumerable<Order> Orders => _appDBcontext.Orders;

        public void CreateOrdery(Order order)
        {
            _appDBcontext.Orders.Add(order);
            _appDBcontext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersFromInventory(int inventoryId) => _appDBcontext.Orders.Where(x=>x.InvenoryId == inventoryId);

        public void EditOrder(int id, string name)
        {
            var order = _appDBcontext.Orders.FirstOrDefault(x=>x.Id == id);
            order.Name= name;
            _appDBcontext.SaveChanges();
        }
    }
}

using WebEnterpriseProjectsKMD.Interfaces;

namespace WebEnterpriseProjectsKMD.Repository
{
    public class OrderRepository : IALLOrders
    {
        private readonly KMDContext _appDBcontext;

        public OrderRepository(KMDContext appDBcontext)
        {
            _appDBcontext = appDBcontext;
        }

        public IEnumerable<Order> Orders => _appDBcontext.Orders;

        public IEnumerable<Order> GetOrdersFromInventory(int inventoryId) => _appDBcontext.Orders.Where(x=>x.InvenoryId == inventoryId);
        
    }
}

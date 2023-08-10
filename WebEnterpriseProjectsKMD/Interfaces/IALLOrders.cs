namespace WebEnterpriseProjectsKMD.Interfaces
{
    public interface IALLOrders
    {
        public IEnumerable<Order> Orders { get; }
        public IEnumerable<Order> GetOrdersFromInventory(int inventoryId);
    }
}

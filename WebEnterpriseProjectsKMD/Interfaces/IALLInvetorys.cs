namespace WebEnterpriseProjectsKMD.Interfaces
{
    public interface IALLInvetorys
    {
        public IEnumerable<Inventory> Inventories { get; }
        public Inventory GetInventory(int inventoryId);
    }
}

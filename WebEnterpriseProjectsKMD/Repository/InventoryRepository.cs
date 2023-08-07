using WebEnterpriseProjectsKMD.Interfaces;

namespace WebEnterpriseProjectsKMD.Repository
{
    public class InventoryRepository : IALLInvetorys
    {
        private readonly KMDContext _appDBcontext;
        public InventoryRepository(KMDContext appDBcontext)
        {
            _appDBcontext = appDBcontext;
        }

        public IEnumerable<Inventory> Inventories => _appDBcontext.Inventories;

        public Inventory GetInventory(int inventoryId) => _appDBcontext.Inventories.Where(x => x.Id == inventoryId).FirstOrDefault();
    }
}

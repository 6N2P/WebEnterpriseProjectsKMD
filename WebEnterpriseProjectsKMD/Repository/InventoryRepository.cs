using WebEnterpriseProjectsKMD.Interfaces;

namespace WebEnterpriseProjectsKMD.Repository
{
    public class InventoryRepository : IALLInvetorys,  IInvetorysWorker
    {
        private readonly KMDContext _appDBcontext;
        public InventoryRepository(KMDContext appDBcontext)
        {
            _appDBcontext = appDBcontext;
        }

        public IEnumerable<Inventory> Inventories => _appDBcontext.Inventories;

        public void CreateInventory(Inventory inventory)
        {
           _appDBcontext.Inventories.Add(inventory);
            _appDBcontext.SaveChanges();
        }

        public void DeleteInventory(int id)
        {
            throw new NotImplementedException();
        }

        public Inventory GetInventory(int inventoryId) => _appDBcontext.Inventories.Where(x => x.Id == inventoryId).FirstOrDefault();

        public void UpdateInventory(int id, string n)
        {
            throw new NotImplementedException();
        }
    }
}

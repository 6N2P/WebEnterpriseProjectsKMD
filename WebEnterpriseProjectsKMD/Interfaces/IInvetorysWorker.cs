namespace WebEnterpriseProjectsKMD.Interfaces
{
    public interface IInvetorysWorker
    {
        public void CreateInventory(Inventory inventory);
        public void EditInventory(int id,string n);
        public void DeleteInventory(int id);
    }
}

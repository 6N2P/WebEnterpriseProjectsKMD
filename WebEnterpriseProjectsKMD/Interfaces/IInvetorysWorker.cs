namespace WebEnterpriseProjectsKMD.Interfaces
{
    public interface IInvetorysWorker
    {
        public void CreateInventory();
        public void UpdateInventory(int id,string n);
        public void DeleteInventory(int id);
    }
}

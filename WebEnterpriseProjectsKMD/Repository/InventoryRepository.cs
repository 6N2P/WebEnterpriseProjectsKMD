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
            //Удаляю все детали из инвентрного
            var detailInventory = _appDBcontext.Parts.Where(x => x.InventorieId == id);
            if (detailInventory != null)
            {
                foreach (var item in detailInventory)
                {
                    _appDBcontext.Parts.Remove(item);
                }
                _appDBcontext.SaveChanges();
            }

            //Удаляю заказ
            var orders = _appDBcontext.Orders.Where(x => x.InvenoryId == id).ToList();

            if (orders != null)
            {
                //id заказов для удаления марок из таблицы Mark
                List<int> idOrders = new List<int>();

                foreach (var order in orders)
                {
                    idOrders.Add(order.Id);
                    _appDBcontext.Orders.Remove(order);
                }
                _appDBcontext.SaveChanges();
                //получаю все  марок
                var mars = _appDBcontext.Marks.ToList();
                if (mars != null)
                {
                    List<int> idMarks = new List<int>();
                    foreach (var mark in mars)
                    {
                        foreach (var item in idOrders)
                        {
                            if (item == mark.OrderId)
                            {
                                idMarks.Add(mark.Id);
                                _appDBcontext.Marks.Remove(mark);
                            }
                        }
                    }
                    _appDBcontext.SaveChanges();
                    //Удаляю все строки заказа
                    var markRow = _appDBcontext.MarksRows.ToList();
                    if (markRow != null)
                    {
                        foreach (var row in markRow)
                        {
                            foreach (var item in idMarks)
                            {
                                if (item == row.MarkId)
                                {
                                    _appDBcontext.MarksRows.Remove(row);
                                }
                            }
                        }
                        _appDBcontext.SaveChanges();
                    }
                }

            }

            //Удаляю инвентарный
            var inventory = _appDBcontext.Inventories.FirstOrDefault(x => x.Id == id);
            if (inventory != null)
            {
                _appDBcontext.Inventories.Remove(inventory);
                _appDBcontext.SaveChanges();
            }

        }

        public Inventory GetInventory(int inventoryId) => _appDBcontext.Inventories.Where(x => x.Id == inventoryId).FirstOrDefault();

        public void EditInventory(int id, string name)
        {
            var inv = _appDBcontext.Inventories.Where(x=>x.Id == id).FirstOrDefault();
            if (inv != null)
            {
                inv.Name = name;
                inv.DateCreate = DateOnly.FromDateTime(DateTime.Now);
                _appDBcontext.SaveChanges();
            }
           
        }
    }
}

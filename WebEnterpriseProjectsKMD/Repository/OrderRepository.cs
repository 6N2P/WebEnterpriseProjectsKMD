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

        public void DeleteOrder(int idOrder)
        {
            var idMarks = GetIDMarks(idOrder);
            DeletAllRowsMarks(idMarks);
            DeletMarksFromOrder(idOrder);
            var order = _appDBcontext.Orders.FirstOrDefault(x => x.Id == idOrder);
            if (order != null)
            {
                _appDBcontext.Orders.Remove(order);
                _appDBcontext.SaveChanges();
            }
        }

        public IEnumerable<Order> GetOrdersFromInventory(int inventoryId) => _appDBcontext.Orders.Where(x=>x.InvenoryId == inventoryId);

        public void EditOrder(int id, string name)
        {
            var order = _appDBcontext.Orders.FirstOrDefault(x=>x.Id == id);
            order.Name= name;
            _appDBcontext.SaveChanges();
        }

        private List<int> GetIDMarks(int idOrder)
        {
            List<int> idMarks = new List<int>();
            var marks = _appDBcontext.Marks.Where(x => x.Id == idOrder).ToList();
            if (marks != null)
            {
                foreach (var mark in marks)
                {
                    idMarks.Add(mark.Id);
                }
            }

            return idMarks;
        }
        private void DeletAllRowsMarks(List<int> idMarks)
        {
            if (idMarks != null)
            {
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
        private void DeletMarksFromOrder(int idOrder)
        {
            var marks = _appDBcontext.Marks.Where(x=>x.Id == idOrder).ToList();
            if(marks != null)
            {
                foreach(var mark in marks)
                {
                    _appDBcontext.Marks.Remove(mark);
                }
                _appDBcontext.SaveChanges();
            }
        }
    }
}

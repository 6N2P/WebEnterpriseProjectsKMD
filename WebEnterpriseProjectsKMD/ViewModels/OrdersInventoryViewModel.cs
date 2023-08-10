using System.Data.SqlTypes;

namespace WebEnterpriseProjectsKMD.ViewModels
{
    public class OrdersInventoryViewModel
    {
        public IEnumerable<Order> orders { get; set; }
    }
}

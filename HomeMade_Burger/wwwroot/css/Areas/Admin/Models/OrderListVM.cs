using HomeMade_Burger.Models;
using HomeMade_Burger.ViewModels.OrderVM;

namespace HomeMade_Burger.Areas.Admin.Models
{
    public class OrderListVM
    {
        public List<Order> Orders { get; set; }
        public List<OrderMenuDetail> MenuDetails { get; set; }
        public List<Ekstra> Ekstras { get; set; }
    }
}

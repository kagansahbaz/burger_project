using HomeMade_Burger.Models;
using HomeMade_Burger.ViewModels.OrderVM;

namespace HomeMade_Burger.Areas.Admin.Models
{
    public class OrderListVM
    {
        public List<Product> Products { get; set; }
        public List<OrderDetail> Details { get; set; }
        public List<Order> Orders { get; set; }
    }
}

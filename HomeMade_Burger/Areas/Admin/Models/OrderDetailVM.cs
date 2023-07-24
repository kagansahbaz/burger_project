using HomeMade_Burger.Models;

namespace HomeMade_Burger.Areas.Admin.Models
{
    public class OrderDetailVM
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

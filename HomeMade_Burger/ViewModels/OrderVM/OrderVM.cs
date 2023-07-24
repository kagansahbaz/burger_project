using HomeMade_Burger.Models;

namespace HomeMade_Burger.ViewModels.OrderVM
{
    public class OrderVM
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

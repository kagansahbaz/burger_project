
namespace HomeMade_Burger.Models
{
    public class OrderDetail
    {
        // Order Navigation Properties
        public int OrderID { get; set; }
        public Order Order { get; set; }

        // Menu Navigation Properties
        public int ProductID { get; set; }
        public Product Product { get; set; }     
        public int Quantity { get; set; }    

        
    }
}


namespace HomeMade_Burger.Models
{
    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Photo { get; set; }

        // OrderDetail Navigation Properties
        public ICollection<OrderDetail> OrderDetails { get; set; }

        // Category Navigation Property
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}

namespace HomeMade_Burger.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        // Product Navigation Properties
        public ICollection<Product> Products { get; set; }
    }
}

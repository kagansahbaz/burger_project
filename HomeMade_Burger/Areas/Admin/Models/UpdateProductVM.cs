
namespace HomeMade_Burger.Areas.Admin.Models
{
    public class UpdateProductVM
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Photo { get; set; }
        public string? Description { get; set; }
    }
}

using HomeMade_Burger.Models;

namespace HomeMade_Burger.Repositories.Abstract
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        public IEnumerable<Product> GetProductWithCategories();
        
    }
}

using HomeMade_Burger.Context;
using HomeMade_Burger.Models;
using HomeMade_Burger.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HomeMade_Burger.Repositories.Concrete
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly BurgerDBContext db;
        public ProductRepository(BurgerDBContext db) : base(db)
        {
            this.db = db;
        }

       
        public IEnumerable<Product> GetProductWithCategories()
        {
            return db.Products.Include(x=>x.Category);
        }

    }
}

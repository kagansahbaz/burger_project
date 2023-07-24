using HomeMade_Burger.Context;
using HomeMade_Burger.Models;
using HomeMade_Burger.Repositories.Abstract;

namespace HomeMade_Burger.Repositories.Concrete
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly BurgerDBContext db;

        public CategoryRepository(BurgerDBContext db) : base(db)
        {
            this.db = db;
        }
    }
}

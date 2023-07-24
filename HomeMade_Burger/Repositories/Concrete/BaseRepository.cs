using HomeMade_Burger.Context;
using HomeMade_Burger.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HomeMade_Burger.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly BurgerDBContext db;
        private readonly DbSet<T> set;
        public BaseRepository(BurgerDBContext db)
        {
            this.db = db;
            set = this.db.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await set.AddAsync(entity);
            return 0 < await db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            set.Remove(entity);
            return 0 < await db.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return set;
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await set.FindAsync(id);
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return set.Where(predicate);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            set.Update(entity);
            return 0 < await db.SaveChangesAsync(); ;
        }

    }
}

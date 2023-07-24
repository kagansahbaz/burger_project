using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomeMade_Burger.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<T> GetByIDAsync(int id);
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);
    }
}

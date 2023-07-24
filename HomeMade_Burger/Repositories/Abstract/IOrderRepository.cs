using HomeMade_Burger.Models;

namespace HomeMade_Burger.Repositories.Abstract
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public IEnumerable<Order> GetOrdersWithUserAndProducts();

    }
}

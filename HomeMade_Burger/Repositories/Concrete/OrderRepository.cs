using HomeMade_Burger.Context;
using HomeMade_Burger.Models;
using HomeMade_Burger.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HomeMade_Burger.Repositories.Concrete
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly BurgerDBContext db;
        public OrderRepository(BurgerDBContext db) : base(db)
        {
            this.db = db;
        }

        public IEnumerable<Order> GetOrdersWithUserAndProducts()
        {
            return db.Orders.Include(x => x.User).Include(x => x.OrderDetails);
        }

    }
}

using HomeMade_Burger.Areas.Admin.Models;
using HomeMade_Burger.Models;

namespace HomeMade_Burger.Repositories.Abstract
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
        public decimal GetOrderTotalPrice(int orderID);
        public IEnumerable<OrderDetailVM> GetOrderDetail(int orderID);
    }
}

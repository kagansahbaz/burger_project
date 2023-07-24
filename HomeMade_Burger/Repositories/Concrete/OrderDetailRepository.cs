using HomeMade_Burger.Areas.Admin.Models;
using HomeMade_Burger.Context;
using HomeMade_Burger.Models;
using HomeMade_Burger.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HomeMade_Burger.Repositories.Concrete
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly BurgerDBContext db;
        public OrderDetailRepository(BurgerDBContext db) : base(db)
        {
            this.db = db;
        }

        public IEnumerable<OrderDetailVM> GetOrderDetail(int orderID)   //ÇOK ŞIK BİR REPOSİTORY
        {
            var result = db.OrderDetails
                .Join(db.Products, od => od.ProductID, p => p.ProductID, (od, p) => new { od, p })
                .Where(x => x.od.OrderID == orderID)
                .Select(x => new OrderDetailVM { ProductName = x.p.ProductName, Quantity = x.od.Quantity, Price = x.p.Price }).ToList();
            return result;
        }

        public decimal GetOrderTotalPrice(int orderID)
        {
            var result = db.OrderDetails
                           .Join(db.Products, od => od.ProductID, p => p.ProductID, (od, p) => new { od, p })
                           .Where(x => x.od.OrderID == orderID)
                           .GroupBy(x => x.od.OrderID)
                           .Select(grouped => grouped.Sum(x => x.od.Quantity * x.p.Price))
                           .SingleOrDefault();

            return result;
        }

    }
}

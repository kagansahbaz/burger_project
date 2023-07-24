using HomeMade_Burger.Context;
using Microsoft.AspNetCore.Mvc;

namespace HomeMade_Burger.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly BurgerDBContext db;

        public AdminController(BurgerDBContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetList()
        {
            var orderList = db.Orders.ToList();
            return PartialView("Index", orderList);
        }

        public IActionResult GetMenuList()
        {
            var menuList = db.Menus.ToList();
            return PartialView("Index", menuList);
        }
    }
}

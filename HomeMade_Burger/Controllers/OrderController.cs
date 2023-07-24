using AutoMapper;
using AutoMapper.QueryableExtensions;
using HomeMade_Burger.Models;
using HomeMade_Burger.Repositories.Abstract;
using HomeMade_Burger.ViewModels.OrderVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HomeMade_Burger.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly IOrderDetailRepository orderDetailRepository;
        public static List<OrderVM> basketItemLists = new();
        private readonly UserManager<User> userManager;

        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository,IMapper mapper , IOrderDetailRepository orderDetailRepository, UserManager<User> userManager)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.orderDetailRepository = orderDetailRepository;
            this.userManager = userManager;
        }
        public IActionResult ProductList()
        {
            var productList = productRepository.GetAll();

            return PartialView("_productListPartial", productList);
        }

        public IActionResult GiveOrder()
        {
            ViewBag.ProductList = productRepository.GetAll();

            return View();
        }
        [HttpPost]
        public IActionResult GiveOrder(OrderVM productOrder)
        {
            return View();
        }


        public async Task<IActionResult> AddBasket(int productId, int quantity)
        {
            Product product = await productRepository.GetByIDAsync(productId);
            OrderVM orderVM = mapper.Map<OrderVM>(product);
            orderVM.Quantity = quantity;

            basketItemLists.Add(orderVM);
            ViewBag.Basket = basketItemLists;
            return PartialView("_BasketPartial", basketItemLists);
        }

        

        public async Task<IActionResult> RemoveBasket(int ItemBasket)
        {
            basketItemLists.Remove(basketItemLists[ItemBasket-1]);

            return PartialView("_BasketPartial", basketItemLists);
        }

        

        public async Task<IActionResult> AddOrder()
        {
            User user = await userManager.GetUserAsync(User);

            Order order = new Order()
            {
                UserID = user.Id,
                OrderDetails = new HashSet<OrderDetail>()
            };

            foreach (OrderVM item in basketItemLists)
            {
                order.OrderDetails.Add(new OrderDetail { ProductID = item.ProductID, Quantity = item.Quantity });
            }

            await orderRepository.AddAsync(order);
            basketItemLists.Clear();

            return RedirectToAction("GiveOrder");
        }

    }
}

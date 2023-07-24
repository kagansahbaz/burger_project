using AutoMapper;
using HomeMade_Burger.Areas.Admin.Models;
using HomeMade_Burger.Models;
using HomeMade_Burger.Repositories.Abstract;
using HomeMade_Burger.Repositories.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeMade_Burger.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository orderDetailRepository;

        public AdminController(IMapper mapper, IProductRepository productRepository,ICategoryRepository categoryRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
        }



        public IActionResult Index()
        {

            return View();
        }
        //********************************************************************** ORDER ***************************************************

        //-------------------- LİST ORDER --------------------
        public IActionResult GetOrderList()
        {
            var orderList = orderRepository.GetOrdersWithUserAndProducts();
            return PartialView("_GetOrderListPartial", orderList);
        }

        public IActionResult GetOrderDetails(int orderID)
        {
            var orderDetailsList = orderDetailRepository.GetOrderDetail(orderID);
            ViewBag.TotalPrice = orderDetailRepository.GetOrderTotalPrice(orderID);
            return PartialView("_GetOrderDetailsPartial", orderDetailsList);
        }


        //********************************************************************** PRODUCT ************************************************

        //-------------------- LİST PRODUCT --------------------
        public IActionResult GetProductList()
        {
            var productList = productRepository.GetProductWithCategories();
            return PartialView("_GetProductListPartial", productList);      //_GetProductListPartial admine ekle
        }

        //-------------------- ADD PRODUCT --------------------
        public IActionResult AddProduct()
        {
            ViewBag.Category= new SelectList(categoryRepository.GetAll(), "CategoryID", "CategoryName");
            return PartialView("_AddProductPartial");
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductVM addProductVM)
        {
            if (ModelState.IsValid)
            {
                Product product = mapper.Map<Product>(addProductVM);
                await productRepository.AddAsync(product);
                return Json("Ok");
            }
            else
            {
                TempData["Message"] = "Başarısız işlem";
                return Json("Hata");
            }

        }

        //-------------------- UPDATE PRODUCT --------------------
        public async Task<IActionResult> UpdateProduct(int productId)
        {
            ViewBag.Category = new SelectList(categoryRepository.GetAll(), "CategoryID", "CategoryName");
            Product product = await productRepository.GetByIDAsync(productId);
            UpdateProductVM updateProductVM = mapper.Map<UpdateProductVM>(product);
            return PartialView("_UpdateProductPartial", updateProductVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductVM updateMenuVM)        
        {
            if (ModelState.IsValid)
            {
                Product product = mapper.Map<Product>(updateMenuVM);
                await productRepository.UpdateAsync(product);
                return Json("Ok");
            }
            else
            {
                TempData["Message"] = "Başarısız işlem";
                return Json("Hata");
            }
        }

        //-------------------- DELETE PRODUCT --------------------
        public async Task<IActionResult> ProductDeleteAsync(int productId)
        {
            Product product = await productRepository.GetByIDAsync(productId);
            if (ModelState.IsValid)
            {
                await productRepository.DeleteAsync(product);
                return Json("Ok");
            }
            else
            {
                TempData["Message"] = "Başarısız işlem";
                return Json("Hata");
            }
        }

        //**************************************************************** CATEGORY ***********************************************************

        //-------------------- LİST CATEGORY --------------------
        public IActionResult GetCategoryList()
        {
            var categorytList = categoryRepository.GetAll();
            return PartialView("_GetCategoryListPartial", categorytList);
        }

        //-------------------- ADD CATEGORY --------------------
        public IActionResult AddCategory()
        {
            return PartialView("_AddCategoryPartial");
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryVM addCategoryVM)
        {
            if (ModelState.IsValid)
            {
                Category category = mapper.Map<Category>(addCategoryVM);
                await categoryRepository.AddAsync(category);
                return Json("Ok");
            }
            else
            {
                TempData["Message"] = "Başarısız işlem";
                return Json("Hata");
            }

        }

        //-------------------- UPDATE CATEGORY --------------------
        public async Task<IActionResult> UpdateCategory(int categoryId)
        {
            Category category = await categoryRepository.GetByIDAsync(categoryId);
            UpdateCategoryVM updateCategoryVM = mapper.Map<UpdateCategoryVM>(category);
            return PartialView("_UpdateCategoryPartial", updateCategoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryVM updateCategoryVM)
        {
            if (ModelState.IsValid)
            {
                Category category = mapper.Map<Category>(updateCategoryVM);
                await categoryRepository.UpdateAsync(category);
                return Json("Ok");
            }
            else
            {
                TempData["Message"] = "Başarısız işlem";
                return Json("Hata");
            }
        }


    }
}

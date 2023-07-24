using AutoMapper;
using HomeMade_Burger.Models;
using HomeMade_Burger.ViewModels.UserVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace HomeMade_Burger.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // Kayıt Olmak
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        {
            if (ModelState.IsValid)
            {
                User user = mapper.Map<User>(userRegisterVM);
                IdentityResult resultAddUserToDB = await userManager.CreateAsync(user);

                if (resultAddUserToDB.Succeeded)
                {
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    foreach (var item in resultAddUserToDB.Errors)
                    {
                        ModelState.AddModelError("User Register", $"{item.Code} - {item.Description}");
                    }
                }

            }

            return View(userRegisterVM);
        }


        // User Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(userLoginVM.UserName);

                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    SignInResult resultUserLogin = await signInManager.PasswordSignInAsync(userLoginVM.UserName, userLoginVM.Password, true, false);

                    if (resultUserLogin.Succeeded)
                    {
                        return RedirectToAction("GiveOrder", "Order");
                    }
                    else
                    {
                        ModelState.AddModelError("User Login", $"Kullanıcı girişi başarısız. Kullanıcı adı ve şifre eşleşmiyor");
                    }
                }
                else
                {
                    ModelState.AddModelError("User Login", $"Kullanıcı girişi başarısız. {userLoginVM.UserName} kullanıcı adı mevcut değil");
                }

            }

            return View();

        }


        
    }
}

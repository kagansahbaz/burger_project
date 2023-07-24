using FluentValidation.AspNetCore;
using HomeMade_Burger.Context;
using HomeMade_Burger.Models;
using HomeMade_Burger.Repositories.Abstract;
using HomeMade_Burger.Repositories.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BurgerSalonu_V2._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // DB Connection
            builder.Services.AddDbContext<BurgerDBContext>(options =>
            {
                string connectionString = builder.Configuration.GetConnectionString("Connection");
                options.UseSqlServer(connectionString);
            });
            // Identity
            builder.Services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequireUppercase = true;            // En az bir büyük harf
                opt.Password.RequireDigit = true;                // En az bir rakam
                opt.Password.RequiredUniqueChars = 0;            // Uniq karakter sayýsý
                opt.Password.RequireLowercase = true;            // En az bir küçük harf
                opt.Password.RequiredLength = 6;                 // Minimum þifre uzunluðu
                opt.User.RequireUniqueEmail = true;              // Email'i uniq yapýyor
            }).AddEntityFrameworkStores<BurgerDBContext>();
            // Repositories            
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            // AutoMapper
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Fluent Validation
            builder.Services.AddControllersWithViews().AddFluentValidation(a => a.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // authentication üstte, authorization altta olmalý.
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "default",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Login}/{id?}");
            });
            app.Run();
        }
    }
}
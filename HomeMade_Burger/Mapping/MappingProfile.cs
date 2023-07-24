using AutoMapper;
using HomeMade_Burger.Areas.Admin.Models;
using HomeMade_Burger.Models;
using HomeMade_Burger.ViewModels.OrderVM;
using HomeMade_Burger.ViewModels.UserVM;
using Microsoft.AspNetCore.Identity;

namespace HomeMade_Burger.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // UserRegisterVM - User Mapping
            CreateMap<UserRegisterVM, User>().BeforeMap((src, dest) =>
            {
                var passwordHasher = new PasswordHasher<User>();
                dest.PasswordHash = passwordHasher.HashPassword(null, src.Password);
            });
            // User - UserRegisterVM Mapping
            CreateMap<User, UserRegisterVM>();
            CreateMap<Product, AddProductVM>().ReverseMap();
            CreateMap<Product, UpdateProductVM>().ReverseMap();
            CreateMap<Category, AddCategoryVM>().ReverseMap();
            CreateMap<Category, UpdateCategoryVM>().ReverseMap();
            CreateMap<Product, OrderVM>().ReverseMap();
        }
    }
}

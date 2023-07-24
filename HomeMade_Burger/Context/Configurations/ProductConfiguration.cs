using HomeMade_Burger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Net.WebRequestMethods;

namespace HomeMade_Burger.Context.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductID);
            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID);

            builder.HasData(
                new Product
                {
                    ProductID = 1,
                    ProductName = "Whooper Small",
                    CategoryID = 1,
                    Price = 85.25M,
                    Photo = "https://cdn.yemek.com/mncrop/940/625/uploads/2016/05/ev-yapimi-hamburger.jpg",
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit."
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Whooper Medium",
                    Price = 90.25M,
                    CategoryID = 1,
                    Photo = "https://cdn.yemek.com/mncrop/940/625/uploads/2016/05/ev-yapimi-hamburger.jpg",
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit."
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Whooper Large",
                    Price = 95.25M,
                    CategoryID = 1,
                    Photo = "https://media-cdn.tripadvisor.com/media/photo-s/1b/9a/6a/8e/burger-colorati-e-gustosi.jpg",
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit."
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Big King Small",
                    Price = 92.75M,
                    CategoryID = 1,
                    Photo = "https://cdn.yemek.com/mncrop/940/625/uploads/2016/05/ev-yapimi-hamburger.jpg",
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit."
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "Big King Medium",
                    Price = 97.75M,
                    CategoryID = 1,
                    Photo = "https://cdn.yemek.com/mncrop/940/625/uploads/2016/05/ev-yapimi-hamburger.jpg",
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit."
                },
                new Product
                {
                    ProductID = 6,
                    ProductName = "Big King Large",
                    CategoryID = 1,
                    Price = 103.75M,
                    Photo = "https://cdn.yemek.com/mncrop/940/625/uploads/2016/05/ev-yapimi-hamburger.jpg",
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit."
                },
                new Product
                {
                    ProductID = 7,
                    ProductName = "Steak House Small",
                    CategoryID = 1,
                    Price = 113.95M,
                    Photo = "https://cdn.yemek.com/mncrop/940/625/uploads/2016/05/ev-yapimi-hamburger.jpg",
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit."
                },
                new Product
                {
                    ProductID = 8,
                    ProductName = "Steak House Medium",
                    CategoryID = 1,
                    Price = 118.95M,
                    Photo = "https://cdn.yemek.com/mncrop/940/625/uploads/2016/05/ev-yapimi-hamburger.jpg",
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit."
                },
                new Product
                {
                    ProductID = 9,
                    ProductName = "Steak House Large",
                    CategoryID = 1,
                    Price = 123.95M,
                    Photo = "https://cdn.yemek.com/mncrop/940/625/uploads/2016/05/ev-yapimi-hamburger.jpg",
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit."
                },
                new Product
                {
                    ProductID = 10,
                    ProductName = "Ketçap",
                    CategoryID = 2,
                    Price = 3.5M,
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit."
                },
                new Product
                {
                    ProductID = 11,
                    ProductName = "Mayonez",
                    CategoryID = 2,
                    Price = 3.5M,
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit."
                },
                new Product
                {
                    ProductID = 12,
                    ProductName = "Turşu",
                    CategoryID = 3,
                    Price = 7,
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit."
                });
        }
    }
}

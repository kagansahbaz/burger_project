
using HomeMade_Burger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeMade_Burger.Context.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryID);
            builder.Property(x => x.CategoryName).IsRequired();

            builder.HasData(
                new Category { CategoryID = 1, CategoryName = "Burger Menu" },
                new Category { CategoryID = 2, CategoryName = "Sos" },
                new Category { CategoryID = 3, CategoryName = "Ekstra" }
                );
        }
    }
}

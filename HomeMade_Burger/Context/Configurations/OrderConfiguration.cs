using HomeMade_Burger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeMade_Burger.Context.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderID);

            // User - Order Relation Relation
            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserID);

        }
    }
}

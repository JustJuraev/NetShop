using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetShop.Models.Configuration
{
    public class OrderBasketConfiguration : IEntityTypeConfiguration<OrderBasket>
    {
        public void Configure(EntityTypeBuilder<OrderBasket> builder)
        {
            builder.ToTable("OrderItems").HasIndex(x => x.Id);
            builder.HasIndex(b => b.Id).IsUnique();
            builder.Property(b => b.ProductName).IsRequired();
            builder.Property(b => b.ProductCount).IsRequired();
            builder.Property(b => b.OrderId).IsRequired();
            builder.Property(b => b.ProductId).IsRequired();
            builder.Property(b => b.Price).IsRequired();
        }
    }
}

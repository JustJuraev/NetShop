using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetShop.Models.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders").HasIndex(x => x.Id);
            builder.HasIndex(b => b.Id).IsUnique(); 
            builder.Property(b => b.Address).IsRequired();
            builder.Property(b => b.Number).IsRequired();
            builder.Property(b => b.Delivery).IsRequired();
            builder.Property(b => b.Date).IsRequired();
        }
    }
}

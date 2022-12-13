using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetShop.Models.Configuration
{
    public class ProductPtopertyConfiguration : IEntityTypeConfiguration<ProductProperty>
    {
        public void Configure(EntityTypeBuilder<ProductProperty> builder)
        {
            builder.ToTable("ProductProperties").HasKey(b => b.Id);
            builder.HasIndex(b => b.Id).IsUnique();
            builder.Property(b => b.PropertyId).IsRequired();
            builder.Property(b => b.ProductId).IsRequired();
            builder.Property(b => b.Value).IsRequired();
        }
    }
}

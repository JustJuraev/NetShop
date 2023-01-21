using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace NetShop.Models.Configuration
{
    public class ProductAddressConfiguration : IEntityTypeConfiguration<ProductAddress>
    {
        public void Configure(EntityTypeBuilder<ProductAddress> builder)
        {
            builder.ToTable("ProductAddresses").HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.RegionId).IsRequired();
            //builder.HasMany(x => x.Products)
            //    .WithMany(x => x.ProductAddresses);
        }
    }
}

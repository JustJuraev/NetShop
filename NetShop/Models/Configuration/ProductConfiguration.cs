using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetShop.Models.Configuration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Products").HasKey(b => b.Id);
			builder.HasIndex(b => b.Id).IsUnique();
			builder.Property(b => b.Name).IsRequired();
			builder.Property(b => b.Price).IsRequired();
			builder.Property(b => b.ShortDesc).IsRequired();
			builder.Property(b => b.LongDesc).IsRequired();
			builder.Property(b => b.Image).IsRequired();
			builder.Property(b => b.CategoryId);
			builder.Property(b => b.Count);
			builder.HasOne(b => b.Category)
			  .WithMany(b => b.Products); 
        }
	}
}

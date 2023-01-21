using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace NetShop.Models
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Property> Properties { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<ProductProperty> ProductProperties { get; set; }

		public DbSet<ProductAddress> ProductAddresses { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<Region> Regions { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
	}
}

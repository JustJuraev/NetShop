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

		public DbSet<Log> Logs { get; set; }

		public DbSet<Cheque> Cheques { get; set; }

		public DbSet<ChequeItem> ChequeItems { get; set; }

		public DbSet<Stock> Stocks { get; set; }

		public DbSet<ProductLanguage> ProductLanguages { get; set; }

		public DbSet<CategoryLanguage> CategoryLanguages { get; set; }

		public DbSet<PropertyLanguage> PropertyLanguages { get; set; }

		public DbSet<OrderBasket> OrderItems { get; set; }

		//TODO: Сделать миграцию

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<ProductLanguage>().HasKey(m => new { m.ProductId, m.Language });
			modelBuilder.Entity<CategoryLanguage>().HasKey(m => new {m.CategoryId, m.Language});
			modelBuilder.Entity<PropertyLanguage>().HasKey(m => new {m.PropertyId, m.Language});
		}
	}
}

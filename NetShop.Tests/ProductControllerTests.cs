using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetShop.Controllers;
using NetShop.Models;
using NetShop.Repository.Repository;
using NetShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetShop.Tests
{
    public class ProductControllerTests
    {
        private IConfiguration _configuration;

        public ProductControllerTests()
        {

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _configuration = configurationBuilder;
        }

        [Fact]
        public void CheckIfIndexNotNull()
        {
            var connectionString = "server=localhost;port=5432;Database=newshop;UserId=postgres;Password=123456;";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(connectionString);

            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                //Arrange
                //Подключаем Repository
                var repository = new ProductRepository(context);
                var productPropertyRepository = new ProductPropertyRepository(context);
                var categoryRepository = new CategoryRepository(context);
                var userRepository = new UserRepository(context);
                var productAddressRepository = new ProductAddressRepository(context);

                //Подключаем Service
                var productService = new ProductService(repository);
                var productPropertyService = new ProductPropertyService(productPropertyRepository);
                var categoryService = new CategoryService(categoryRepository);
                var productAddressService = new ProductAddressService(productAddressRepository);

                //Подключаем Unit-Тесты
                var controller = new ProductController(productService, productPropertyService, categoryService, userRepository, productAddressService);

                //Act
                var result = controller.Index("", "", "ru-RU");

                //Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<Product>>(viewResult.Model);
                Assert.True(model.Count > 0);
            }
        }

        [Fact]
        public void CheckIfGetByCategoryNotNull()
        {
            var connectionString = "server=localhost;port=5432;Database=newshop;UserId=postgres;Password=123456;";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(connectionString);

            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                //Arrange
                //Подключаем Repository
                var repository = new ProductRepository(context);
                var productPropertyRepository = new ProductPropertyRepository(context);
                var categoryRepository = new CategoryRepository(context);
                var userRepository = new UserRepository(context);
                var productAddressRepository = new ProductAddressRepository(context);

                //Подключаем Service
                var productService = new ProductService(repository);
                var productPropertyService = new ProductPropertyService(productPropertyRepository);
                var categoryService = new CategoryService(categoryRepository);
                var productAddressService = new ProductAddressService(productAddressRepository);

                //Подключаем Unit-Тесты
                var controller = new ProductController(productService, productPropertyService, categoryService, userRepository, productAddressService);

                //Act
                var result = controller.GetByCategory(1, 0, 0, new List<Filters>());

                //Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<ProductFilterModel>(viewResult.Model);
                Assert.True(model.Products.Count > 0);
            }
        }

        [Fact]
        public void CheckIfGetProductNotNull()
        {
            var connectionString = "server=localhost;port=5432;Database=newshop;UserId=postgres;Password=123456;";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(connectionString);

            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                //Arrange
                //Подключаем Repository
                var repository = new ProductRepository(context);
                var productPropertyRepository = new ProductPropertyRepository(context);
                var categoryRepository = new CategoryRepository(context);
                var userRepository = new UserRepository(context);
                var productAddressRepository = new ProductAddressRepository(context);

                //Подключаем Service
                var productService = new ProductService(repository);
                var productPropertyService = new ProductPropertyService(productPropertyRepository);
                var categoryService = new CategoryService(categoryRepository);
                var productAddressService = new ProductAddressService(productAddressRepository);

                //Подключаем Unit-Тесты
                var controller = new ProductController(productService, productPropertyService, categoryService, userRepository, productAddressService);

                //Act
                var result = controller.GetProduct(1);

                //Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<Product>(viewResult.Model);
                Assert.NotNull(model);
            }
        }
    }
}

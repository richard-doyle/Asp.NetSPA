namespace SportsStore.Data.Test.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Moq;
    using SportsStore.Data.Context;
    using SportsStore.Data.Entities;
    using SportsStore.Data.Repositories;

    using Xunit;

    public class ProductRepositoryTests
    {
        [Fact]
        public void ProductRepositoryGetProductsReturnsProductsFromContext()
        {
            // Arrange
            var products = new List<Product>
                               {
                                   new Product { Id = 1 }, new Product { Id = 2 }, new Product { Id = 3 }
                               }.AsQueryable();

            var mockSet = new Mock<IDbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<SportsStoreContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            var productRepository = new ProductRepository(mockContext.Object);

            // Act
            var result = productRepository.GetProducts().ToList();

            // Assert
            Assert.Equal(3, result.Count());
            Assert.Equal(1, result.ElementAt(0).Id);
            Assert.Equal(2, result.ElementAt(1).Id);
            Assert.Equal(3, result.ElementAt(2).Id);
        }

        [Fact]
        public void ProductRepositoryAddProductAddsProductToContext()
        {
            // Arrange
            var mockSet = new Mock<IDbSet<Product>>();
            var mockContext = new Mock<SportsStoreContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            var productRepository = new ProductRepository(mockContext.Object);
            var product = new Product { Name = "Product" };

            // Act
            productRepository.AddProduct(product);

            // Assert
            mockSet.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
        }

        [Fact]
        public void ProductRepositoryAddProductSavesContext()
        {
            // Arrange
            var mockSet = new Mock<IDbSet<Product>>();
            var mockContext = new Mock<SportsStoreContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            var productRepository = new ProductRepository(mockContext.Object);
            var product = new Product { Name = "Product" };

            // Act
            productRepository.AddProduct(product);

            // Assert
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void ProductRepositoryAddProductReturnsAddedItem()
        {
            // Arrange
            var mockSet = new Mock<IDbSet<Product>>();
            var mockContext = new Mock<SportsStoreContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            var productRepository = new ProductRepository(mockContext.Object);
            var product = new Product { Name = "Product" };

            // Act
            var result = productRepository.AddProduct(product);

            // Assert
            Assert.Equal("Product", result.Name);
        }
    }
}

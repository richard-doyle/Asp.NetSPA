﻿namespace SportsStore.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using SportsStore.Data.Context;
    using SportsStore.Data.Entities;

    public class ProductRepository : IProductRepository
    {
        private readonly SportsStoreContext context;

        public ProductRepository(SportsStoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.context.Products.ToList();
        }

        public Product AddProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();

            return product;
        }

        public void RemoveProduct(int productId)
        {
            var product = this.context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return;
            }

            this.context.Products.Remove(product);
            this.context.SaveChanges();
        }
    }
}

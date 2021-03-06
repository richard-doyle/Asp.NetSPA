﻿namespace SportsStore.Data.Repositories
{
    using System.Collections.Generic;

    using SportsStore.Data.Entities;

    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product AddProduct(Product product);

        void RemoveProduct(int productId);
    }
}

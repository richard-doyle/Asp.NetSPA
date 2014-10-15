namespace SportsStore.Data.Repositories
{
    using System.Collections.Generic;

    using SportsStore.Data.Entities;

    public interface IProductsRepository
    {
        IEnumerable<Product> GetProducts();
    }
}

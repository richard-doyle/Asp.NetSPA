namespace SportsStore.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using SportsStore.Data.Context;
    using SportsStore.Data.Entities;

    public class ProductsRepository : IProductsRepository
    {
        private readonly SportsStoreContext context = new SportsStoreContext();

        public IEnumerable<Product> GetProducts()
        {
            return this.context.Products.AsEnumerable();
        }
    }
}

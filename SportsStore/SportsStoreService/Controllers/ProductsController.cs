namespace SportsStoreService.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using SportsStore.Domain.Models;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            var products = new List<Product>
            {
                new Product { Name = "Football", Price = 5.0 },
                new Product { Name = "Tennis Raquet", Price = 24.99 },
                new Product { Name = "Golf Clubs", Price = 248.75 }
            };
            return this.Ok(products);
        }
    }
}

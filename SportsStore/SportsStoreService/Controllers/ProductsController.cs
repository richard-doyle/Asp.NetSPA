namespace SportsStoreService.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using SportsStore.Data.Repositories;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private readonly IProductsRepository productsRepository = new ProductsRepository();

        public IHttpActionResult GetAll()
        {
            return this.Ok(this.productsRepository.GetProducts());
        }
    }
}

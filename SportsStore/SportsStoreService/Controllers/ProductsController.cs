namespace SportsStoreService.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using SportsStore.Data.Repositories;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IHttpActionResult GetAll()
        {
            return this.Ok(this.productRepository.GetProducts());
        }
    }
}

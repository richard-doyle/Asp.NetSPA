namespace SportsStoreService.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using SportsStore.Data.Entities;
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

        public IHttpActionResult Post([FromBody] Product product)
        {
            return this.Ok(this.productRepository.AddProduct(product));
        }
    }
}

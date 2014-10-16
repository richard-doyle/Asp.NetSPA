namespace SportsStoreService.Controllers
{
    using System.Web.Http;

    using SportsStore.Data.Entities;
    using SportsStore.Data.Repositories;

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

        public IHttpActionResult Delete(int id)
        {
            this.productRepository.RemoveProduct(id);
            return this.Ok();
        }
    }
}

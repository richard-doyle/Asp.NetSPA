namespace SportsStoreService.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using SportsStore.Data.Context;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private readonly SportsStoreContext db = new SportsStoreContext();

        public IHttpActionResult GetAll()
        {
            return this.Ok(this.db.Products.ToList());
        }
    }
}

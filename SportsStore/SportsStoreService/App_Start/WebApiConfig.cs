namespace SportsStoreService
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Microsoft.Practices.Unity;

    using Newtonsoft.Json.Serialization;

    using SportsStore.Data.Repositories;

    using SportsStoreService.DependencyResolution;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}

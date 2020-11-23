using System.Web.Http;
using System.Net.Http.Headers;
using Unity;
using ContactManagementApi.Models;
using ContactManagementApi.Interfaces;
using ContactManagementApi.Repositories;
using ContactManagementApi.Filters;
using System.Web.Http.Cors;

namespace ContactManagementApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new ContactExceptionFilter());

            var container = new UnityContainer();
            container.RegisterType<IContactRepository, ContactInfoRepository>();
            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}

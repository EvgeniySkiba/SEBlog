using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;
using SeBlog.Core;
using SeBlog.Core.Concrete;
using SeBlog.Core.Objects;
using SeBlog.Web.Providers;

namespace SeBlog.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(new RepositoryModule());
            kernel.Bind<IBlogRepository>().To<BlogRepository>();
          
            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
          
            base.OnApplicationStarted();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

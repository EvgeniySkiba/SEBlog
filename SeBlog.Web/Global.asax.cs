using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;
using SeBlog.Core;
using SeBlog.Core.Concrete;
using SeBlog.Core.Objects;
using SeBlog.Web.Providers;
using System.Web.Optimization;
using SeBlog.Web.App_Start;

namespace SeBlog.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(new RepositoryModule());
            kernel.Bind<IBlogRepository>().To<BlogRepository>();
            kernel.Bind<IAuthProvider>().To<AuthProvider>();

            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Post), new PostModelBinder(Kernel));

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            base.OnApplicationStarted();
        }

       
    }
}

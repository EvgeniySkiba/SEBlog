using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SeBlog.Web;

namespace SeBlog.Core
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("IdentityDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}

using Antlr.Runtime.Misc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using TPV.Models;

namespace TPV.Infrastructure
{
    public class AppRoleManager : RoleManager<Rol>
    {
        public AppRoleManager(IRoleStore<Rol, string> store) : base(store)
        {
        }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            return new AppRoleManager(new RoleStore<Rol>(context.Get<LyraContext>()));
        }

        public Func<string, Rol> FindById { get; set; }

    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using TPV.Models;

namespace TPV.Infrastructure
{
    public class AppUserManager : UserManager<Usuario>
    {
        public AppUserManager(IUserStore<Usuario> store) : base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            LyraContext db = context.Get<LyraContext>();
            AppUserManager manager = new AppUserManager(new UserStore<Usuario>(db));

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true
            };
            return manager;
        }
    }
}
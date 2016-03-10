using System;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using TPV.Models.Repositories;

namespace TPV.Security
{
    public class ProveedorRoles : RoleProvider
    {
        private UsuarioRepositorio _UsuarioRepositorio = new UsuarioRepositorio();

        private int _CacheTimeOutInMinutos = 20;

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }

            var cachekey = string.Format("{0}_role", username);
            if (HttpRuntime.Cache[cachekey] != null)
            {
                return (string[])HttpRuntime.Cache[cachekey];
            }

            string[] roles = new string[] { };

            roles = _UsuarioRepositorio.UserInRoles(username); 

            if (roles.Count() > 0)
            {
                HttpRuntime.Cache.Insert(cachekey, roles, null, DateTime.Now.AddMinutes(_CacheTimeOutInMinutos), Cache.NoSlidingExpiration);
            }

            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var userRoles = GetRolesForUser(username);

            return userRoles.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
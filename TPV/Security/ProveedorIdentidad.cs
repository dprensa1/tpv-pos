using System;
using System.Security.Principal;

namespace TPV.Security
{
    public class ProveedorIdentidad : IIdentity
    {
        public IIdentity Identity { get; set; }
        public string Usuario { get; set; }

        public string AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return Identity.IsAuthenticated; }
        }

        public string Name
        {
            get { return String.Format("{0}", Usuario); }
        }

        public ProveedorIdentidad (IIdentity identity)
        {
            Identity = identity;
            Usuario = Identity.Name;
        }
    }
}
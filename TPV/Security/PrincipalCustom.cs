using System;
using System.Security.Principal;

namespace TPV.Security
{
    public class PrincipalCustom : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public PrincipalCustom(ProveedorIdentidad identity)
        {
            Identity = identity;
        }
    }
}
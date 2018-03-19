using AuthBehavior.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthBehavior.Behaviors
{
    public class ClientAuthenticationHeaderContext
    {
        public static AuthenticationData HeaderInformation;

        static ClientAuthenticationHeaderContext()
        {
            HeaderInformation = new AuthenticationData();
        }
    }
}

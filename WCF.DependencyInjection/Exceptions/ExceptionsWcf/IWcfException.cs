using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.ExceptionsWcf
{
    // Interface devant être implémentée par les classes d'exception qui doivent être traduites en exception Wcf
    public interface IWcfException
    {
        System.ServiceModel.Channels.Message TraduireEnFault(System.ServiceModel.Channels.MessageVersion version);
    }
}

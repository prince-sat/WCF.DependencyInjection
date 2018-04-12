using Core.Common.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.ExceptionsWcf
{
    /// <summary>
    /// Erreur SOAP lors de la demande d'accès à un Blog inexistant.
    /// </summary>

    [DataContract(Name = "DemandeInexistanteFault", Namespace = ConstantesTransverse.URI_WEB_SERVICE)]
    public class BlogInexistantFault : AbstractFault
    {
    }
}

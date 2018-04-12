
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
    /// Abstraction de toutes les Fault WCF.
    /// </summary>
    [DataContract(Name = "AbstractFault", Namespace = ConstantesTransverse.URI_WEB_SERVICE)]
    public abstract class AbstractFault
    {
        /// <summary>
        /// Code
        /// </summary>
        [DataMember(IsRequired = true, Name = "Code")]
        public int Code { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [DataMember(IsRequired = true, Name = "Message")]
        public string Message { get; set; }

        /// <summary>
        /// Pile
        /// </summary>
        [DataMember(IsRequired = true, Name = "StackTrace")]
        public string StackTrace { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        [DataMember(IsRequired = true, Name = "UtcDateException")]
        public DateTime UtcDateException { get; set; }
    }
}

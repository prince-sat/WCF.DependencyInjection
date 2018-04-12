using Core.Common.Constantes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.ExceptionsWcf
{
    /// <summary>
    /// Erreur SOAP lors d'une erreur inconnue.
    /// </summary>
    [DataContract(Name = "ErreurTechniqueFault", Namespace = ConstantesTransverse.URI_WEB_SERVICE)]
    public class ErreurInconnueFault
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

        /// <summary>
        /// Récupération du message Fault de l'erreur inconnue.
        /// </summary>
        /// <param name="version">Version SOAP du message</param>
        /// <returns>Message d'erreur Wcf</returns>
        public static Message RecupererMessage(MessageVersion version)
        {
            Object vDetails = new ErreurInconnueFault()
            {
                Message = "Erreur inconnue",
                UtcDateException = DateTime.Now,
                Code = ConstantesCodesErreurs.CODE_ERR_INCONNUE
            };

            FaultCode vFaultCode = null;

            if (version.Envelope == EnvelopeVersion.Soap11)
            {
                // soap 1.1
                vFaultCode = new FaultCode("Server");
            }
            else if (version.Envelope == EnvelopeVersion.Soap12)
            {
                vFaultCode = FaultCode.CreateReceiverFaultCode("", "");
            }

            MessageFault vMessageFault = MessageFault.CreateFault(
                vFaultCode,
                new FaultReason("Erreur inconnue"),
                vDetails);

            return System.ServiceModel.Channels.Message.CreateMessage(version, vMessageFault, "failAction");
        }
    }
}

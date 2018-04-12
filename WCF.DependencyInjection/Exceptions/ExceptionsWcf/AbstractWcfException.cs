using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Exceptions.Exceptions;

namespace Exceptions.ExceptionsWcf
{
    /// <summary>
    /// Exception mère de toutes les exceptions métiers  WCF.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly"), Serializable]
    public abstract class AbstractWcfException : BusinessException, IWcfException
    {
        #region Propriétés

        /// <summary>
        /// Code erreur.
        /// </summary>
        public Int32 CodeErreur { get; set; }

        /// <summary>
        /// Détail de l'exception.
        /// </summary>
        public abstract AbstractFault Detail { get; }

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur.
        /// </summary>
        protected AbstractWcfException()
        {
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="message"></param>
        protected AbstractWcfException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        protected AbstractWcfException(String message, Exception ex)
            : base(message, ex)
        {
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="ex"></param>
        protected AbstractWcfException(Exception ex)
            : base(ex.Message)
        {
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected AbstractWcfException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Convertion de l'exception fonctionnelle en "Fault" Wcf.
        /// </summary>
        /// <param name="version">Version SOAP du message</param>
        /// <returns>Message d'erreur Wcf</returns>
        public Message TraduireEnFault(MessageVersion version)
        {
            // FaultCode
            FaultCode vFaultCode = null;

            if (version.Envelope == EnvelopeVersion.Soap11)
            {
                vFaultCode = new FaultCode("Server");
            }
            else if (version.Envelope == EnvelopeVersion.Soap12)
            {
                vFaultCode = FaultCode.CreateReceiverFaultCode(this.TargetSite.ToString(), "");
            }

            // Instanciation du message
            MessageFault vMessageFault = MessageFault.CreateFault(vFaultCode, new FaultReason(this.Message), this.Detail);

            return System.ServiceModel.Channels.Message.CreateMessage(version, vMessageFault, "failAction");
        }

        #endregion
    }
}

using Exceptions.ExceptionsWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Extensions
{
    public static class Exception
    {
        /// <summary>
        /// Variable permettant de positionner des traces au sein de la classe.
        /// </summary>
        // private static readonly ILog log = LogManager.GetLogger(typeof(Exception));

        /// <summary>
        /// Méthode permettant de convertir une exception en exception Wcf
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="version">Version SOAP du message</param>
        /// <returns>Message d'erreur Wcf</returns>
        public static System.ServiceModel.Channels.Message TraduireEnFault(this System.Exception exception, System.ServiceModel.Channels.MessageVersion version)
        {
           
                // log.Error("Une exception non prévue a été levée.", exception);
                //erreurSoap = exception.TraduireEnFault(version);

                string message = exception.InnerException != null && exception.InnerException.GetType() == typeof(SerializationException) ?
                                                        exception.InnerException.Message : exception.Message;

                Object vDetails = new ErreurInconnueFault
                {
                    Message = message,
                    UtcDateException = DateTime.Now,
                    Code = 7000
                };

                FaultCode vFaultCode = null;

                if (version.Envelope == EnvelopeVersion.Soap11)
                {
                    // soap 1.1
                    vFaultCode = new FaultCode("Server");
                }
                else if (version.Envelope == EnvelopeVersion.Soap12)
                {
                    vFaultCode = FaultCode.CreateReceiverFaultCode(exception.TargetSite.ToString(), "");
                }

                MessageFault vMessageFault = MessageFault.CreateFault(vFaultCode, new FaultReason(message), vDetails);

                return Message.CreateMessage(version, vMessageFault, "failAction");

          

            
        }
    }
}

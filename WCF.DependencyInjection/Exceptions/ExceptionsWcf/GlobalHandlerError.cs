using Exceptions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exceptions.ExceptionsWcf
{
    /// <summary>
    /// Gère la traduction des exceptions de service en erreur soap.
    /// </summary>
    class GlobalHandlerError : IErrorHandler
    {
        /// <summary>
        /// Variable permettant de positionner des traces au sein de la classe.
        /// </summary>
       // private static readonly ILog log = LogManager.GetLogger(typeof(GlobalHandleError));

        #region IErrorHandler Membres

        /// <summary>
        /// Indique si une exception est gérée par cette classe.
        /// </summary>
        /// <param name="exception">exception à gérer</param>
        /// <returns>true si l'exception est gérée</returns>
        public bool HandleError(System.Exception exception)
        {
            return true;
        }

        /// <summary>
        /// Construit l'erreur soap à partir de l'exception.
        /// </summary>
        /// <param name="exception">exception</param>
        /// <param name="version">version du message soap</param>
        /// <param name="erreurSoap">erreur soap</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        public void ProvideFault(System.Exception exception,
            System.ServiceModel.Channels.MessageVersion version,
            ref System.ServiceModel.Channels.Message erreurSoap)
        {
            // Si l'exception implémente IWcfException, on appelle la méthode TraduireEnFault
            if (exception is IWcfException)
            {
                // log.Warn("Une exception fonctionnelle a été levée.", exception);
                erreurSoap = ((IWcfException)exception).TraduireEnFault(version);
            }
            // Pour les autres exceptions, alors on appelle la méthode d'extension
            else
            {
                // log.Error("Une exception non prévue a été levée.", exception);
                //erreurSoap = exception.TraduireEnFault(version);

                erreurSoap = exception.TraduireEnFault(version);

            }
        }

        #endregion
    }
}

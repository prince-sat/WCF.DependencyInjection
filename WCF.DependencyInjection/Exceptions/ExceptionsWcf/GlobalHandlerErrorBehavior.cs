using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.ExceptionsWcf
{
    /// <summary>
    /// Attribut à utiliser sur les classes d'implémentation de service
    /// pour la gestion des exceptions
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class  GlobalHandlerErrorBehavior : Attribute, IServiceBehavior
    {

        #region IServiceBehavior Membres

        /// <summary>
        /// Construit le ou les gestionnaires d'exceptions
        /// </summary>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            if (serviceHostBase == null)
            {
                return;
            }

            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                dispatcher.ErrorHandlers.Add(new GlobalHandlerError());
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription,
            System.ServiceModel.ServiceHostBase serviceHostBase,
            System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
            System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceDescription serviceDescription,
            System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }

        #endregion
    }
}

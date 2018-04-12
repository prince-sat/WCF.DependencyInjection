using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Exceptions
{
    /// <summary>
    /// Exception mère de toutes les exceptions métiers 
    /// </summary>
    [Serializable]
    public class BusinessException : Exception
    {
        #region Propriété

        /// <summary>
        /// Code du message d'erreur
        /// </summary>
        public String CodeMessage { get; set; }

        /// <summary>
        /// Arguments du message d'erreur
        /// </summary>
        public IList<Object> ArgsMessage { get; set; }

        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        public BusinessException()
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="message"></param>
        public BusinessException(String message) : base(message)
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public BusinessException(String message, Exception ex) : base(message, ex)
        {

        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="ex"></param>
        public BusinessException(Exception ex)
            : base(ex.Message)
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="message"></param>
        /// <param name="codeMessage">Code du message dans le fichier de ressource</param>
        /// <param name="argsMessage">Arguments du message du fichier de ressource</param>
        public BusinessException(String message, String codeMessage, IList<Object> argsMessage)
            : base(message)
        {
            this.CodeMessage = codeMessage;
            this.ArgsMessage = argsMessage;
        }

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Substition utile pour la règle FxCop CA2240
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}

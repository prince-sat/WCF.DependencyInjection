using Core.Common.Constantes;
using Exceptions.ExceptionsWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Exceptions
{
    /// <summary>
    /// Exception fonctionnelle lancée quand un blog est inexistant.
    /// </summary>
    [Serializable]
    public class BlogInexistantException : AbstractWcfException
    {
        #region Propriétés

        /// <summary>
        /// Détail.
        /// </summary>
        public override AbstractFault Detail
        {
            get
            {
                return new BlogInexistantFault()
                {
                    Code = ConstantesCodesErreurs.CODE_ERR_CONS_DEM_BLOG_INEXISTANT,
                    Message = this.Message,
                    UtcDateException = DateTime.Now
                };
            }
        }

        #endregion


        #region Constructeurs

        /// <summary>
        /// Constructeur.
        /// </summary>
        public BlogInexistantException()
        {
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="message">Message</param>
        public BlogInexistantException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exp">Exception mère</param>
        public BlogInexistantException(String message, Exception exp)
            : base(message, exp)
        {
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="info">Infos de sérialisation</param>
        /// <param name="context">Contexte</param>
        protected BlogInexistantException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion


    }
}

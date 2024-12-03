using System;
#if (!SILVERLIGHT)
using System.Runtime.Serialization;

#endif

namespace Obfuscar
{
    /// <summary>
    /// Obfuscar exception.
    /// </summary>
    [Serializable]
    public class ObfuscarException : Exception
    {
        /// <summary>
        /// Message code.
        /// </summary>
        public string MessageCode { get; private set; }

        /// <summary>
        /// Creates a <see cref="ObfuscarException"/>.
        /// </summary>
        public ObfuscarException()
        {
            this.MessageCode = MessageCodes.ofr001;
        }

        /// <summary>
        /// Creates a <see cref="ObfuscarException"/> instance with a specific <see cref="string"/>.
        /// </summary>
        /// <param name="messageCode">Code.</param>
        /// <param name="message">Message</param>
        public ObfuscarException(string messageCode, string message) : base(message)
        {
            this.MessageCode = messageCode;
        }

        /// <summary>
        /// Creates a <see cref="ObfuscarException"/> instance with a specific <see cref="string"/> and an <see cref="Exception"/>.
        /// </summary>
        /// <param name="messageCode">The message code.</param>
        /// <param name="message">Message</param>
        /// <param name="inner">Inner exception</param>
        public ObfuscarException(string messageCode, string message, Exception inner): base(message, inner)
        {
            this.MessageCode = messageCode;
        }

#if !CF
        /// <summary>
        /// Creates a <see cref="ObfuscarException"/> instance.
        /// </summary>
        /// <param name="info">Info</param>
        /// <param name="context">Context</param>
        [Obsolete]
        protected ObfuscarException(SerializationInfo info, StreamingContext context): base(info, context)
        {
            this.MessageCode = MessageCodes.ofr022;
        }
#endif
    }
}

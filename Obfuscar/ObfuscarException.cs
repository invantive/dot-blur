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
        /// Hint.
        /// </summary>
        public string? Hint { get; private set; }

        /// <summary>
        /// Creates a <see cref="ObfuscarException"/>.
        /// </summary>
        public ObfuscarException()
        {
            this.MessageCode = MessageCodes.dbr001;
            this.Hint = null;
        }

        /// <summary>
        /// Creates a <see cref="ObfuscarException"/> instance with a specific <see cref="string"/> and an <see cref="Exception"/>.
        /// </summary>
        /// <param name="messageCode">The message code.</param>
        /// <param name="message">Message.</param>
        /// <param name="hint">Hint.</param>
        /// <param name="innerException">Inner exception</param>
        public ObfuscarException(string messageCode, string message, string? hint = null, Exception? innerException = null): base(message, innerException)
        {
            this.MessageCode = messageCode;
            this.Hint = hint;
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
            this.MessageCode = MessageCodes.dbr022;
        }
#endif
    }
}

using System;
using System.Runtime.Serialization;

namespace Dffrnt.Envelopes
{
    [Serializable]
    public class EnvelopeException : Exception
    {
        public EnvelopeException()
        {
        }

        public EnvelopeException(string message) : base(message)
        {
        }

        public EnvelopeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EnvelopeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

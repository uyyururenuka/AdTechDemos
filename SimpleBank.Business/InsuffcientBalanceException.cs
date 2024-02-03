using System.Runtime.Serialization;

namespace SimpleBank.Business
{
    [Serializable]
    public class InsuffcientBalanceException : ApplicationException
    {
        public InsuffcientBalanceException()
        {
        }

        public InsuffcientBalanceException(string message) : base(message)
        {
        }

        public InsuffcientBalanceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsuffcientBalanceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
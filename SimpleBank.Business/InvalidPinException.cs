﻿using System.Runtime.Serialization;

namespace SimpleBank.Business
{
    [Serializable]
    public class InvalidPinException : ApplicationException
    {
        public InvalidPinException()
        {
        }

        public InvalidPinException(string? message) : base(message)
        {
        }

        public InvalidPinException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidPinException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
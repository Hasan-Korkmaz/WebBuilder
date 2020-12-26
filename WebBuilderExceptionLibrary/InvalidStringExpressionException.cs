using System;

namespace WebBuilderExceptionLibrary
{
    /// <summary>
    /// The exception that is thrown when attempt to do operations with unsupported string by process.
    /// </summary>
    public class InvalidStringExpressionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.InvalidStringExpressionException</c> class.
        /// </summary>
        public InvalidStringExpressionException()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.InvalidStringExpressionException</c> class
        /// with a specified error message.
        /// </summary>
        /// <param name="customMessage"></param>
        public InvalidStringExpressionException(string customMessage) : base(customMessage)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.InvalidStringExpressionException</c> class
        /// with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="customMessage"></param>
        /// <param name="innerException"></param>
        public InvalidStringExpressionException(string customMessage, Exception innerException) : base(customMessage, innerException)
        {
        }
    }
}

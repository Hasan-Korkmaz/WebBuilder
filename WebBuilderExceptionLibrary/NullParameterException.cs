using System;

namespace WebBuilderExceptionLibrary
{
    /// <summary>
    /// The exception that is thrown when attempt to do operation with null objects.
    /// </summary>
    public class NullParameterException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.NullParameterException</c> class.
        /// </summary>
        public NullParameterException()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.NullParameterException</c> class
        /// with a specified error message.
        /// </summary>
        /// <param name="customMessage"></param>
        public NullParameterException(string customMessage) : base(customMessage)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.NullParameterException</c> class
        /// with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="customMessage"></param>
        /// <param name="innerException"></param>
        public NullParameterException(string customMessage, Exception innerException) : base(customMessage, innerException)
        {

        }
    }
}

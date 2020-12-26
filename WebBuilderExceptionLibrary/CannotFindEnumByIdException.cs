using System;

namespace WebBuilderExceptionLibrary
{
    /// <summary>
    /// The exception that is thrown when attempt to get enum by invalid id.
    /// </summary>
    public class CannotFindEnumByIdException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.CannotFindEnumByIdException</c> class.
        /// </summary>
        public CannotFindEnumByIdException()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.CannotFindEnumByIdException</c> class
        /// with not found enum id in enum process. The spesific message of base class uses this invalid id when does not send a specific message.
        /// </summary>
        /// <param name="enumId"></param>
        public CannotFindEnumByIdException(int enumId) : base($"{enumId} idsine sahip enum yok.")
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.CannotFindEnumByIdException</c> class
        /// with a specified error message.
        /// </summary>
        /// <param name="customMessage"></param>
        public CannotFindEnumByIdException(string cutomMessage) : base(cutomMessage)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.CannotFindEnumByIdException</c> class
        /// with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="customMessage"></param>
        /// <param name="innerException"></param>
        public CannotFindEnumByIdException(string cutomMessage, Exception innerException) : base(cutomMessage, innerException)
        {
        }
    }
}

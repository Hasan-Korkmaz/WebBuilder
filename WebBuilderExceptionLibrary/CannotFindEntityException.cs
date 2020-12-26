using System;

namespace WebBuilderExceptionLibrary
{
    /// <summary>
    /// The exception that is thrown when attempt to search for an entity not found in the Repository.
    /// </summary>
    public class CannotFindEntityException:Exception
    {
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.CannotFindEntityException</c> class with defined default message by constructor.
        /// </summary>
        public CannotFindEntityException() : base($"Hiçbir entity bulunamadi.")
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.CannotFindEntityException</c> class
        /// with an entity id not found in the Repository. The spesific message of base class uses this invalid id when does not send a specific message.
        /// </summary>
        /// <param name="entityId"></param>
        public CannotFindEntityException(int entityId) : base($"{entityId} id'sine sahip entity bulunamadi.")
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.CannotFindEntityException</c> class
        /// with a specified error message.
        /// </summary>
        /// <param name="customMessage"></param>
        public CannotFindEntityException(string message) : base(message)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.CannotFindEntityException</c> class
        /// with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="customMessage"></param>
        /// <param name="innerException"></param>
        public CannotFindEntityException(string customMessage, Exception innerException) : base(customMessage,innerException)
        {

        }
    }
}

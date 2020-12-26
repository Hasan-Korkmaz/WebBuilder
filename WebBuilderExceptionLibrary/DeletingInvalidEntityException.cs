using System;

namespace WebBuilderExceptionLibrary
{
    /// <summary>
    /// The exception that is thrown when attempt to delete an entity that is not in the Repository.
    /// </summary>
    public class DeletingInvalidEntityException :Exception
    {
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.DeletingInvalidEntityException</c> class.
        /// </summary>
        public DeletingInvalidEntityException()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.DeletingInvalidEntityException</c> class
        /// with an entity id not found in the Repository. The spesific message of base class uses this invalid id when does not send a specific message.
        /// </summary>
        /// <param name="entityId"></param>
        public DeletingInvalidEntityException(int entityId) : base($"Entity silebilmek için entity'nin geçerli bir id'ye sahip olması gerekir. Entity Id:{entityId}")
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.DeletingInvalidEntityException</c> class
        /// with a specified error message.
        /// </summary>
        /// <param name="customMessage"></param>
        public DeletingInvalidEntityException(string customMessage) : base(customMessage)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.DeletingInvalidEntityException</c> class
        /// with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="customMessage"></param>
        /// <param name="innerException"></param>
        public DeletingInvalidEntityException(string customMessage, Exception innerException) : base(customMessage, innerException)
        {

        }
    }
}

using System;

namespace WebBuilderExceptionLibrary
{
    /// <summary>
    /// The exception that is thrown when attempt to update an entity that is not in the Repository.
    /// </summary>
    public class UpdatingInvalidEntityException:Exception
    {
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.UpdatingInvalidEntityException</c> class.
        /// </summary>
        public UpdatingInvalidEntityException()
        {
                
        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.UpdatingInvalidEntityException</c> class
        /// with an entity id not found in the Repository. The spesific message of base class uses this invalid id when does not send a specific message.
        /// </summary>
        /// <param name="entityId"></param>
        public UpdatingInvalidEntityException(int entityId): base($"Entity güncelleyebilmek için entity'nin geçerli bir id'ye sahip olması gerekir. Entity Id:{entityId}")
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.UpdatingInvalidEntityException</c> class
        /// with a specified error message.
        /// </summary>
        /// <param name="customMessage"></param>
        public UpdatingInvalidEntityException(string customMessage) : base(customMessage)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.UpdatingInvalidEntityException</c> class
        /// with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="customMessage"></param>
        /// <param name="innerException"></param>
        public UpdatingInvalidEntityException(string customMessage, Exception innerException) : base(customMessage, innerException)
        {

        }
    
    }
}

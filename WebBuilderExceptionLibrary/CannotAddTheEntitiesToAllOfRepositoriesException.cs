namespace WebBuilderExceptionLibrary
{
    using System;

    //CLK Hicbir yerde kullanilmamis. Adi da pek kullanilabilir gibi durmuyor. Silinebilir...
    /// <summary>
    /// The exception that is thrown when attempt to add entities to multiple repositories.
    /// </summary>
    public class CannotAddTheEntitiesToAllOfRepositoriesException :Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CannotAddTheEntitiesToAllOfRepositoriesException"/> class.
        /// </summary>
        /// <param name="customMessage">The customMessage<see cref="string"/>.</param>
        public CannotAddTheEntitiesToAllOfRepositoriesException(string customMessage) : base(customMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CannotAddTheEntitiesToAllOfRepositoriesException"/> class.
        /// </summary>
        public CannotAddTheEntitiesToAllOfRepositoriesException() : base("There was problem when add the entities to multiple repositories.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c cref="CannotAddTheEntitiesToAllOfRepositoriesException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        /// <param name="innerException">The innerException<see cref="Exception"/>.</param>
        public CannotAddTheEntitiesToAllOfRepositoriesException(string message, Exception innerException) : base("Message : " + $"{message}" + " Inner Exception : " + $"{innerException}")
        {
        }
    }
}

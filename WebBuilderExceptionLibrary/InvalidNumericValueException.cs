using System;

namespace WebBuilderExceptionLibrary
{
    /// <summary>
    /// The exception that is thrown when attempt to process invalid numeric value in the conditions of situation.
    /// </summary>
    public class InvalidNumericValueException:Exception
    {
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.InvalidNumericValueException</c> class.
        /// </summary>
        private InvalidNumericValueException()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.InvalidNumericValueException</c> class
        /// with invalid value. The spesific message of base class uses this invalid value when does not send a specific message.
        /// </summary>
        /// <param name="invalidValue"></param>
        public InvalidNumericValueException(decimal invalidValue):base("Girilen" +invalidValue.ToString("{0:0.##}")+"sayısal değeri bu işlem için geçersiz bir değer.")
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.InvalidNumericValueException</c> class
        /// with a specified error message.
        /// </summary>
        /// <param name="customMessage"></param>
        public InvalidNumericValueException(string customMessage):base(customMessage)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <c>ABKExceptionLibrary.InvalidNumericValueException</c> class
        /// with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="customMessage"></param>
        /// <param name="innerException"></param>
        public InvalidNumericValueException(string customMessage, Exception innerException):base(customMessage, innerException)
        {

        }
    }
}

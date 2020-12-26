using System;


namespace WebBuilderExceptionLibrary
{
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException()
        {

        }
        public InvalidParameterException(string message) : base("Message : " + message)
        {

        }
        public InvalidParameterException(string message, Exception innerException) : base("Message : " + $"{message}" + " Inner Exception : " + $"{innerException}")
        {

        }
    }
}

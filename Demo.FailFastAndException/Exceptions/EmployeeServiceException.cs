using System;

namespace Demo.FailFastAndException.Exceptions
{
    public class EmployeeServiceException : Exception
    {
        public EmployeeServiceException(string message) : base(message)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.Utilities.Exceptions
{
    public class ValidationTypeException : Exception
    {
        public ValidationTypeException(string message)
        {
            throw new Exception(message);
        }

        public ValidationTypeException()
        {
            throw new Exception();
        }
    }
}

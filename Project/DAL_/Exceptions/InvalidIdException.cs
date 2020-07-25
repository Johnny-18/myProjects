using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_.Exceptions
{
    public class InvalidIdException : ArgumentException
    {
        public InvalidIdException()
        {
        }

        public InvalidIdException(string message)
            : base(message)
        {
        }

        public InvalidIdException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

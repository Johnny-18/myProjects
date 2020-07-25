using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL_.Exceptions
{
    public class LikeException : Exception
    {
        public LikeException()
        {
        }

        public LikeException(string message)
            : base(message)
        {
        }

        public LikeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

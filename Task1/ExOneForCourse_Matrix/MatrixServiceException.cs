using System;

namespace ExOneForCourse_Matrix
{
    public class MatrixServiceException : Exception
    {
        public MatrixServiceException() { }
        public MatrixServiceException(string message) : base(message) { }
        public MatrixServiceException(string message, Exception inner) : base(message, inner) { }
    }
}

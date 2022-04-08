using System;

namespace WPF_Ex10
{
    public class InvalidOperationException : ApplicationException
    {
        public InvalidOperationException(string message) : base(message)
        {
        }
    }
}

using System;

namespace WPF_Ex7
{
    public class InvalidLineException : ApplicationException
    {
        public InvalidLineException(string msg) : base(msg)
        {
        }
    }
}

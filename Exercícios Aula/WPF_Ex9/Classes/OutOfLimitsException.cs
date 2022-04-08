using System;

namespace WPF_Ex9
{
    public class OutOfLimitsException : ApplicationException
    {
        public int Charge { get; private set; }

        public OutOfLimitsException(string msg, int charge) : base(msg)
        {
            Charge = charge;
        }
    }
}

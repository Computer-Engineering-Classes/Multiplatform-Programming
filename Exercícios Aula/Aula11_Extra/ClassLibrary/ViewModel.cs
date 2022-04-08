using System;

namespace ClassLibrary
{
    public delegate void MethodWithString(string str);

    public class ViewModel : BaseViewModel
    {
        public event MethodWithString ErrorEvent;

        private char _Sign;
        public char Sign
        {
            get => _Sign;
            set { _Sign = value; OnPropertyChanged(nameof(Sign)); }
        }

        private double _Value1;
        public double Value1
        {
            get => _Value1;
            set { _Value1 = value; OnPropertyChanged(nameof(Value1)); }
        }

        private double _Value2;
        public double Value2
        {
            get => _Value2;
            set { _Value2 = value; OnPropertyChanged(nameof(Value2)); }
        }

        private double _Result;
        public double Result
        {
            get => _Result;
            set { _Result = value; OnPropertyChanged(nameof(Result)); }
        }

        public void ChangeSign(object content)
        {
            Sign = Convert.ToChar(content);
        }

        public void Sqrt()
        {
            if (Result < 0)
            {
                ErrorEvent?.Invoke("O resultador tem de ser não negativo.");
            }
            else
            {
                Result = Math.Sqrt(Result);
            }
        }

        public void Inv()
        {
            if (Result == 0)
            {
                ErrorEvent?.Invoke("O resultado tem de ser diferente de 0.");
            }
            else
            {
                Result = 1 / Result;
            }
        }

        public void AddDigit(int v, object content)
        {
            switch(v)
            {
                case 1:
                    Value1 = Convert.ToDouble(Value1.ToString() + content);
                    break;
                case 2:
                    Value2 = Convert.ToDouble(Value2.ToString() + content);
                    break;
            }
        }

        public void Assign()
        {
            if (Value2 == 0 && Sign == '÷')
            {
                ErrorEvent?.Invoke("Valor 2 tem de ser diferente de 0.");
            }
            else
            {
                switch (Sign)
                {
                    case '+':
                        Result = Value1 + Value2;
                        break;
                    case '−':
                        Result = Value1 - Value2;
                        break;
                    case '×':
                        Result = Value1 * Value2;
                        break;
                    case '÷':
                        Result = Value1 / Value2;
                        break;
                    case '%':
                        Result = Value1 % Value2;
                        break;
                    default:
                        ErrorEvent?.Invoke("Selecione uma operação");
                        break;
                }
            }

        }

        public void Minus(int v)
        {
            switch (v)
            {
                case 1:
                    Value1 = -Value1;
                    break;
                case 2:
                    Value2 = -Value2;
                    break;
            }
        }

        public void Clean()
        {
            Value1 = 0;
            Value2 = 0;
            Result = 0;
        }
    }
}

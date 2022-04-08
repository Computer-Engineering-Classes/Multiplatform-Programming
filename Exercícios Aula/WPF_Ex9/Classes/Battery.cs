namespace WPF_Ex9
{
    public class Battery : IBattery
    {
        public int Capacity { get; set; }

        public int ChargeValue { get; set; }
        
        public event voidArgInt ChargeChanged;

        public Battery(int capacity)
        {
            Capacity = capacity;
            ChargeValue = 50;
        }

        public void Charge(int delta)
        {
            if ((ChargeValue + delta) > 100)
            {
                throw new OutOfLimitsException("A bateria não suporta essa carga!!!", ChargeValue);
            }
            ChargeValue += delta;
            ChargeChanged?.Invoke(ChargeValue);
        }

        public void Discharge(int delta)
        {
            if ((ChargeValue - delta) < 0)
            {
                throw new OutOfLimitsException("A bateria não suporta essa carga!!!", ChargeValue);
            }
            ChargeValue -= delta;
            ChargeChanged?.Invoke(ChargeValue);
        }
    }
}

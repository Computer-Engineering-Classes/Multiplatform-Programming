namespace WPF_Ex9
{
    public interface IBattery
    {
        int Capacity { get; set; }

        int ChargeValue { get; set; }

        event voidArgInt ChargeChanged;

        void Charge(int delta);

        void Discharge(int delta);
    }
}

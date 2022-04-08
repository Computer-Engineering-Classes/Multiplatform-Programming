namespace WPF_Ex9
{
    public class NewBattery : Battery, IBatteryWithTotal
    {
        public float TotalCharge { get; set; }

        public float TotalDischarge { get; set; }

        public event voidArgFloat TotalsChanged;

        public NewBattery(int capacity) : base(capacity)
        {
            TotalCharge = 0;
        }

        public new void Charge(int delta)
        {
            base.Charge(delta);
            TotalCharge += Capacity * ((float)delta / 100);
            TotalsChanged?.Invoke(TotalCharge, TotalDischarge);
        }

        public new void Discharge(int delta)
        {
            base.Discharge(delta);
            TotalDischarge += Capacity * ((float)delta / 100);
            TotalsChanged?.Invoke(TotalCharge, TotalDischarge);
        }
    }
}

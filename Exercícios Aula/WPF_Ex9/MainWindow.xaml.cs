using System.Windows;

namespace WPF_Ex9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly App app;

        public MainWindow()
        {
            InitializeComponent();
            app = Application.Current as App;
            app.Battery.ChargeChanged += ChargeChanged;
            app.Battery.TotalsChanged += TotalChanged;
            pbBateria.Value = app.Battery.ChargeValue;
            Title = $"Gestão de Bateria - {app.Battery.ChargeValue}%";
        }

        private void ChargeChanged(int value)
        {
            pbBateria.Value = value;
            Title = $"Gestão de Bateria - {value}%";
        }

        private void TotalChanged(float v1, float v2)
        {
            TbCharge.Text = $"Total carregado: {v1}mAh";
            TbDischarge.Text = $"Total descarregado: {v2}mAh";
        }

        private void BtCarregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                app.Battery.Charge(10);
            }
            catch (OutOfLimitsException exception)
            {
                MessageBox.Show(exception.Message, $"Baterial atual: {exception.Charge}%", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtDescarregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                app.Battery.Discharge(10);
            }
            catch (OutOfLimitsException exception)
            {
                MessageBox.Show(exception.Message, $"Baterial atual: {exception.Charge}%", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

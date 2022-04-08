using System.Windows;

namespace WPF_Ex11
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
            app.ModeloSoma.SomaTerminada += Window_SomaTerminada;
        }
        private void Window_SomaTerminada()
        {
            tbResultado.Text = app.ModeloSoma.Soma;
        }
        private void BtSomar_Click(object sender, RoutedEventArgs e)
        {
            app.ModeloSoma.Add(tbValor1.Text, tbValor2.Text);
        }
    }
}

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Ex11
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly App app;

        public MainPage()
        {
            InitializeComponent();

            app = Application.Current as App;
            app.ModeloSoma.SomaTerminada += Page_SomaTerminada;
        }

        private void Page_SomaTerminada()
        {
            tbResultado.Text = app.ModeloSoma.Soma.ToString();
        }

        private void BtAdicionar_Click(object sender, RoutedEventArgs e)
        {
            app.ModeloSoma.Add(tbValor1.Text, tbValor2.Text);
        }
    }
}

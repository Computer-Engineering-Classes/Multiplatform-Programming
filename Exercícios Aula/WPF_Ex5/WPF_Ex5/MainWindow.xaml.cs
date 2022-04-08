using System;
using System.Windows;

namespace WPF_Ex5
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
            Loaded += MainWindow_Loaded;
            Closed += MainWindow_Closed;
            app.ModelNotas.MensagemErro += ModelNotas_Erro;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            app.WindowNotas.Show();
            app.WindowAvaliacoes.Show();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            app.WindowNotas.Close();
            app.WindowAvaliacoes.Close();
        }

        private void BtAdicionar_Click(object sender, RoutedEventArgs e)
        {
            app.ModelNotas.Adiciona(tbNotas.Text);
        }

        private void ModelNotas_Erro(string msg)
        {
            sbErro.Content = msg;
        }

    }
}

using System.Windows;
using System.Windows.Controls;

namespace WPF_Ex8
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
            app.Escola.InitEnded += MainWindows_InitEnded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            app.Escola.Init();
        }

        private void MainWindows_InitEnded()
        {
            tbEscola.Text = app.Escola.Nome;

            foreach (Departamento departamento in app.Escola)
            {
                cbDepartamentos.Items.Add(departamento.Nome);
            }
        }

        private void CbDepartamentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sbiNDocentes.Content = $"Departamento com {app.Escola.GetNDocentes(cbDepartamentos.SelectedIndex)} docentes";
        }
    }
}

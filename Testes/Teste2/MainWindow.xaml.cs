using System.Windows;

namespace Teste2
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
            app.Implementacao.TarefaTerminada += Implementacao_TarefaTerminada;
            app.Implementacao.FluxoDados();
            app.Implementacao.Pesquisa();
        }

        private void Implementacao_TarefaTerminada()
        {
        }
    }
}

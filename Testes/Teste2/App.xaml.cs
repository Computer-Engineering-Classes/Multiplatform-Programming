using System.Windows;

namespace Teste2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Implementacao Implementacao { get; set; }

        public App()
        {
            Implementacao = new Implementacao();
        }
    }
}

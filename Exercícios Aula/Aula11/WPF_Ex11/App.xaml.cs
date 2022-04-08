using ModelSomaNamespace;
using System.Windows;

namespace WPF_Ex11
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ModelSoma ModeloSoma { get; private set; }

        public App()
        {
            ModeloSoma = new ModelSoma();
        }
    }
}

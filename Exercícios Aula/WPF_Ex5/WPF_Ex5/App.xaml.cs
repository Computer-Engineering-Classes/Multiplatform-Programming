using System.Windows;

namespace WPF_Ex5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //View 2 janelas
        public Notas WindowNotas
        {
            get;
            private set;
        }
        public Avaliacao WindowAvaliacoes
        {
            get;
            private set;
        }
        //Model 1 class
        public ModelNotas ModelNotas
        {
            get;
            private set;
        }

        public App()
        {
            //Modelo / Model
            ModelNotas = new ModelNotas();
            //Vista / View
            WindowNotas = new Notas();
            WindowAvaliacoes = new Avaliacao();
        }
    }
}

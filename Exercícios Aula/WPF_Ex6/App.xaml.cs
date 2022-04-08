using System.Windows;

namespace WPF_Ex6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Model class
        public ModelFile ModelFile;
        // View window
        public ReadWindow ReadWindow
        {
            get;
            private set;
        }

        public App()
        {
            // Model
            ModelFile = new();
            // View
            ReadWindow = new();
        }
    }
}

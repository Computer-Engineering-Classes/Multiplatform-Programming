using System.Windows;

namespace WPF_Ex7
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ModelLines ModelLines;

        public App()
        {
            ModelLines = new();
        }
    }
}

using System.Windows;

namespace WPF_Ex9
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public NewBattery Battery { get; private set; }

        public App()
        {
            Battery = new NewBattery(4000);
        }
    }
}

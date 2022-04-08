using Ex9e10.ViewModels;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Ex9e10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel ViewModel { get; init; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = DataContext as ViewModel;
            ViewModel.OpenInBrowser += OpenInBrowser;
        }

        private void OpenInBrowser(string url)
        {
            ProcessStartInfo sInfo = new()
            {
                FileName = url,
                UseShellExecute = true,
            };
            _ = Process.Start(sInfo);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ShowNoticia();
        }
    }
}

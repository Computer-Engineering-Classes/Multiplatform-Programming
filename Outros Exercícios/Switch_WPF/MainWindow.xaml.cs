using System.Windows;

namespace Switch_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Input1.Text, Input2.Text) = (Input2.Text, Input1.Text);
        }
    }
}

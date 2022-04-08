using System.Windows;

namespace WPF_Ex7
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
            app.ModelLines.LineInserted += ModelLines_LineInserted;
        }

        private void ModelLines_LineInserted(string text)
        {
            lbLines.Items.Add(text);
        }

        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                app.ModelLines.Add(tbLine.Text);
            }
            catch (InvalidLineException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}

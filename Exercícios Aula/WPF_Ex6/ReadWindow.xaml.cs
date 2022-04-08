using System.Windows;

namespace WPF_Ex6
{
    /// <summary>
    /// Interaction logic for ReadWindow.xaml
    /// </summary>
    public partial class ReadWindow : Window
    {
        private readonly App app;

        public ReadWindow()
        {
            InitializeComponent();
            app = Application.Current as App;
            app.ModelFile.ReadingFinished += ModelFile_Update;
            app.ModelFile.WritingFinished += ModelFile_Update;
        }

        private void ModelFile_Update()
        {
            tbConteudo.Text = app.ModelFile.Content;
        }
    }
}

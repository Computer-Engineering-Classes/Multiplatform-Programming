using System.Windows;

namespace WPF_Ex10.Views
{
    /// <summary>
    /// Interaction logic for AddCourseWindow.xaml
    /// </summary>
    public partial class AddCourseWindow : Window
    {
        private readonly App app;

        public AddCourseWindow()
        {
            InitializeComponent();
            app = Application.Current as App;
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TbName.Text))
            {
                app.Courses.CoursesList.Add(TbName.Text);
                Close();
            }
            else
            {
                MessageBox.Show("Nome em falta.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

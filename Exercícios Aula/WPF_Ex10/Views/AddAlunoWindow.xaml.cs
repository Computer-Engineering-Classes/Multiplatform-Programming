using System;
using System.Windows;
using WPF_Ex10.ViewModels;

namespace WPF_Ex10.Views
{
    /// <summary>
    /// Interaction logic for AddAlunoWindow.xaml
    /// </summary>
    public partial class AddAlunoWindow : Window
    {
        private readonly AddAlunoViewModel ViewModel;

        public AddAlunoWindow()
        {
            InitializeComponent();
            ViewModel = new AddAlunoViewModel();
            DataContext = ViewModel;
        }

        private void AddAluno_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.AddAluno();
                Close();
            }
            catch (ApplicationException exception)
            {
                MessageBox.Show(exception.Message, "Erro");
            }
        }
    }
}

using System.Windows;
using System.Windows.Controls;

namespace WPF_Ex8._1
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            app.Universidade.Init();
        }

        private void CbGrauEscola_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbCurso.Items.Clear();
            if (CbGrauEscola.SelectedIndex != -1)
            {
                switch (GbGrauEscola.Header)
                {
                    case "Grau":
                        foreach (Curso curso in app.Universidade.Graus[CbGrauEscola.SelectedIndex])
                        {
                            CbCurso.Items.Add(curso.Nome);
                        }
                        break;
                    case "Escola":
                        foreach (Curso curso in app.Universidade.Escolas[CbGrauEscola.SelectedIndex])
                        {
                            CbCurso.Items.Add(curso.Nome);
                        }
                        break;
                }
            }
        }

        private void CbCurso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbCurso.SelectedIndex != -1)
            {
                switch (GbGrauEscola.Header)
                {
                    case "Grau":
                        sbiNDocentes.Content = $"Curso com {app.Universidade.Graus[CbGrauEscola.SelectedIndex].GetNAlunos(CbCurso.SelectedIndex)} alunos";
                        break;
                    case "Escola":
                        sbiNDocentes.Content = $"Curso com {app.Universidade.Escolas[CbGrauEscola.SelectedIndex].GetNAlunos(CbCurso.SelectedIndex)} alunos";
                        break;
                }
            }
            else
            {
                sbiNDocentes.Content = "Selecionar Curso...";
            }
        }

        private void RbGrau_Checked(object sender, RoutedEventArgs e)
        {
            GbGrauEscola.Header = "Grau";
            CbGrauEscola.Items.Clear();
            CbCurso.Items.Clear();
            foreach (Grau grau in app.Universidade.Graus)
            {
                CbGrauEscola.Items.Add(grau.Nome);
            }
        }

        private void RbEscola_Checked(object sender, RoutedEventArgs e)
        {
            GbGrauEscola.Header = "Escola";
            CbGrauEscola.Items.Clear();
            CbCurso.Items.Clear();
            foreach (Escola escola in app.Universidade)
            {
                CbGrauEscola.Items.Add(escola.Nome);
            }
        }
    }
}

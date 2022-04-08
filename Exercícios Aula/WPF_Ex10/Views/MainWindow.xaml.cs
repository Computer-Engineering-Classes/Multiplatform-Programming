using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using WPF_Ex10.Models;

namespace WPF_Ex10.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const char TreeViewFS = ';';
        private readonly App app;

        public MainWindow()
        {
            InitializeComponent();
            app = Application.Current as App;
            app.Enrollments.ReadEnded += Model_Inscricoes_LeituraTerminada;
            app.Enrollments.EnrolmentsUpdated += Model_Inscricoes_LeituraTerminada;
            app.Enrollments.WriteEnded += Model_Inscricoes_EscritaTerminada;
        }

        private void Model_Inscricoes_LeituraTerminada()
        {
            TreeViewItem inscritos = new()
            {
                Header = "Inscritos"
            };
            TreeViewItem naoinscritos = new()
            {
                Header = "Não Inscritos"
            };
            foreach (Student student in app.Enrollments.Students.Values)
            {
                string line = $"{student.Number}{TreeViewFS}{student.Name}{TreeViewFS}{student.Course}";
                if (student.Subscribed)
                    inscritos.Items.Add(line);
                else
                    naoinscritos.Items.Add(line);
            }
            tvAlunos.Items.Clear();
            tvAlunos.Items.Add(inscritos);
            tvAlunos.Items.Add(naoinscritos);
        }

        private void Model_Inscricoes_EscritaTerminada()
        {
            MessageBox.Show("Ficheiro guardado com sucesso!");
        }

        private void MenuItem_AbrirTXT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new()
            {
                Filter = "Ficheiros de texto|*.txt|Todos os ficheiros|*.*"
            };
            if (dlg.ShowDialog() == true)
                app.Enrollments.ReadFromTxt(dlg.FileName);
        }

        private void MenuItem_GuardarTXT_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new()
            {
                Filter = "Ficheiros de texto|*.txt|Todos os ficheiros|*.*"
            };
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    app.Enrollments.WriteToTxt(dlg.FileName);
                }
                catch (InvalidOperationException erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void TvAlunos_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (tvAlunos.SelectedValue != null)
            {
                int num = Convert.ToInt32(tvAlunos.SelectedValue.ToString().Split(TreeViewFS)[0]);
                app.Enrollments.ChangeSubscription(num);
            }
        }

        private void AddAluno_Click(object sender, RoutedEventArgs e)
        {
            AddAlunoWindow window = new();
            window.ShowDialog();
            Model_Inscricoes_LeituraTerminada();
        }

        private void AddCurso_Click(object sender, RoutedEventArgs e)
        {
            AddCourseWindow window = new();
            window.ShowDialog();
        }

        private void ReadCursos_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new()
            {
                Filter = "Ficheiros de texto|*.txt|Todos os ficheiros|*.*"
            };
            if (dlg.ShowDialog() == true)
                app.Courses.ReadFromTxt(dlg.FileName);
        }

        private void SaveCurso_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new()
            {
                Filter = "Ficheiros de texto|*.txt|Todos os ficheiros|*.*"
            };
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    app.Courses.WriteToTxt(dlg.FileName);
                }
                catch (InvalidOperationException erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void MenuItem_AbrirXML_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new()
            {
                Filter = "Ficheiros XML|*.xml|Todos os ficheiros|*.*"
            };
            if (dlg.ShowDialog() == true)
                app.Enrollments.ReadFromXml(dlg.FileName);
        }

        private void MenuItem_GuardarXML_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new()
            {
                Filter = "Ficheiros XML|*.xml|Todos os ficheiros|*.*"
            };
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    app.Enrollments.WriteToXml(dlg.FileName);
                }
                catch (InvalidOperationException erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }
    }
}

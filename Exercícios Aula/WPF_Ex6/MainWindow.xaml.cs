using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;

namespace WPF_Ex6
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
            app.ModelFile.ReadingFinished += ModelFile_FileRead;
            app.ModelFile.WritingFinished += ModelFile_FileWritten;
        }

        private void ModelFile_FileRead()
        {
            tbConteudo.Text = app.ModelFile.Content;
        }

        private void BtAbrir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBoxResult.Yes;
            if (app.ModelFile.Content != tbConteudo.Text)
            {
                result = MessageBox.Show("Deseja abrir um novo ficheiro sem guardar?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            }
            if (result == MessageBoxResult.Yes)
            {
                OpenFileDialog dlg = new()
                {
                    Filter = "Ficheiros de Texto (*.txt)|*.txt|Todos os ficheiros (*.*)|*.*",
                };

                if (dlg.ShowDialog() == true)
                {
                    app.ModelFile.ReadFile(dlg.FileName);
                }
            }
        }

        private void ModelFile_FileWritten()
        {
            MessageBox.Show("Ficheiro guardado com sucesso!!!");
        }

        private void BtGuardar_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new()
            {
                Filter = "Ficheiros de Texto (*.txt)|*.txt|Todos os ficheiros (*.*)|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                app.ModelFile.WriteFile(dlg.FileName, tbConteudo.Text);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            app.ReadWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            app.ReadWindow.Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (tbConteudo.Text != app.ModelFile.Content)
            {
                MessageBoxResult result = MessageBox.Show("Deseja sair sem guardar?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}

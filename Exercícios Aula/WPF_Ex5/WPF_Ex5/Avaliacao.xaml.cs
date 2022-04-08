using System;
using System.Windows;

namespace WPF_Ex5
{
    /// <summary>
    /// Interaction logic for Avaliacao.xaml
    /// </summary>
    public partial class Avaliacao : Window
    {
        private readonly App app;

        public Avaliacao()
        {
            InitializeComponent();
            //Ligação à App
            app = Application.Current as App;
            //Subscrição de método no evento do Model
            app.ModelNotas.NotaAdicionada += ModelNotas_NotaAdicionada;
        }

        private void ModelNotas_NotaAdicionada(string str)
        {
            double nota = Convert.ToDouble(str);
            if (nota >= 9.5)
            {
                lvAvaliacoes.Items.Add($"Aprovado ({nota})");
            }
            else
            {
                lvAvaliacoes.Items.Add($"Reprovado ({nota})");
            }
        }
    }
}

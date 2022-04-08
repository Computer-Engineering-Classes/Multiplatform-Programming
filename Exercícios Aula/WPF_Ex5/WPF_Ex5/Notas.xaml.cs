using System;
using System.Windows;

namespace WPF_Ex5
{
    /// <summary>
    /// Interaction logic for Notas.xaml
    /// </summary>
    public partial class Notas : Window
    {
        private readonly App app;

        public Notas()
        {
            InitializeComponent();
            //ligação à App
            app = Application.Current as App;
            //Subscrição de um método no evento do Model
            app.ModelNotas.NotaAdicionada += ModelNotas_NotaAdicionada;
        }
        private void ModelNotas_NotaAdicionada(string str)
        {
            double nota = Math.Round(Convert.ToDouble(str));
            lbNotas.Items.Add($"{nota} valores");
        }
    }
}

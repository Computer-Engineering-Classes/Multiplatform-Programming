using System.Collections.Generic;
using System.Windows;

namespace Teste
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
            app.ModelNotas.NotaAdicionada += MainAddNota;
            app.ModelNotas.NotaCritica += MainCritica;
        }

        public void MainAddNota(string nota)
        {
            LbNotas.Items.Add(nota);
        }

        private void MainCritica()
        {
            TbCriticas.Text = app.ModelNotas.NoCriticas;
        }

        private void AddNota_Click(object sender, RoutedEventArgs e)
        {
            app.ModelNotas.Adiciona(TbNota.Text);
        }
    }

    public class ModelNotas
    {
        public delegate void MetodosComString(string str);
        public delegate void MetodoSemArg();
        public event MetodosComString NotaAdicionada;
        public event MetodoSemArg NotaCritica;

        public List<double> ListaNotas
        {
            get;
            private set;
        }

        public ModelNotas()
        {
            ListaNotas = new List<double>();
        }

        public string NoCriticas
        {
            get
            {
                int count = 0;
                foreach (double n in ListaNotas)
                {
                    if (n < 10 && n >= 8.5)
                        count++;
                }
                return count.ToString();
            }
        }

        public void Adiciona(string nota)
        {
            if (!string.IsNullOrWhiteSpace(nota))
            {
                if (double.TryParse(nota, out double tmp))
                {
                    if (tmp >= 0 && tmp <= 20)
                    {
                        ListaNotas.Add(tmp);
                        NotaAdicionada?.Invoke(nota);
                        if (tmp >= 8.5 && tmp < 10)
                            NotaCritica?.Invoke();
                    }
                }
            }
        }
    }

}

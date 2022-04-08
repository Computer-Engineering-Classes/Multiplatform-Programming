using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Ex4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Figura> Lista { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Lista = new();
        }

        private void FiguraAdicionar_Click(object sender, RoutedEventArgs e)
        {
            WindowAdicionar dlg = new();
            if (dlg.ShowDialog() == true)
            {
                lbFiguras.Items.Add(dlg.Figura.Nome);
                Lista.Add(dlg.Figura);
            }
        }

        private void LbFiguras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int fig_index = lbFiguras.SelectedIndex;
            Figura fig = Lista[fig_index];
            sbDimensoes.Content = $"Largura: {fig.Largura} Altura: {fig.Altura}";
        }
    }
}

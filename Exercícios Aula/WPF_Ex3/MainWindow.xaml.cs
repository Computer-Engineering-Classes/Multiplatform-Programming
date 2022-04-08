using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPF_Ex3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FigurasSair_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja sair?", "Sair", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void FigurasAdicionar_Click(object sender, RoutedEventArgs e)
        {
            WindowFiguras wfiguras = new();
            if (wfiguras.ShowDialog() == true)
            {
                lbFiguras.Items.Add(wfiguras.FiguraEscolhida);
                canvasRepresentacao.Children.Clear();
                switch (wfiguras.FiguraEscolhida)
                {
                    case "Quadrado":
                        Rectangle r1 = new()
                        {
                            Width = 50,
                            Height = 50,
                            Stroke = Brushes.Red,
                            StrokeThickness = 1
                        };
                        canvasRepresentacao.Children.Add(r1);
                        break;
                    case "Retângulo":
                        Rectangle r2 = new()
                        {
                            Width = 100,
                            Height = 50,
                            Stroke = Brushes.Green,
                            StrokeThickness = 1
                        };
                        canvasRepresentacao.Children.Add(r2);
                        break;
                    case "Círculo":
                        Ellipse el1 = new()
                        {
                            Width = 100,
                            Height = 100,
                            Stroke = Brushes.Blue,
                            StrokeThickness = 1
                        };
                        canvasRepresentacao.Children.Add(el1);
                        break;
                    case "Elipse":
                        Ellipse el2 = new()
                        {
                            Width = 200,
                            Height = 100,
                            Stroke = Brushes.Yellow,
                            StrokeThickness = 1
                        };
                        canvasRepresentacao.Children.Add(el2);
                        break;
                }
            }
        }
    }
}

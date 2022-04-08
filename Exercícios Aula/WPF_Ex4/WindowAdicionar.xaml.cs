using System.Windows;

namespace WPF_Ex4
{
    /// <summary>
    /// Interaction logic for WindowAdicionar.xaml
    /// </summary>
    public partial class WindowAdicionar : Window
    {
        public Figura Figura { get; private set; }

        public WindowAdicionar()
        {
            InitializeComponent();
            Figura = new();
        }

        private void BtAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbLargura.Text, out double largura) != true || double.TryParse(tbAltura.Text, out double altura) != true)
            {
                MessageBox.Show("As dimensões são inválidas.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Figura.Largura = tbLargura.Text;
                Figura.Altura = tbAltura.Text;

                if (rbCirculo.IsChecked == true)
                {
                    if (altura == largura)
                    {
                        Figura.Nome = "Círculo";
                        DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("As dimensões têm de ser idênticas.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (rbQuadrado.IsChecked == true)
                {
                    if (altura == largura)
                    {
                        Figura.Nome = "Quadrado";
                        DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("As dimensões têm de ser idênticas.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (rbRetangulo.IsChecked == true)
                {
                    Figura.Nome = "Retângulo";
                    DialogResult = true;
                }
            }
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Tem a certeza que quer cancelar?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                DialogResult = false;
            }
        }
    }
}

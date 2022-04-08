using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculadoraWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel ViewModel { get; init; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ViewModel();
            DataContext = ViewModel;
            ViewModel.ErrorEvent += ViewModel_ErrorEvent;
        }

        private void ViewModel_ErrorEvent(string str)
        {
            MessageBox.Show(str, "Erro", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void ButtonSign_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ChangeSign((sender as Button).Content);
        }

        private void ButtonAssign_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Assign();
        }

        private void ButtonInv_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Inv();
        }

        private void ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Sqrt();
        }

        private TextBox lastFocused;

        private void TextBoxFocusLost(object sender, EventArgs e)
        {
            lastFocused = (TextBox)sender;
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            if (lastFocused == TextBox1)
            {
                ViewModel.AddDigit(1, (sender as Button).Content);
            }
            else if (lastFocused == TextBox2)
            {
                ViewModel.AddDigit(2, (sender as Button).Content);
            }
        }

        private void ButtonPoint_Click(object sender, RoutedEventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused.Text.Contains('.'))
                {
                    ViewModel_ErrorEvent("Número decimal.");
                }
                else
                {
                    lastFocused.Text += '.';
                }
                _ = lastFocused.Focus();
                lastFocused.CaretIndex = lastFocused.Text.Length;
            }
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            if (lastFocused == TextBox1)
            {
                ViewModel.Minus(1);
            }
            else if (lastFocused == TextBox2)
            {
                ViewModel.Minus(2);
            }
        }

        private void ButtonClean_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Clean();
        }
    }
}

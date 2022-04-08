using ClassLibrary;
using System;
using System.Linq;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CalculadoraUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Size size = new Size(Width, Height); 
            ApplicationView.GetForCurrentView().SetPreferredMinSize(size);
            ApplicationView.PreferredLaunchViewSize = size;
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ViewModel = new ViewModel();
            DataContext = ViewModel;
            ViewModel.ErrorEvent += ViewModel_ErrorEvent;
        }

        private async void ViewModel_ErrorEvent(string str)
        {
            ContentDialog contentDialog = new ContentDialog()
            {
                Title = "Erro",
                Content = str,
                CloseButtonText = "OK"
            };
            await contentDialog.ShowAsync();
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

        private void TextBoxFocusLost(object sender, RoutedEventArgs e)
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
                    ViewModel_ErrorEvent("Número decimal.");
                else
                    lastFocused.Text += '.';
                lastFocused.Focus(FocusState.Programmatic);
                lastFocused.TabIndex = lastFocused.Text.Length;
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

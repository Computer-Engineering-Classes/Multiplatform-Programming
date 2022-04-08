using System;
using System.Windows;

namespace WPF_ExExtra2
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

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(tbV1.Text, out double v1) && Double.TryParse(tbV2.Text, out double v2))
            {
                tblSum.Text = (v1 + v2).ToString();
                comboBox.Items.Add(tblSum.Text);
                listBox.Items.Add(tblSum.Text);
                listView.Items.Add(tblSum.Text);
                treeView.Items.Add(tblSum.Text);
            }
            else
                MessageBox.Show("Valores inválidos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            tblSum.Text = "";
            comboBox.Items.Clear();
            listBox.Items.Clear();
            listView.Items.Clear();
            treeView.Items.Clear();
        }
    }
}

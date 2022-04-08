using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Ex2
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
            if (String.IsNullOrWhiteSpace(tbName.Text) || String.IsNullOrWhiteSpace(tbSurname.Text))
                MessageBox.Show("Falta nome ou apelido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                tblFullName.Text = tbName.Text + " " + tbSurname.Text;
                comboBox.Items.Add(tblFullName.Text);
                listBox.Items.Add(tblFullName.Text);
                listView.Items.Add(tblFullName.Text);
                treeView.Items.Add(tblFullName.Text);
            }
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            tblFullName.Text = "";
            comboBox.Items.Clear();
            listBox.Items.Clear();
            listView.Items.Clear();
            treeView.Items.Clear();
        }
    }
}

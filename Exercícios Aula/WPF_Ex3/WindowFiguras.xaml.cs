﻿using System;
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
using System.Windows.Shapes;

namespace WPF_Ex3
{
    /// <summary>
    /// Interaction logic for WindowFiguras.xaml
    /// </summary>
    public partial class WindowFiguras : Window
    {
        public string FiguraEscolhida 
        { 
            get; 
            private set; 
        }

        public WindowFiguras()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            FiguraEscolhida = cbFiguras.Text;
            this.DialogResult = true;
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf___PC_Koncorocny_projekt
{
    /// <summary>
    /// Interaction logic for WindowHardPexeso.xaml
    /// </summary>
    public partial class WindowHardPexeso : Window
    {
        public WindowHardPexeso()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SampleCard_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

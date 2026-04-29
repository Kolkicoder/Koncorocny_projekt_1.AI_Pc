using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf___PC_Koncorocny_projekt
{
    /// <summary>
    /// Interaction logic for WindowGame.xaml
    /// </summary>
    public partial class WindowGame : Window
    {
        public WindowGame()
        {
            InitializeComponent();
        }

        private void BtnGameClose_Click(object sender, RoutedEventArgs e)
        {
            var home = new WindowHome();
            home.Show();
            this.Close();
        }

        private void ButtonGame1_Click(object sender, RoutedEventArgs e)
        {
           WindowEasyPexeso easyPexeso = new WindowEasyPexeso();
           easyPexeso.Show();
           


        }

        private void ButtonGame2_Click(object sender, RoutedEventArgs e)
        {
            WindowHardPexeso hardPexeso = new WindowHardPexeso();
            hardPexeso.Show();
        }
    }
}

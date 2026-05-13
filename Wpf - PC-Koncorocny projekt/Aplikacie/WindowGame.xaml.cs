using System;
using System.Windows;
using System.Windows.Controls;

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

        // Fix pre chybu CS1061 - BtnGameClose_Click
        private void BtnGameClose_Click(object sender, RoutedEventArgs e) //sdasda
        {
            var home = new WindowHome();
            home.Show();
            this.Close();
        }

        // Fix pre chybu CS1061 - ButtonGame1_Click
        private void ButtonGame1_Click(object sender, RoutedEventArgs e)
        {
            WindowEasyPexeso easyPexeso = new WindowEasyPexeso();
            easyPexeso.Show();
        }

        // Metóda pre druhé tlačidlo (ButtonGame2)
        private void ButtonGame2_Click(object sender, RoutedEventArgs e)
        {
            WindowHardPexeso hardPexeso = new WindowHardPexeso();
            hardPexeso.Show();
        }
    }
}
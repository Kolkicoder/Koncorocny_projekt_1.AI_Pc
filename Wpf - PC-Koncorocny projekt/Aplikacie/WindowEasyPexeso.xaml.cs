using System.Windows;

namespace Wpf___PC_Koncorocny_projekt
{
    public partial class WindowEasyPexeso : Window
    {
        public WindowEasyPexeso()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
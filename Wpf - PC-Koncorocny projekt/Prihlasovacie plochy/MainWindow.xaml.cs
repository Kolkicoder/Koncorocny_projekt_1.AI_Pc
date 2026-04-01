using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf___PC_Koncorocny_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool escPressed = false;

        public MainWindow()
        {
            InitializeComponent();

            this.KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                escPressed = true;
            }
            else if (e.Key == Key.O && escPressed)
            {
                escPressed = false;
                
                WindowLoading secondWindow = new WindowLoading();
                secondWindow.Show();
            }
            else
            {
                escPressed = false;
            }
        }
        
    }
}
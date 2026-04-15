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
using System.Threading.Tasks;

namespace Wpf___PC_Koncorocny_projekt
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

        private async void BtnPower_Click(object sender, RoutedEventArgs e)
        {
            BtnPower.Visibility = Visibility.Collapsed;
            // little pause so user sees the power button vanish
            await Task.Delay(5000);

            var loadingWindow = new WindowLoading();
            loadingWindow.Show();
            Close();
        }
    }
}
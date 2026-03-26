using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading.Tasks;

namespace Wpf___PC_Koncorocny_projekt
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowLoading : Window
    {
        public WindowLoading()
        {
            InitializeComponent();

            var animation = new RectAnimation(
                            new Rect(0, 0, 0, 300),
                            new Rect(0, 0, 800, 400),
                            TimeSpan.FromSeconds(5));

            animation.Completed += async (s, e) =>
            {
                await Task.Delay(2000);

                WindowLogin loginWindow = new WindowLogin();
                loginWindow.Show();

                this.Close();
            };

            clipRect.BeginAnimation(RectangleGeometry.RectProperty, animation);

        }
    }
}

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
                            new Rect(0, 0, 0, 500),
                            new Rect(0, 0, 800, 500),
                            TimeSpan.FromSeconds(5));
            
            DoubleAnimation progressAnim = new DoubleAnimation(0, 680, TimeSpan.FromSeconds(5));

            animation.Completed += async (s, e) =>
            {
                txtPercent.Text = "100%"; 
                await Task.Delay(1000); 

                WindowLogin loginWindow = new WindowLogin();
                loginWindow.Show();
                this.Close();
            };
            
            //AI
            clipRect.BeginAnimation(RectangleGeometry.RectProperty, animation);
            ProgressBarFill.BeginAnimation(FrameworkElement.WidthProperty, progressAnim);
            //
            
            CompositionTarget.Rendering += (s, e) => 
            {
                if (ProgressBarFill.Width > 0)
                {                   
                    double percent = (ProgressBarFill.Width / 680) * 100;
                    if (percent <= 100)
                    {
                        txtPercent.Text = $"{(int)percent}%";
                    }
                }
            };
        }
    }
}

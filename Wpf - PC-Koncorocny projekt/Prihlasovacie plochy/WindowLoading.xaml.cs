using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prihlasovacie_plochy
{

    public partial class WindowLoading : Window
    {
        private readonly Random _rnd = new Random();

        private readonly string[] _fakeUrls = new[]
        {
            "https://krionix.io/kernel/load",
            "https://krionix.io/drivers/video/directx",
            "https://krionix.io/network/secure_shell/auth",
            "https://krionix.io/assets/ui_theme/dark_neon"
        };

        public WindowLoading()
        {
            InitializeComponent();
            StartBootSequenceAsync();
        }

        private async void StartBootSequenceAsync()
        {
            txtStatus.Text = "ESTABLISHING SECURE CONNECTION...";
            await Task.Delay(5000);

            double currentPercent = 0;
            double totalBarWidth = 500;

            while (currentPercent < 100)
            {
                double jump = _rnd.Next(2, 16);
                currentPercent += jump;
                if (currentPercent > 100) currentPercent = 100;

                double targetWidth = (currentPercent / 100.0) * totalBarWidth;

                var pbAnim = new DoubleAnimation(targetWidth, TimeSpan.FromMilliseconds(500))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                ManualProgressBarFill.BeginAnimation(FrameworkElement.WidthProperty, pbAnim);

                txtPercent.Text = $"{(int)currentPercent}%";
                txtStatus.Text = _fakeUrls[_rnd.Next(_fakeUrls.Length)] + "/node_" + _rnd.Next(1000, 9999);

                await Task.Delay(_rnd.Next(800, 1300));
            }

            txtStatus.Text = "BOOT SUCCESSFUL. FINALIZING SYSTEM SYNC...";

            var fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(500));
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(500));

            txtPercent.BeginAnimation(TextBlock.OpacityProperty, fadeOut);

            FinalLoadingArea.BeginAnimation(StackPanel.OpacityProperty, fadeIn);
            FinalLoadingArea.Visibility = Visibility.Visible;

            var rotateAnim = new DoubleAnimation(0, 360, TimeSpan.FromSeconds(1)) { RepeatBehavior = RepeatBehavior.Forever };
            SpinnerRotate.BeginAnimation(RotateTransform.AngleProperty, rotateAnim);

            await Task.Delay(8000);

            var login = new WindowLogin();
            login.Show();
            Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Wpf___PC_Koncorocny_projekt
{

    public partial class WindowHome : Window
    {

        public WindowHome()
        {
            InitializeComponent();
            StartClockLogic();

            BtnGoogle.Click += BtnGoogle_Click;
            BtnPexeso.Click += BtnPexeso_Click;

            UpdateBatteryStatus();
            var battTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(30) };
            battTimer.Tick += (s, e) => UpdateBatteryStatus();
            battTimer.Start();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (SleepOverlay.Visibility == Visibility.Visible)
            {
                var login = new WindowLogin();
                login.Show();
                this.Close();
            }
        }

        private void SetingButton_Click(object sender, RoutedEventArgs e)
        {
            PowerMenuOverlay.Visibility = PowerMenuOverlay.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void Lock_Click(object sender, RoutedEventArgs e)
        {
            PowerMenuOverlay.Visibility = Visibility.Collapsed;
            var login = new WindowLogin();
            login.Show();
            this.Close();
        }

        private void Sleep_Click(object sender, RoutedEventArgs e)
        {
            PowerMenuOverlay.Visibility = Visibility.Collapsed;
            SleepOverlay.Visibility = Visibility.Visible;
        }

        private void Shutdown_Click(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            var loading = new WindowLoading();
            loading.Show();
            this.Close();
        }

        private void StartClockLogic()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                TxtTime.Text = DateTime.Now.ToString("HH:mm:ss");
                TxtDate.Text = DateTime.Now.ToString("d. M. yyyy");

            };

            TxtTime.Text = DateTime.Now.ToString("HH:mm:ss");
            TxtDate.Text = DateTime.Now.ToString("d. M. yyyy");

            timer.Start();
        }

        private void BtnGoogle_Click(object sender, RoutedEventArgs e)
        {
            // ensure only one window is visible: open google and close home
            var googleWindow = new Google_domov();
            googleWindow.Show();
            this.Close();
        }


        private void BtnPexeso_Click(object sender, RoutedEventArgs e)
        {
            // open the game in a dedicated window and make it full screen
            var game = new WindowGame();
            game.WindowState = WindowState.Maximized;
            game.WindowStyle = WindowStyle.None;
            game.ResizeMode = ResizeMode.NoResize;
            game.Show();
            this.Close();
        }

        private void SpotifyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "\"C:\\Users\\notebook\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Spotify.lnk\"",
                UseShellExecute = true
            });
        }

        private void UpdateBatteryStatus()
        {
            try
            {
                var p = System.Windows.Forms.SystemInformation.PowerStatus;
                int percent = (int)(p.BatteryLifePercent * 100);
                TxtBattery.Text = $"🔋 {percent}%";
            }
            catch
            {
                TxtBattery.Text = "🔋 N/A";
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // toggle power menu when left green area clicked
            PowerMenuOverlay.Visibility = PowerMenuOverlay.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            e.Handled = true; // prevent the window preview handler from immediately closing it
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {













            if (SleepOverlay.Visibility == Visibility.Visible)
            {
                var login = new WindowLogin();
                login.Show();
                this.Close();
                return;
            }

            if (PowerMenuOverlay.Visibility == Visibility.Visible)
            {
                var src = e.OriginalSource as DependencyObject;
                if (src != null)
                {
                    var parent = src;
                    while (parent != null)
                    {
                        if (parent == PowerToggleBorder || parent == PowerMenuOverlay)
                        {
                            return; // click inside overlay or on toggle -> do nothing
                        }
                        parent = VisualTreeHelper.GetParent(parent);
                    }
                }

                PowerMenuOverlay.Visibility = Visibility.Collapsed;
            }
        }

    }
}


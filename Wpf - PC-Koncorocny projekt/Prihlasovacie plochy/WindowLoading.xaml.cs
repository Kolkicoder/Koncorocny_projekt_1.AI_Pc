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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wpf___PC_Koncorocny_projekt
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class WindowLoading : Window
    {
        private Random rnd = new Random();

        // AI 
        // Fiktivne adresy pre efekt bootovania
        private string[] fakeUrls =
        {
            "https://krionix.io/kernel/load",
            "https://krionix.io/drivers/video/directx",
            "https://krionix.io/network/secure_shell/auth",
            "https://krionix.io/assets/ui_theme/dark_neon"

        };

        public WindowLoading()
        {
            InitializeComponent();
            ExecuteAdvancedBootSequence();
        }

        private async void ExecuteAdvancedBootSequence()
        {
            // 1. Cakanie na loading
            txtStatus.Text = "ESTABLISHING SECURE CONNECTION...";
            await Task.Delay(5000);

            // Celkova sirka podkladu ciary
            double currentPercent = 0;
            double totalBarWidth = 600;

            // 2. Cuklus nacitavania (percenta a ciara)
            while (currentPercent < 100)
            {
                // Náhodný skok v percentách pri loadingu
                double jumpPercent = rnd.Next(2, 16);
                currentPercent += jumpPercent;

                if (currentPercent > 100) currentPercent = 100;
                double targetWidth = (currentPercent / 100.0) * totalBarWidth;

                // AI 
                // Animacia sirky modrej ciary 
                DoubleAnimation pbAnim = new DoubleAnimation(targetWidth, TimeSpan.FromMilliseconds(500));
                pbAnim.EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut };
                ManualProgressBarFill.BeginAnimation(FrameworkElement.WidthProperty, pbAnim);

                // Aktualizacia textovych informacii
                txtPercent.Text = $"{(int)currentPercent}%";
                txtStatus.Text = fakeUrls[rnd.Next(fakeUrls.Length)] + "/node_" + rnd.Next(1000, 9999);

                // Nahodna pauza medzi krokmi simulacie
                await Task.Delay(rnd.Next(800, 1300));
            }

            // 3. Priprava na prechod 
            txtStatus.Text = "BOOT SUCCESSFUL. FINALIZING SYSTEM SYNC...";

            // AI
            // Definicia plynulych prechodov 
            DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(500));
            DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(500));

            // 4. Prepnutie prvkov
            txtPercent.BeginAnimation(TextBlock.OpacityProperty, fadeOut);

            // Objavenie spinera a loadingu
            FinalLoadingArea.BeginAnimation(StackPanel.OpacityProperty, fadeIn);
            FinalLoadingArea.Visibility = Visibility.Visible;

            // AI
            // Rotacia spinera
            DoubleAnimation rotateAnim = new DoubleAnimation(0, 360, TimeSpan.FromSeconds(1));
            rotateAnim.RepeatBehavior = RepeatBehavior.Forever;
            SpinnerRotate.BeginAnimation(RotateTransform.AngleProperty, rotateAnim);

            // 5. Finalna pauza pred vstupom do WindowHome
            await Task.Delay(8000);

            // 6. Otvorenie login systemu
            WindowLogin loginWindow = new WindowLogin();
            loginWindow.Show();
            this.Close();

        }
    }
}
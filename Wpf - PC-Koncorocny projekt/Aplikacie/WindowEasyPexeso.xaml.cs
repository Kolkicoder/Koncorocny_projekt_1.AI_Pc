using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
// Disambiguate common types if System.Windows.Forms is referenced elsewhere
using Button = System.Windows.Controls.Button;
using Point = System.Windows.Point;

namespace Wpf___PC_Koncorocny_projekt
{
    public partial class WindowEasyPexeso : Window
    {
        string[] symboly = { "🐶", "🐱", "🐭", "🐹", "🐰", "🦊", "🐻", "🐼", "🐨", "🐯", "🦁", "🐮", "🐸", "🐵", "🐔", "🐧", "🐦", "🦋" };
        List<string> karty = new List<string>();
        Button prvaKarta = null;
        Button druhaKarta = null;
        bool animacia = false;
        int najdene = 0;

        public WindowEasyPexeso()
        {
            InitializeComponent();
            StartHra();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void StartHra()
        {
            karty.Clear();
            foreach (string s in symboly)
            {
                karty.Add(s);
                karty.Add(s);
            }

            Random rnd = new Random();
            for (int i = karty.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                string tmp = karty[i];
                karty[i] = karty[j];
                karty[j] = tmp;
            }

            CardGrid.Children.Clear();
            najdene = 0;
            prvaKarta = null;
            druhaKarta = null;
            TxtStatus.Text = "";

            for (int i = 0; i < 36; i++)
            {
                Button btn = new Button();
                btn.Tag = karty[i];
                btn.Content = "?";
                btn.FontSize = 24;
                btn.Margin = new Thickness(3);
                btn.Background = new SolidColorBrush(Colors.DimGray);
                btn.Foreground = new SolidColorBrush(Colors.White);
                btn.BorderThickness = new Thickness(0);
                btn.RenderTransformOrigin = new Point(0.5, 0.5);
                btn.RenderTransform = new ScaleTransform(1, 1);
                btn.Click += KlikNaKartu;
                CardGrid.Children.Add(btn);
            }
        }

        void KlikNaKartu(object sender, RoutedEventArgs e)
        {
            if (animacia) return;
            Button btn = (Button)sender;
            if (btn.Content.ToString() != "?") return;
            if (btn == prvaKarta) return;

            OtocKartu(btn, btn.Tag.ToString(), delegate
            {
                if (prvaKarta == null)
                {
                    prvaKarta = btn;
                }
                else
                {
                    druhaKarta = btn;
                    SkontrolujZhodu();
                }
            });
        }

        void SkontrolujZhodu()
        {
            string val1 = prvaKarta.Tag.ToString();
            string val2 = druhaKarta.Tag.ToString();

            if (val1 == val2)
            {
                prvaKarta.Background = new SolidColorBrush(Colors.Green);
                druhaKarta.Background = new SolidColorBrush(Colors.Green);
                prvaKarta.IsEnabled = false;
                druhaKarta.IsEnabled = false;
                prvaKarta = null;
                druhaKarta = null;
                najdene++;
                if (najdene == 18)
                    TxtStatus.Text = "Vyhral si!";
            }
            else
            {
                animacia = true;
                Button f = prvaKarta;
                Button s = druhaKarta;
                prvaKarta = null;
                druhaKarta = null;

                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(800);
                timer.Tick += delegate
                {
                    timer.Stop();
                    OtocSpat(f, delegate { });
                    OtocSpat(s, delegate { animacia = false; });
                };
                timer.Start();
            }
        }

        void OtocKartu(Button btn, string symbol, Action hotovo)
        {
            animacia = true;
            ScaleTransform scale = (ScaleTransform)btn.RenderTransform;

            DoubleAnimation zuzit = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(150));
            zuzit.Completed += delegate
            {
                btn.Content = symbol;
                DoubleAnimation roztiahnit = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(150));
                roztiahnit.Completed += delegate
                {
                    animacia = false;
                    hotovo();
                };
                scale.BeginAnimation(ScaleTransform.ScaleXProperty, roztiahnit);
            };
            scale.BeginAnimation(ScaleTransform.ScaleXProperty, zuzit);
        }

        void OtocSpat(Button btn, Action hotovo)
        {
            ScaleTransform scale = (ScaleTransform)btn.RenderTransform;

            DoubleAnimation zuzit = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(150));
            zuzit.Completed += delegate
            {
                // Set back to hidden content marker and animate scale back
                btn.Content = "?";
                DoubleAnimation roztiahnit = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(150));
                roztiahnit.Completed += delegate
                {
                    hotovo();
                };
                scale.BeginAnimation(ScaleTransform.ScaleXProperty, roztiahnit);
            };
            scale.BeginAnimation(ScaleTransform.ScaleXProperty, zuzit);
        }

    }
}

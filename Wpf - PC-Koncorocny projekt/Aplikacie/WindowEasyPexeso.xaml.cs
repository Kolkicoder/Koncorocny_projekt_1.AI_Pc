using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace Wpf___PC_Koncorocny_projekt
{
    public partial class WindowEasyPexeso : Window
    {
        private string obrazok;
        private string Source;
        private bool rnd;
        private int i;
        private int j;
        public WindowEasyPexeso()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Karta_Click(object sender, RoutedEventArgs e)
        {
            image1.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image2.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image3.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image4.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image5.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image6.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image7.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image8.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image9.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image10.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image11.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image12.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image13.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image14.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image15.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image16.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image17.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image18.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image19.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image20.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image21.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image22.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image23.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image24.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image25.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image26.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image27.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image28.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image29.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image30.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image31.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image32.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image33.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image34.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image35.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
            image36.Source = new BitmapImage(new Uri("C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp"));
        }

        public void Add_Image(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            for (int i = 0; i < 36; i++)
            {
                string obrazok = $"C:\\Users\\kolku\\source\\repos\\Wpf - PC-Koncorocny projekt\\Wpf - PC-Koncorocny projekt\\pictures\\obrazok1.webp";


                int r1 = rnd.Next(1, 20);
                System.Windows.Controls.Button btn1 = (System.Windows.Controls.Button)this.FindName("Button" + r1);
                if (btn1 != null) btn1.Content = obrazok;


                int r2 = rnd.Next(1, 36);
                System.Windows.Controls.Button btn2 = (System.Windows.Controls.Button)this.FindName("Button" + r2);
                if (btn2 != null) btn2.Content = obrazok;
            }
        }
    }
}
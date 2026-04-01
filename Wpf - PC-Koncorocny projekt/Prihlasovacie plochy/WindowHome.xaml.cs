using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowHome : Window
    {
       public WindowHome()
        {
            InitializeComponent();                       
            StartClockLogic();
                        
            BtnGoogle.Click += BtnGoogle_Click;
            BtnPexeso.Click += BtnPexeso_Click;
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
           
        }

       
        private void BtnPexeso_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
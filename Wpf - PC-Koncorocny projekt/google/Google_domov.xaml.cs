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
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Wpf___PC_Koncorocny_projekt
{
    /// <summary>
    /// Interaction logic for Google_domov.xaml
    /// </summary>

    public partial class Google_domov : Window
    {
        public Google_domov()
        {
            InitializeComponent();
        }

        private void SearchInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ResultsDisplay.Visibility = Visibility.Visible;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://chat.openai.com", 
                UseShellExecute = true
            });
        }

    }
    }




    

// HISTORIA VYHLADAVANIA !!!!!
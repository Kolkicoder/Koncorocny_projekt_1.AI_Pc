using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Policy;
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

    public partial class Google_domov : Window
    {
        public Google_domov()
        {
            InitializeComponent();
                       
            this.Loaded += Google_domov_Loaded;
        }

        private async void Google_domov_Loaded(object? sender, RoutedEventArgs e)
        {            
            this.Loaded -= Google_domov_Loaded;

            try
            {
                string query = "krionix";
                string url = $"https://api.duckduckgo.com/?q={query}&format=json";

                using HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "DuckDuckGoSearch/1.0");
                string response = await client.GetStringAsync(url);

                System.Windows.MessageBox.Show(response);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error fetching data: {ex.Message}");
            }
        }

        private void SearchInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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

        private void BtnCloseGoogle_Click(object sender, RoutedEventArgs e)
        {
            var home = new WindowHome();
            home.Show();
            this.Close();
        }



    }
}






// HISTORIA VYHLADAVANIA !!!!!
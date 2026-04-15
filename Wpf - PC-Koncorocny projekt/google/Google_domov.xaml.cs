using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics; // Toto potrebujeme na otvorenie webu

namespace Wpf___PC_Koncorocny_projekt
{
    public partial class Google_domov : Window
    {
        public Google_domov()
        {
            InitializeComponent();
        }

        private void BtnClassicMode_Click(object sender, RoutedEventArgs e)
        {
            SearchArea.Visibility = Visibility.Visible;
            AiOptionsPanel.Visibility = Visibility.Collapsed;
            if (ResultsDisplay != null) ResultsDisplay.Visibility = Visibility.Collapsed;
        }

        private void BtnAiAssistantMode_Click(object sender, RoutedEventArgs e)
        {
            SearchArea.Visibility = Visibility.Collapsed;
            AiOptionsPanel.Visibility = Visibility.Visible;
            if (ResultsDisplay != null) ResultsDisplay.Visibility = Visibility.Collapsed;

            
            AiButtonsContainer.Children.Clear();

            
            CreateAiButton("Gemini", "https://gemini.google.com");
            CreateAiButton("ChatGPT", "https://chatgpt.com");
        }

        private void CreateAiButton(string nazov, string url)
        {
           
            System.Windows.Controls.Button btn = new System.Windows.Controls.Button();

            btn.Content = nazov;
            btn.Width = 200;
            btn.Height = 80;
            btn.Margin = new Thickness(10);
            btn.FontSize = 18;
            btn.Tag = "Active"; 

          
            btn.Style = (Style)this.FindResource("NavButtonStyle");


            btn.Click += (s, ev) =>
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Chyba pri otváraní webu: " + ex.Message);
                }
            };

            
            AiButtonsContainer.Children.Add(btn);
        }

        private void BtnCloseGoogle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
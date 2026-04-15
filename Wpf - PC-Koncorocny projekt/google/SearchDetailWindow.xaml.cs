using System;
using System.Windows;
using Microsoft.Web.WebView2.Wpf;
using Microsoft.Web.WebView2.Core;

namespace Wpf___PC_Koncorocny_projekt
{
    public partial class SearchDetailWindow : Window
    {
        public SearchDetailWindow(string url)
        {
            InitializeComponent();
            InitializeAsync(url);
        }

        private async void InitializeAsync(string url)
        {
            try
            {
                await Browser.EnsureCoreWebView2Async();
                Browser.CoreWebView2.Navigate(url);
            }
            catch
            {
                
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

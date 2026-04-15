using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Wpf___PC_Koncorocny_projekt
{
    public partial class SearchResultsWindow2 : Window
    {
        public SearchResultsWindow2()
        {
            InitializeComponent();
        }

        public void SetResults(IEnumerable<SearchResult> results)
        {
            ResultsList.ItemsSource = results;
        }

        private void ResultsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ResultsList.SelectedItem is SearchResult sr && !string.IsNullOrEmpty(sr.Link))
            {
                // open fullscreen detail window with embedded browser
                var detail = new SearchDetailWindow(sr.Link)
                {
                    Owner = this.Owner,
                    WindowState = WindowState.Maximized,
                    WindowStyle = WindowStyle.None,
                    Topmost = true
                };
                detail.Show();
            }
        }
    }
}
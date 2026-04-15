using System.Collections.Generic;
using System.Windows;

namespace Wpf___PC_Koncorocny_projekt
{
    public partial class SearchResultsWindow : Window
    {
        public SearchResultsWindow()
        {
            InitializeComponent();
        }

        public void SetResults(IEnumerable<SearchResult> results)
        {
            ResultsList.ItemsSource = results;
        }
    }
}
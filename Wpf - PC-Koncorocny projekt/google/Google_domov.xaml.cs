using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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

            await PerformSearchAsync("krionix");
        }

        private async Task PerformSearchAsync(string query)
        {
            try
            {
                string url = $"https://api.duckduckgo.com/?q={Uri.EscapeDataString(query)}&format=json";

                using HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "DuckDuckGoSearch/1.0");
                string response = await client.GetStringAsync(url);

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
               
                options.Converters.Add(new NumberToStringConverter());
                DuckDuckGoResponse? ddg = null;
                try
                {
                    ddg = JsonSerializer.Deserialize<DuckDuckGoResponse>(response, options);
                }
                catch (JsonException jex)
                {
                   
                    string snippet = response?.Length > 2000 ? response.Substring(0, 2000) + "..." : response;
                    System.Windows.MessageBox.Show($"JSON parse error: {jex.Message}\n\nResponse snippet:\n{snippet}");
                    return;
                }

                var results = new List<SearchResult>();

                if (ddg?.Results != null)
                {
                    foreach (var r in ddg.Results)
                    {
                        results.Add(new SearchResult
                        {
                            Title = ddg.Heading ?? r.Text ?? string.Empty,
                            Snippet = r.Text ?? string.Empty,
                            Link = r.FirstURL ?? string.Empty
                        });
                    }
                }

                if (ddg?.RelatedTopics != null)
                {
                    void WalkRelated(IEnumerable<RelatedTopic> topics)
                    {
                        foreach (var t in topics)
                        {
                            if (!string.IsNullOrEmpty(t.Text) || t.Icon != null)
                            {
                                results.Add(new SearchResult
                                {
                                    Title = t.Text ?? string.Empty,
                                    Snippet = t.Text ?? string.Empty,
                                    Link = t.FirstURL ?? string.Empty
                                });
                            }

                            if (t.Topics != null && t.Topics.Count > 0)
                                WalkRelated(t.Topics);
                        }
                    }

                    WalkRelated(ddg.RelatedTopics);
                }

                ResultsDisplay.ItemsSource = results;
                ResultsDisplay.Visibility = results.Count > 0 ? Visibility.Visible : Visibility.Collapsed;

                if (results.Count == 0)
                {
                    
                    string heading = ddg?.Heading ?? "(no heading)";
                    string abstractText = ddg?.AbstractText ?? ddg?.Abstract ?? "(no abstract)";
                    int relatedCount = ddg?.RelatedTopics?.Count ?? 0;
                    int resultsCount = ddg?.Results?.Count ?? 0;

                    System.Windows.MessageBox.Show($"No parsed results found.\nHeading: {heading}\nAbstract: {abstractText}\nResults array count: {resultsCount}\nRelatedTopics count: {relatedCount}");
                }
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
                _ = PerformSearchAsync(SearchInput.Text ?? string.Empty);

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

        private void ResultsDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ResultsDisplay.SelectedItem is SearchResult sr)
            {                
                if (!string.IsNullOrEmpty(sr.Link))
                {
                    var detail = new SearchDetailWindow(sr.Link)
                    {
                        Owner = this,
                        WindowState = WindowState.Maximized,
                        WindowStyle = WindowStyle.None,
                        Topmost = true
                    };
                    detail.Show();
                }
            }
        }

        // also open detail on single click (so it opens directly without showing intermediate window)
        private void ResultsDisplay_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // find the item under mouse
            if (e.Source is FrameworkElement fe && fe.DataContext is SearchResult sr)
            {
                if (!string.IsNullOrEmpty(sr.Link))
                {
                    var detail = new SearchDetailWindow(sr.Link)
                    {
                        Owner = this,
                        WindowState = WindowState.Maximized,
                        WindowStyle = WindowStyle.None,
                        Topmost = true
                    };
                    detail.Show();
                    e.Handled = true;
                }
            }
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
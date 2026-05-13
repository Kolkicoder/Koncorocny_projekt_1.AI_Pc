using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Button = System.Windows.Controls.Button;
using Color = System.Windows.Media.Color;

namespace Wpf___PC_Koncorocny_projekt
{
    public partial class WindowEasyPexeso : Window
    {
        private string _player1Name;
        private string _player2Name;
        private int _currentPlayer = 1; // 1 = left player, 2 = right player

        private Dictionary<Button, int> _cardValues;
        private List<Button> _flipped;
        private HashSet<Button> _matchedCards;
        private bool _isBusy;
        private int _score1;
        private int _score2;

        public WindowEasyPexeso()
        {
            InitializeComponent();

            _player1Name = PlayerName1?.Text ?? "Player1";
            _player2Name = PlayerName2?.Text ?? "Player2";

            if (PlayerName1 != null) PlayerName1.TextChanged += PlayerName1_TextChanged;
            if (PlayerName2 != null) PlayerName2.TextChanged += PlayerName2_TextChanged;

            UpdateCurrentPlayerDisplay();
            InitializeGame();
        }

        private void PlayerName1_TextChanged(object sender, TextChangedEventArgs e)
        {
            _player1Name = PlayerName1.Text;
            UpdateCurrentPlayerDisplay();
        }

        private void PlayerName2_TextChanged(object sender, TextChangedEventArgs e)
        {
            _player2Name = PlayerName2.Text;
            UpdateCurrentPlayerDisplay();
        }

        private void UpdateCurrentPlayerDisplay()
        {
            var name = _currentPlayer == 1 ? _player1Name : _player2Name;
            TxtCurrentPlayer.Text = $"Na rade: {name}";
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // placeholder
        }

        private void Karta_Click(object sender, RoutedEventArgs e)
        {
            if (_isBusy) return;

            var btn = sender as Button;
            if (btn == null) return;
            if (_matchedCards.Contains(btn)) return;
            if (_flipped.Contains(btn)) return;

            // reveal (show id as text)
            btn.Content = _cardValues[btn].ToString();
            _flipped.Add(btn);

            if (_flipped.Count == 2)
            {
                var a = _cardValues[_flipped[0]];
                var b = _cardValues[_flipped[1]];
                if (a == b)
                {
                    _matchedCards.Add(_flipped[0]);
                    _matchedCards.Add(_flipped[1]);

                    if (_currentPlayer == 1)
                    {
                        _score1++;
                        PlayerTable1.Content = _score1.ToString();
                    }
                    else
                    {
                        _score2++;
                        PlayerTable2.Content = _score2.ToString();
                    }

                    _flipped[0].IsEnabled = false;
                    _flipped[1].IsEnabled = false;
                    _flipped[0].Background = new SolidColorBrush(Color.FromRgb(34, 139, 34));
                    _flipped[1].Background = new SolidColorBrush(Color.FromRgb(34, 139, 34));

                    _flipped.Clear();
                    // player stays the same
                    UpdateCurrentPlayerDisplay();

                    if (_matchedCards.Count >= _cardValues.Count)
                    {
                        string winner;
                        if (_score1 > _score2) winner = _player1Name;
                        else if (_score2 > _score1) winner = _player2Name;
                        else winner = "Remíza";
                        System.Windows.MessageBox.Show($"Koniec hry! Víťaz: {winner}", "Koniec", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    _isBusy = true;
                    var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(700) };
                    timer.Tick += (s, ev) =>
                    {
                        timer.Stop();
                        foreach (var f in _flipped)
                        {
                            f.Content = "?";
                        }
                        _flipped.Clear();
                        _isBusy = false;
                        // switch player
                        _currentPlayer = _currentPlayer == 1 ? 2 : 1;
                        UpdateCurrentPlayerDisplay();
                    };
                    timer.Start();
                }
            }
        }

        private void InitializeGame()
        {
            _cardValues = new Dictionary<Button, int>();
            _flipped = new List<Button>();
            _matchedCards = new HashSet<Button>();
            _isBusy = false;
            _score1 = 0;
            _score2 = 0;
            PlayerTable1.Content = "0";
            PlayerTable2.Content = "0";

            // collect buttons
            var buttons = new List<Button>();
            for (int idx = 1; idx <= 36; idx++)
            {
                var btn = this.FindName("Button" + idx) as Button;
                if (btn != null) buttons.Add(btn);
            }

            int pairCount = buttons.Count / 2;
            var ids = new List<int>();
            for (int id = 1; id <= pairCount; id++)
            {
                ids.Add(id);
                ids.Add(id);
            }

            var rnd = new Random();
            ids = ids.OrderBy(x => rnd.Next()).ToList();

            for (int i = 0; i < buttons.Count; i++)
            {
                _cardValues[buttons[i]] = ids[i];
                buttons[i].Content = "?";
                buttons[i].IsEnabled = true;
                buttons[i].Background = new SolidColorBrush(Color.FromRgb(51,51,51));
            }
        }
    }
}

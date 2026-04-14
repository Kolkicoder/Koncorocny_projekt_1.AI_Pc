using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media;

namespace Wpf___PC_Koncorocny_projekt
{
    public class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public partial class WindowLogin : Window
    {
        private readonly string _jsonPath = System.IO.Path.Combine(AppContext.BaseDirectory, "users.json");

        public WindowLogin()
        {
            InitializeComponent();
        }

        private async void UserButton_Click(object sender, RoutedEventArgs e)
        {
            string inputUser = UserNameTxt.Text;
            string inputPass = PasswordTxt.Password;

            if (string.IsNullOrWhiteSpace(inputUser) || string.IsNullOrWhiteSpace(inputPass))
            {
                System.Windows.MessageBox.Show("Please enter both username and password.", "Security", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ValidateUser(inputUser, inputPass))
            {
                LoginControls.Visibility = Visibility.Collapsed;
                LoadingOverlay.Visibility = Visibility.Visible;

                Storyboard storyboard = (Storyboard)this.FindResource("RotateLoading");
                storyboard.Begin();

                await Task.Delay(3000);

                var home = new WindowHome();
                home.Show();
                Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Invalid credentials. Please register if you are a new operator.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void ConfirmRegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string newUser = NewUserTxt.Text;
            string newPass = NewPassTxt.Password;
            string confirmPass = ConfirmPassTxt.Password; // confirmation

            if (string.IsNullOrWhiteSpace(newUser) || string.IsNullOrWhiteSpace(newPass))
            {
                System.Windows.MessageBox.Show("Registration failed. Data missing.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (newPass != confirmPass)
            {
                System.Windows.MessageBox.Show("Passwords do not match!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var users = LoadUsers();

                // check if username already exists (no LINQ)
                bool exists = false;
                foreach (var u in users)
                {
                    if (string.Equals(u.Username, newUser, StringComparison.OrdinalIgnoreCase))
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                {
                    System.Windows.MessageBox.Show("This operator already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                users.Add(new UserCredentials { Username = newUser, Password = newPass });

                string jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_jsonPath, jsonString);

                System.Windows.MessageBox.Show("Operator registered successfully. You can now login.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                NewUserTxt.Clear();
                NewPassTxt.Clear();
                ConfirmPassTxt.Clear(); // cleanup
                CloseModal_Click(null, null);
            }
            catch (Exception ex)
            {
                // simple error popup - student style
                System.Windows.MessageBox.Show("System error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<UserCredentials> LoadUsers()
        {
            if (!File.Exists(_jsonPath)) return new List<UserCredentials>();
            try
            {
                string jsonString = File.ReadAllText(_jsonPath);
                return JsonSerializer.Deserialize<List<UserCredentials>>(jsonString) ?? new List<UserCredentials>();
            }
            catch
            {
                // if file is corrupted or unreadable, return empty list
                return new List<UserCredentials>();
            }
        }

        private bool ValidateUser(string user, string pass)
        {
            var users = LoadUsers();
            foreach (var u in users)
            {
                if (u.Username == user && u.Password == pass)
                {
                    return true;
                }
            }
            return false;
        }

        private void ChangeUserButton_Click(object sender, RoutedEventArgs e)
        {
            BlurEffect myBlur = new BlurEffect { Radius = 15 };
            MainContentGrid.Effect = myBlur;
            NewUserModal.Visibility = Visibility.Visible;
        }

        private void CloseModal_Click(object sender, RoutedEventArgs e)
        {
            NewUserModal.Visibility = Visibility.Collapsed;
            MainContentGrid.Effect = null;
        }

        private void SetingButton_Click(object sender, RoutedEventArgs e)
        {
            PowerMenuOverlay.Visibility = PowerMenuOverlay.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void Lock_Click(object sender, RoutedEventArgs e)
        {
            PowerMenuOverlay.Visibility = Visibility.Collapsed;
            System.Windows.MessageBox.Show("The system has been locked.", "Security", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // UPRAVENÉ TLAČIDLO SLEEP
        private void Sleep_Click(object sender, RoutedEventArgs e)
        {
            PowerMenuOverlay.Visibility = Visibility.Collapsed;
            SleepOverlay.Visibility = Visibility.Visible; // Zobrazí čiernu plochu
        }

        // EVENT PRE PREBUDENIE Z REŽIMU SPÁNKU
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (SleepOverlay.Visibility == Visibility.Visible)
            {
                // any key wakes up to the login controls
                SleepOverlay.Visibility = Visibility.Collapsed; // Skryje čiernu plochu
                LoginControls.Visibility = Visibility.Visible;
            }
        }

        private void Window_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // if sleeping, any mouse click wakes to login controls
            if (SleepOverlay.Visibility == Visibility.Visible)
            {
                SleepOverlay.Visibility = Visibility.Collapsed;
                LoginControls.Visibility = Visibility.Visible;
                return;
            }

            // if overlay is open and user clicks outside of it, close it
            if (PowerMenuOverlay.Visibility == Visibility.Visible)
            {
                // if click happened on the settings button or inside overlay, ignore
                var src = e.OriginalSource as DependencyObject;
                if (src != null)
                {
                    var parent = src;
                    while (parent != null)
                    {
                        if (parent == SetingButton || parent == PowerMenuOverlay)
                        {
                            return; // click inside overlay or on toggle -> do nothing
                        }
                        parent = VisualTreeHelper.GetParent(parent);
                    }
                }

                PowerMenuOverlay.Visibility = Visibility.Collapsed;
            }
        }

        private void SetingButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // toggle overlay directly on mouse down so the window preview won't immediately close it
            PowerMenuOverlay.Visibility = PowerMenuOverlay.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            e.Handled = true; // stop further processing so Window_PreviewMouseDown doesn't close it
        }

        private void Shutdown_Click(object sender, RoutedEventArgs e)
        {
            MainWindow off = new MainWindow();
            off.Show();
            this.Close();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            WindowLoading loading = new WindowLoading();
            loading.Show();
            this.Close();
        }
    }
}
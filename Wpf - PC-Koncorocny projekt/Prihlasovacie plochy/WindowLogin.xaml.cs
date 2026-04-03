using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace Wpf___PC_Koncorocny_projekt
{
    public class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public partial class WindowLogin : Window
    {
        private string jsonPath = "users.json";

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
                MessageBox.Show("Please enter both username and password.", "Security", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ValidateUser(inputUser, inputPass))
            {
                LoginControls.Visibility = Visibility.Collapsed;
                LoadingOverlay.Visibility = Visibility.Visible;

                Storyboard storyboard = (Storyboard)this.FindResource("RotateLoading");
                storyboard.Begin();

                await Task.Delay(3000);

                WindowHome home = new WindowHome();
                home.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials. Please register if you are a new operator.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void ConfirmRegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string newUser = NewUserTxt.Text;
            string newPass = NewPassTxt.Password;
            string confirmPass = ConfirmPassTxt.Password; // Načítanie potvrdenia

            if (string.IsNullOrWhiteSpace(newUser) || string.IsNullOrWhiteSpace(newPass))
            {
                MessageBox.Show("Registration failed. Data missing.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // OVERENIE ZHODY HESIEL
            if (newPass != confirmPass)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                List<UserCredentials> users = LoadUsers();

                if (users.Any(u => u.Username.Equals(newUser, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("This operator already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                users.Add(new UserCredentials { Username = newUser, Password = newPass });

                string jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonPath, jsonString);

                MessageBox.Show("Operator registered successfully. You can now login.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                NewUserTxt.Clear();
                NewPassTxt.Clear();
                ConfirmPassTxt.Clear(); // Vyčistenie
                CloseModal_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"System error: {ex.Message}");
            }
        }

        private List<UserCredentials> LoadUsers()
        {
            if (!File.Exists(jsonPath)) return new List<UserCredentials>();
            try
            {
                string jsonString = File.ReadAllText(jsonPath);
                return JsonSerializer.Deserialize<List<UserCredentials>>(jsonString) ?? new List<UserCredentials>();
            }
            catch { return new List<UserCredentials>(); }
        }

        private bool ValidateUser(string user, string pass)
        {
            var users = LoadUsers();
            return users.Any(u => u.Username == user && u.Password == pass);
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
            MessageBox.Show("The system has been locked.", "Security", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // UPRAVENÉ TLAČIDLO SLEEP
        private void Sleep_Click(object sender, RoutedEventArgs e)
        {
            PowerMenuOverlay.Visibility = Visibility.Collapsed;
            SleepOverlay.Visibility = Visibility.Visible; // Zobrazí čiernu plochu
        }

        // EVENT PRE PREBUDENIE Z REŽIMU SPÁNKU
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (SleepOverlay.Visibility == Visibility.Visible)
            {
                SleepOverlay.Visibility = Visibility.Collapsed; // Skryje čiernu plochu
                // UI sa vráti do stavu Login, keďže okno nebolo zatvorené
            }
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
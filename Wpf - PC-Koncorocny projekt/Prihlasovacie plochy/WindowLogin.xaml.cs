using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Input;

namespace Wpf___PC_Koncorocny_projekt
{
    /// <summary>
    /// Logika pre prihlasovacie okno Krionix OS
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
        }

        private async void UserButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(UserNameTxt.Text) || string.IsNullOrWhiteSpace(PasswordTxt.Password))
            {
                MessageBox.Show("Login not possible. Please try again.", "Security", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; 
            }

            // AI
            LoginControls.Visibility = Visibility.Collapsed;
            LoadingOverlay.Visibility = Visibility.Visible;

            Storyboard storyboard = (Storyboard)this.FindResource("RotateLoading");
            storyboard.Begin();
           
            await Task.Delay(5000);

            WindowHome home = new WindowHome();
            home.Show();
            this.Close();
        }

        private void ChangeUserButton_Click(object sender, RoutedEventArgs e)
        {            
            BlurEffect myBlur = new BlurEffect();
            myBlur.Radius = 15;

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
            if (PowerMenuOverlay.Visibility == Visibility.Visible)
            {
                PowerMenuOverlay.Visibility = Visibility.Collapsed;
            }
            else
            {
                PowerMenuOverlay.Visibility = Visibility.Visible;
            }
        }

        private void Lock_Click(object sender, RoutedEventArgs e)
        {
            PowerMenuOverlay.Visibility = Visibility.Collapsed;
            MessageBox.Show("Systém bol uzamknutý.", "Security", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Sleep_Click(object sender, RoutedEventArgs e)
        {            
            WindowHome home = new WindowHome();
            home.Show();
            this.Close();
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

        private void UserNameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

       
    }
}
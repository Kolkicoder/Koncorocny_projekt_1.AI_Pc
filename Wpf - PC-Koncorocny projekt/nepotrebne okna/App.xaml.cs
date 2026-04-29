using System;
using System.Windows;

namespace Wpf___PC_Koncorocny_projekt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Instantiate main window directly to avoid pack URI/resource lookup errors
            var main = new Prihlasovacie_plochy.MainWindow();
            main.Show();
        }
    }
}}
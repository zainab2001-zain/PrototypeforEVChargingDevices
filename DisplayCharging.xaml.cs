using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProtypeForEV_Charging
{
    /// <summary>
    /// Interaction logic for DisplayCharging.xaml
    /// </summary>
    public partial class DisplayCharging : Window
    {
        private DispatcherTimer timer;
        private int chargingTime = 60; // Charging time in seconds
        private int elapsedTime = 0;
        public DisplayCharging()
        {
            InitializeComponent();
            StartCharging();

        }
        private void StartCharging()
        {
            // Start the dispatcher timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update progress bar
            elapsedTime++;
            ChargingProgressBar.Value = (double)elapsedTime / chargingTime * 100;

            // Calculate time left
            int timeLeft = chargingTime - elapsedTime;
            TimeSpan timeLeftSpan = TimeSpan.FromSeconds(timeLeft);
            TimeLeftLabel.Content = $"Time Left: {timeLeftSpan:mm\\:ss}";

            // If charging is completed, stop the timer and display the completion prompt
            if (elapsedTime >= chargingTime)
            {
                timer.Stop();
                TimeLeftLabel.Content = "Charging Completed";

                // Display the completion prompt
                MessageBox.Show("Charging completed. Thank you!", "Charging Completed", MessageBoxButton.OK, MessageBoxImage.Information);

                // Navigate to the authentication page
                Authentication authenticationPage = new Authentication();
                authenticationPage.Show();

                // Close the current window
                this.Close();
            }
        }

        private void CancelCharging_Click(object sender, RoutedEventArgs e)
        {
            // Open the PIN confirmation window
            PINConfirmationWindow pinWindow = new PINConfirmationWindow();
            if (pinWindow.ShowDialog() == true)
            {
                // If the PIN was confirmed, proceed with canceling charging
                MessageBox.Show("Charging canceled successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

    }
}

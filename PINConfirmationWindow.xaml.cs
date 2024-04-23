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

namespace ProtypeForEV_Charging
{
    /// <summary>
    /// Interaction logic for PINConfirmationWindow.xaml
    /// </summary>
    public partial class PINConfirmationWindow : Window
    {
        UserCredentials userCredentials;
        public PINConfirmationWindow()
        {
           
            InitializeComponent();

            userCredentials = new UserCredentials();
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the entered PIN
            string enteredPIN = PINTextBox.Text;

            // Check if the PIN is correct (you can add your validation logic here)
            if (enteredPIN == userCredentials.AccountPin)
            {
                DialogResult = true; // Set DialogResult to true to indicate success
                                     // Navigate to the charging details page
                ChargingDetails chargingDetailsPage = new ChargingDetails();
                chargingDetailsPage.Show();
                this.Close(); // Close the current window if necessary
                
            }
            else
            {
                MessageBox.Show("Incorrect PIN. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                PINTextBox.Clear(); // Clear the PIN TextBox
                PINTextBox.Focus(); // Set focus back to the PIN TextBox
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Set DialogResult to false to indicate cancelation
            Close(); // Close the window
        }
    }
}

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
    /// Interaction logic for PinInput.xaml
    /// </summary>
    public partial class PinInput : Window
    {
        private UserCredentials userCredentials;
        private TextBox selectedTextBox; // Store reference to the selected input field
        public PinInput()
        {
            InitializeComponent();
            userCredentials = new UserCredentials(); // Instantiate the class
        }
        private void PinTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            HideKeypadsExcept(PinKeypadGrid); // Hide all keypads except for PinKeypadGrid
            ShowPinKeypad(PinTextBox);
        }
        private void HideKeypadsExcept(Grid gridToKeepVisible)
        {
            
            if (gridToKeepVisible != PinKeypadGrid)
            {
                PinKeypadGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void ShowPinKeypad(TextBox textBox)
        {
            selectedTextBox = textBox;
            PinKeypadGrid.Visibility = Visibility.Visible;
            // Position the pin keypad below the selected input field
            PinKeypadGrid.Margin = new Thickness(textBox.Margin.Left, textBox.Margin.Top + textBox.Height + 10, 0, 0);
        }

        private void PinKeypadButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && selectedTextBox != null)
            {
                // Append the button's content to the selected input field
                selectedTextBox.Text += button.Content.ToString();
            }
        }
        private void PinClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTextBox != null)
            {
                selectedTextBox.Text = string.Empty;
            }
        }

        private void PinBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTextBox != null && selectedTextBox.Text.Length > 0)
            {
                selectedTextBox.Text = selectedTextBox.Text.Substring(0, selectedTextBox.Text.Length - 1);
            }
        }
        // Hide the keyboard when the focus moves away from all text boxes
        private void Window_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
           
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if both AccountNoTextBox and PinTextBox are not empty
            if (  string.IsNullOrWhiteSpace(PinTextBox.Text))
            {
                // Display a message indicating that both fields are required
                MessageBox.Show("Enter Pin Number!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Save the entered credentials globally
               
                userCredentials.AccountPin = PinTextBox.Text;
                // Proceed to the ChargingDetails window
                ChargingDetails chargingDetailsWindow = new ChargingDetails();
                chargingDetailsWindow.Show();

                // Close the current Authentication window
                this.Close();
            }

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle the "Back" button click event
            // Here, you can navigate back to the previous window or perform any other desired action
            // For example:
            Authentication mainWindow = new Authentication(); // Assuming MainWindow is the previous window
            mainWindow.Show();
            this.Close(); // Close the current window
        }
    }

}

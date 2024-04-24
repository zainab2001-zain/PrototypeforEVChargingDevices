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
    /// Interaction logic for Authentication.xaml
    /// </summary>
    public partial class Authentication : Window
    {
        
        public Authentication()
        {
            InitializeComponent();
           
        }

        private TextBox selectedTextBox; // Store reference to the selected input field

        private void AccountNoTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            HideKeypadsExcept(null); // Hide all keypads
            ShowKeyboard(AccountNoTextBox);
        }



        private void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && selectedTextBox != null)
            {
                // Append the button's content to the selected input field
                selectedTextBox.Text += button.Content.ToString();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTextBox != null)
            {
                selectedTextBox.Text = string.Empty;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTextBox != null && selectedTextBox.Text.Length > 0)
            {
                selectedTextBox.Text = selectedTextBox.Text.Substring(0, selectedTextBox.Text.Length - 1);
            }
        }

        private void Window_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!(e.NewFocus is TextBox))
            {
                HideKeyboard();
                selectedTextBox = null;
            }
        }



        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if both AccountNoTextBox and PinTextBox are not empty
            if (string.IsNullOrWhiteSpace(AccountNoTextBox.Text) )
            {
                // Display a message indicating that both fields are required
                MessageBox.Show("Account Number required!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
              
                // Proceed to the ChargingDetails window
                PinInput pinInput = new PinInput();
                pinInput.Show();

                // Close the current Authentication window
                this.Close();
            }
        }
        private void ScanQRCodeButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the QR code scanner window
            QRCodeScannerWindow scannerWindow = new QRCodeScannerWindow();

            // Show the scanner window
            scannerWindow.ShowDialog();
        }
        private void HideKeypadsExcept(Grid gridToKeepVisible)
        {
            if (gridToKeepVisible != KeyboardGrid)
            {
                KeyboardGrid.Visibility = Visibility.Collapsed;
            }

           
        }
        private void ShowKeyboard(TextBox textBox)
        {
            selectedTextBox = textBox;
            KeyboardGrid.Visibility = Visibility.Visible;
            // Position the keyboard below the selected input field
            KeyboardGrid.Margin = new Thickness(textBox.Margin.Left, textBox.Margin.Top + textBox.Height + 10, 0, 0);
        }
        private void HideKeyboard()
        {
            KeyboardGrid.Visibility = Visibility.Collapsed;
        }
       
       

       
    }

}


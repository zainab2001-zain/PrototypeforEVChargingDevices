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
    /// Interaction logic for ChargingDetails.xaml
    /// </summary>
    public partial class ChargingDetails : Window
    {
        public ChargingDetails()
        {
            InitializeComponent();
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a vehicle is selected
            if (!(CarRadioButton.IsChecked == true || BikeRadioButton.IsChecked == true || ScooterRadioButton.IsChecked == true))
            {
                MessageBox.Show("Please select a vehicle.", "Vehicle Not Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Stop further execution
            }

            // Check if a charge duration is selected
            if (!(EightHoursRadioButton.IsChecked == true || TwoHoursRadioButton.IsChecked == true || OneHourRadioButton.IsChecked == true))
            {
                MessageBox.Show("Please select a charge duration.", "Charge Duration Not Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Stop further execution
            }

            // Check if a charging bay is selected
            // For simplicity, we assume at least one bay is always selected
            RadioButton selectedBay = ChargingBayPanel.Children.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);
            if (selectedBay == null)
            {
                MessageBox.Show("Please select a charging bay.", "Charging Bay Not Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Stop further execution
            }

            // If all validations pass, proceed to the next page (payment details page)
            PaymentDetails paymentDetails = new PaymentDetails();
            paymentDetails.Show();

            // Close the current window
            this.Close();
        }
    }
    }



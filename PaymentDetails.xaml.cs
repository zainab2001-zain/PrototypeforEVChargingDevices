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
    /// Interaction logic for Charging.xaml
    /// </summary>
    public partial class PaymentDetails : Window
    {
        public PaymentDetails()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a payment method is selected
            if (!(CreditCardRadioButton.IsChecked == true || CashPaymentRadioButton.IsChecked == true))
            {
                MessageBox.Show("Please select a payment method.", "Payment Method Not Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // Proceed to the next page (authentication page)
                DisplayCharging displayCharging = new DisplayCharging();
                displayCharging.Show();

                // Close the current window
                this.Close();
            }
        }
    }
}

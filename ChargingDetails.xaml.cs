﻿using System;
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

            
            // If all validations pass, proceed to the next page (charging details page)
            ChargingDetails2 chargingDetails2 = new ChargingDetails2();
            chargingDetails2.Show();

            // Close the current window
            this.Close();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle the "Back" button click event
            // Here, you can navigate back to the previous window or perform any other desired action
            // For example:
            PinInput pinInput = new PinInput(); // Assuming MainWindow is the previous window
            pinInput.Show();
            this.Close(); // Close the current window
        }
    }
    }



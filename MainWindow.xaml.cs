using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProtypeForEV_Charging
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            // Create a new timer with an interval of 5 seconds
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);

            // Subscribe to the timer's elapsed event
            timer.Tick += Timer_Tick;

            // Start the timer
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Instantiate the new window
            Authentication secondWindow = new Authentication();

            // Display the new window
            secondWindow.Show();

            // Close the current window
            this.Close();
        }
    }
}
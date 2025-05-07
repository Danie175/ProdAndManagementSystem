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
using MaterialDesignThemes.Wpf.Internal;
using ProdAndManagementSystem.Data;
using ProdAndManagementSystem.Views;
namespace ProdAndManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
              ContentFrame.Navigate(new Views.CustomerView());
        }
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Content != null)
            {
                DefaultDashboard.Visibility = Visibility.Collapsed;
            }
        }
        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Views.OrderMenu());
        }
        private void btnVehicle_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Views.VehicleManagement());
        }

        private void btnSite_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Views.SiteManagement());
        }

        private void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Views.SupplierManagement());
        }

        private void btnRecipe_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Views.RecipeManagement());
        }

        private void btnMaterial_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Views.MaterialInventory());
        }

        private void btnBatch_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Views.BatchManagement());
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = null;
            // Show the dashboard
            DefaultDashboard.Visibility = Visibility.Visible;

            // Force WPF to immediately update the layout/render cycle
            Application.Current.Dispatcher.Invoke(() => { }, System.Windows.Threading.DispatcherPriority.Render);
        }
    }
}
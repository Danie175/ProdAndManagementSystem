using ProdAndManagementSystem.Data;
using ProdAndManagementSystem.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using ProdAndManagementSystem.Views;
using System.Data;
namespace ProdAndManagementSystem.Views
{
    public partial class VehicleManagement : Page
    {
        private readonly JustDbContext _context;

        public VehicleManagement()
        {
            JustDbContext context = new JustDbContext();
            InitializeComponent();
            _context = context;
            LoadTransportGrid();
        }

        private void LoadTransportGrid()
        {
            try
            {
                DataTable table = new DataTable();

                table.Columns.Add("Vehicleid");
                table.Columns.Add("Vehiclenumber");
                table.Columns.Add("Drivername");
                table.Columns.Add("Drivernumber");
                table.Columns.Add("Driverid");
                table.Columns.Add("Createdate", typeof(DateTime));
                table.Columns.Add("Updatedate", typeof(DateTime));

                var vehicles = _context.Vehicles.ToList();
                var drivers = _context.Drivers.ToList();

                int rowCount = Math.Max(vehicles.Count, drivers.Count);

                for (int i = 0; i < rowCount; i++)
                {
                    var vehicle = i < vehicles.Count ? vehicles[i] : null;
                    var driver = i < drivers.Count ? drivers[i] : null;

                    table.Rows.Add(
                        vehicle?.Vehicleid.ToString() ?? "",
                        vehicle?.Vehiclenumber ?? "",
                        driver?.Drivername.ToString() ?? "",
                        driver?.Drivernumber.ToString() ?? "",
                        driver?.Driverid.ToString() ?? "",
                        vehicle?.Createdate ?? driver?.Createdate ?? DateTime.MinValue,
                        vehicle?.Updatedate ?? driver?.Updatedate ?? DateTime.MinValue
                    );
                }

                dgTransport.ItemsSource = table.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load transport data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Parse IDs safely
                if (!int.TryParse(txtvehId.Text, out int vehicleId) ||
                    !int.TryParse(txtdrvid.Text, out int driverId))
                {
                    MessageBox.Show("Invalid ID values.");
                    return;
                }

                // Get existing records from DB
                var vehicle = _context.Vehicles.FirstOrDefault(v => v.Vehicleid == vehicleId);
                var driver = _context.Drivers.FirstOrDefault(d => d.Driverid == driverId);

                if (vehicle == null || driver == null)
                {
                    MessageBox.Show("Vehicle or Driver not found.");
                    return;
                }

                // Update values
                vehicle.Vehiclenumber = txtvehnum.Text;
                vehicle.Updatedate = DateTime.Now;

                driver.Drivername = txtdriver.Text;
                driver.Drivernumber = txtdrccont.Text;
                driver.Updatedate = DateTime.Now;

                // No need to call Add(), because we're modifying existing tracked entities
                _context.SaveChanges();

                MessageBox.Show("Record updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed: {ex.Message}\n{ex.InnerException?.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTransport.SelectedItem is Vehicle selectedVehicle)
            {

                var confirm = MessageBox.Show("Are you sure you want to delete this vehicle?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    _context.Vehicles.Remove(selectedVehicle);
                    _context.SaveChanges();
                    LoadTransportGrid();
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Please select a vehicle to delete.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtvehId.Text = "";
            txtvehnum.Text = "";
            txtdrvid.Text = "";
            txtdriver.Text = "";
            txtdrccont.Text = "";
        }

        private void dgTransport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dgTransport.SelectedItem is DataRowView row)
            {
                string driverName = row["Drivername"]?.ToString();
                string driverNumber = row["Drivernumber"]?.ToString();
                string vehicleNumber = row["Vehiclenumber"]?.ToString();
                string driverId = row["Driverid"]?.ToString();
                string vehicleId = row["Vehicleid"]?.ToString();

                txtvehId.Text = vehicleId;
                txtvehnum.Text = vehicleNumber;
                txtdrvid.Text = driverId;
                txtdriver.Text = driverName;
                txtdrccont.Text = driverNumber;

                BtnSave.Content = "Update";
                //MessageBox.Show($"Selected: {driverName} driving {vehicleNumber}");
            }
        }

        private void txtdrvid_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

using ProdAndManagementSystem.Data;
using ProdAndManagementSystem.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using ProdAndManagementSystem.Views;
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
            LoadVehicles();
        }

        private void LoadVehicles()
        {
            dgTransport.ItemsSource = _context.Vehicles.ToList();
            //dgTransport.ItemsSource = _context.Drivers.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var vehicle = new Vehicle
                {
                    Vehicleid = int.Parse(txtvehId.Text),
                    Vehiclenumber = txtvehnum.Text,
                    Createdate = DateTime.Now,
                    Updatedate = DateTime.Now
                };

                var driver = new Driver 
                {
                    Driverid = int.Parse(txtdrvid.Text),
                    Drivername = txtdriver.Text,
                    Drivernumber = txtdrccont.Text,
                    Createdate = DateTime.Now,
                    Updatedate = DateTime.Now
                };

                _context.Vehicles.Add(vehicle);
                _context.Drivers.Add(driver);
                _context.SaveChanges();

                MessageBox.Show("Saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Save Failed", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    LoadVehicles();
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
            if (dgTransport.SelectedItem is Vehicle selectedVehicle)
            {
                //tx.Text = selectedVehicle.Vehiclenumber;
                LoadVehicles();
            }
        }

        private void txtdrvid_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

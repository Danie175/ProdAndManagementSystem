using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using ProdAndManagementSystem.Data;
using ProdAndManagementSystem.Models;

namespace ProdAndManagementSystem.Views
{
    public partial class CustomerView : Page
    {
        private bool isEditMode = false;
        private int? currentCustomerId = null;

        public CustomerView()
        {
            InitializeComponent();
            SetAddMode();
            LoadData();
        }

        private void SetAddMode()
        {
            isEditMode = false;
            currentCustomerId = null;
            btnSave.Content = "Add";
            ClearForm();
            txtCustomerId.IsEnabled = true;
        }

        private void SetEditMode(Customer customer)
        {
            isEditMode = true;
            currentCustomerId = customer.Customerid;
            btnSave.Content = "Update";

            txtCustomerId.Text = customer.Customerid.ToString();
            txtCustomerName.Text = customer.Customername ?? string.Empty;
            txtCustomerAddress.Text = customer.Customeradd ?? string.Empty;
            txtCustomerNumber.Text = customer.Customernumber ?? string.Empty;
            txtCustomerId.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text.Trim(), out int customerId))
            {
                MessageBox.Show("Invalid Customer ID. Please enter a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string name = txtCustomerName.Text.Trim();
            string address = txtCustomerAddress.Text.Trim();
            string number = txtCustomerNumber.Text.Trim();
            //string site = txtSiteName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Customer name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (JustDbContext context = new JustDbContext())
            {
                try
                {
                    if (isEditMode && currentCustomerId.HasValue)
                    {
                        var customerToUpdate = context.Customers.SingleOrDefault(c => c.Customerid == currentCustomerId);

                        if (customerToUpdate == null)
                        {
                            MessageBox.Show("Customer not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            SetAddMode();
                            LoadData();
                            return;
                        }

                        customerToUpdate.Customername = name;
                        customerToUpdate.Customeradd = address;
                        customerToUpdate.Customernumber = number;
                        customerToUpdate.Updatedate = DateTime.Now;

                        context.SaveChanges();
                        MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        // Check for duplicates
                        bool exists = context.Customers.Any(c => c.Customerid == customerId);
                        if (exists)
                        {
                            MessageBox.Show("A customer with this ID already exists.", "Duplicate Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        var newCustomer = new Customer
                        {
                            Customerid = customerId,
                            Customername = name,
                            Customeradd = address,
                            Customernumber = number,
                            Createdate = DateTime.Now,
                            Updatedate = DateTime.Now
                        };

                        context.Customers.Add(newCustomer);
                        context.SaveChanges();
                        MessageBox.Show("Customer added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    LoadData();
                    SetAddMode();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"Database error: {ex.InnerException?.Message ?? ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void dgCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selectedCustomer)
            {
                SetEditMode(selectedCustomer);
            }
        }

        private void LoadData()
        {
            try
            {
                using (JustDbContext context = new JustDbContext())
                {
                    var customers = context.Customers.ToList();
                    dgCustomers.ItemsSource = customers;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer data: {ex.Message}", "Data Load Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearForm()
        {
            txtCustomerId.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtCustomerNumber.Text = string.Empty;
            //txtSiteName.Text = string.Empty;
            dgCustomers.SelectedItem = null;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            SetAddMode();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!currentCustomerId.HasValue)
            {
                MessageBox.Show("Select a customer to delete.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;

            using (JustDbContext context = new JustDbContext())
            {
                try
                {
                    var customer = context.Customers.SingleOrDefault(c => c.Customerid == currentCustomerId);
                    if (customer == null)
                    {
                        MessageBox.Show("Customer not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    context.Customers.Remove(customer);
                    context.SaveChanges();
                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                    SetAddMode();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Delete failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();

                using (JustDbContext context = new JustDbContext())
                {
                    var results = context.Customers.Where(c =>
                        (!string.IsNullOrEmpty(c.Customername) && c.Customername.Contains(searchTerm)) ||
                        (!string.IsNullOrEmpty(c.Customernumber) && c.Customernumber.Contains(searchTerm)) ||
                        (!string.IsNullOrEmpty(c.Customeradd) && c.Customeradd.Contains(searchTerm)) 
                    ).ToList();

                    dgCustomers.ItemsSource = results;

                    if (!results.Any())
                        MessageBox.Show("No matching customers found.", "Search Result", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
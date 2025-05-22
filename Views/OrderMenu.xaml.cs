using ProdAndManagementSystem.Data;
using ProdAndManagementSystem.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace ProdAndManagementSystem.Views
{
    public partial class OrderMenu : Page
    {
        private readonly JustDbContext _context = new JustDbContext();
        private List<Ordertable> _orders;

        public OrderMenu()
        {
            InitializeComponent();
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var customers = await _context.Customers.ToListAsync();
                var sites = await _context.Sites.ToListAsync();
                var recipes = await _context.Recipes.ToListAsync();

                CustomerDropbox.ItemsSource = customers;
                SiteDropbox.ItemsSource = sites;
                RecipeDropbox.ItemsSource = recipes;

                CustomerDropbox.DisplayMemberPath = "Customerid";
                SiteDropbox.DisplayMemberPath = "Siteid";
                RecipeDropbox.DisplayMemberPath = "Id";

                await LoadOrdersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async Task LoadOrdersAsync()
        {
            try
            {
                _orders = await _context.Ordertables
                    .Include(o => o.Customer)
                    .Include(o => o.Site)
                    .Include(o => o.Recipe)
                    .ToListAsync();

                OrderDg.ItemsSource = _orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}");
            }
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var query = _context.Ordertables
                    .Include(o => o.Customer)
                    .Include(o => o.Site)
                    .Include(o => o.Recipe)
                    .AsQueryable();

                if (CustomerDropbox.SelectedItem is Customer customer)
                    query = query.Where(o => o.Customerid == customer.Customerid);

                if (SiteDropbox.SelectedItem is Site site)
                    query = query.Where(o => o.Siteid == site.Siteid);

                if (RecipeDropbox.SelectedItem is Recipe recipe)
                    query = query.Where(o => o.Recipeid == recipe.Id);

                if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))
                    query = query.Where(o => o.Orderid.ToString().Contains(SearchTextBox.Text));

                _orders = await query.ToListAsync();
                OrderDg.ItemsSource = _orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}");
            }
        }

        private async void btnReset_Click(object sender, RoutedEventArgs e)
        {
            CustomerDropbox.SelectedItem = null;
            SiteDropbox.SelectedItem = null;
            RecipeDropbox.SelectedItem = null;
            SearchTextBox.Clear();

            await LoadOrdersAsync();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_orders == null || !_orders.Any())
                {
                    MessageBox.Show("No data to export.");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV file (*.csv)|*.csv",
                    FileName = "Orders.csv"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    using var writer = new StreamWriter(saveFileDialog.FileName);
                    writer.WriteLine("OrderID,CustomerID,SiteID,RecipeID,CreatedDate");

                    foreach (var order in _orders)
                    {
                        writer.WriteLine($"{order.Orderid},{order.Customerid},{order.Siteid},{order.Recipeid},{order.Createdate}");
                    }

                    MessageBox.Show("Export successful.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}");
            }
        }
        private async void EditOrder()
        {
            try
            {
                if (OrderDg.SelectedItem is not Ordertable selectedOrder)
                {
                    MessageBox.Show("Please select an order to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new JustDbContext())
                {
                    // Fetch original from DB using primary key
                    var orderToUpdate = await context.Ordertables
                        .FirstOrDefaultAsync(o => o.Srno == selectedOrder.Srno);

                    if (orderToUpdate == null)
                    {
                        MessageBox.Show("Order not found in database.", "Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Update fields based on UI selections
                    if (CustomerDropbox.SelectedItem is Customer selectedCustomer)
                        orderToUpdate.Customerid = selectedCustomer.Customerid;

                    if (SiteDropbox.SelectedItem is Site selectedSite)
                        orderToUpdate.Siteid = selectedSite.Siteid;

                    if (RecipeDropbox.SelectedItem is Recipe selectedRecipe)
                        orderToUpdate.Recipeid = selectedRecipe.Id;

                    // Optional: Update other fields here (like quantity, notes, etc.)
                    // if (double.TryParse(QuantityTextBox.Text, out double qty))
                    //     orderToUpdate.Quantity = qty;

                    orderToUpdate.Updatedate = DateTime.Now;

                    await context.SaveChangesAsync();

                    MessageBox.Show("Order updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Refresh DataGrid with latest data
                    await ReloadOrderData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task ReloadOrderData()
        {
            try
            {
                using var context = new JustDbContext();

                var orders = await context.Ordertables
                    .Include(o => o.Customer)
                    .Include(o => o.Site)
                    .Include(o => o.Recipe)
                    .ToListAsync();

                OrderDg.ItemsSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Optional: You can fill in selection events if needed later
        private void OrderDg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderDg.SelectedItem is Ordertable selectedOrder)
            {
                // Set dropdowns to match the selected order’s current values
                CustomerDropbox.SelectedValue = selectedOrder.Customer;
                SiteDropbox.SelectedValue = selectedOrder.Site;
                RecipeDropbox.SelectedValue = selectedOrder.Recipeid;

                // Optional: load into text fields if present
                 //QuantityTextBox.Text = selectedOrder.ToString();
                 //OrderIdTextBox.Text = selectedOrder.Orderid;

                Console.WriteLine($"Order selected: {selectedOrder.Orderid}");
            }
        }

        private void SiteDropbox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            SiteDropbox.DisplayMemberPath = "Siteid";
        }
        private void RecipeDropbox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            RecipeDropbox.DisplayMemberPath = "Id";
        }
        private void CustomerDropbox_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) { }

        private void StatusDropbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PriorityDropbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

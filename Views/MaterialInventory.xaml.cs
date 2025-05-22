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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using ProdAndManagementSystem.Data;
using ProdAndManagementSystem.Models;

namespace ProdAndManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for MaterialInventory.xaml
    /// </summary>
    public partial class MaterialInventory : Page
    {
        private readonly JustDbContext _context = new JustDbContext();

        public MaterialInventory()
        {
            InitializeComponent();
            _ = LoadInitialDataAsync();
        }

        private async Task LoadInitialDataAsync()
        {
            try
            {
                var categories = await _context.MaterialInventories
                    .Select(m => m.Category)
                    .Distinct()
                    .ToListAsync();
                CategoryDropbox.ItemsSource = categories;

                var suppliers = await _context.SupplierMasters.ToListAsync();
                SupplierID_Dropbox.ItemsSource = suppliers;
                SupplierID_Dropbox.DisplayMemberPath = "SupplierName";
                SupplierID_Dropbox.SelectedValuePath = "SupplierId";

                TransactiontypeDropbox.ItemsSource = new List<string> { "IN", "OUT" };


                await LoadTransactionsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async Task LoadTransactionsAsync()
        {
            try
            {
                var transactions = await _context.MaterialInventories.ToListAsync();
                TransactionsDataGrid.ItemsSource = transactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transactions: {ex.Message}");
            }
        }

        private void CategoryDropbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MaterialName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Optional: auto-fill rate or other metadata if needed
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            RecalculateTotalCost();
        }

        private void txtRate_TextChanged(object sender, TextChangedEventArgs e)
        {
            RecalculateTotalCost();
        }

        private void txtTotalCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            // No-op: recalculated from qty x rate
        }
        
        private void TransactiontypeDropbox_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void SupplierID_Dropbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SupplierID_Dropbox.SelectedItem is SupplierMaster supplier)
            {
                // Optional: auto-fill other fields based on supplier
                SupplierID_Dropbox.SelectedValue = supplier.SupplierId;
            }
        }
        private void txtInvoiceNumber_TextChanged(object sender, TextChangedEventArgs e) { }
        private void txtDeliverChalanNo_TextChanged(object sender, TextChangedEventArgs e) { }
        private void txtTruckNumber_TextChanged(object sender, TextChangedEventArgs e) { }
        private void txtDriverName_TextChanged(object sender, TextChangedEventArgs e) { }

        private void TransactionsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TransactionsDataGrid.SelectedItem is Models.MaterialInventory selected)
            {
                txtMaterialName.Text = selected.MaterialName;
                TransactiontypeDropbox.SelectedItem = selected.TransactionType;   
                SupplierID_Dropbox.SelectedValue = selected.SupplierId;

                txtQuantity.Text = selected.Quantity.ToString();
                txtRate.Text = selected.Rate.ToString();
                txtTotalCost.Text = selected.TotalCost.ToString();
                txtInvoiceNumber.Text = selected.InvoiceNumber;
                txtDeliverChalanNo.Text = selected.DeliveryChalanNo;
                txtTruckNumber.Text = selected.TruckNumber;
                txtDriverName.Text = selected.DriverName;
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtMaterialName.Text == null || string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    MessageBox.Show("Please select material and enter quantity.");
                    return;
                }

                var transaction = new Models.MaterialInventory
                {
                    MaterialName = txtMaterialName.Text?.ToString(),
                    TransactionType = TransactiontypeDropbox.SelectedItem?.ToString(),
                    SupplierId = SupplierID_Dropbox.SelectedValue as int?,
                    Quantity = double.TryParse(txtQuantity.Text, out var q) ? q : 0,
                    Rate = double.TryParse(txtRate.Text, out var r) ? r : 0,
                    TotalCost = double.TryParse(txtTotalCost.Text, out var c) ? c : 0,
                    InvoiceNumber = txtInvoiceNumber.Text,
                    DeliveryChalanNo = txtDeliverChalanNo.Text,
                    TruckNumber = txtTruckNumber.Text,
                    DriverName = txtDriverName.Text,
                    Createdate = DateTime.Now
                };

                _context.MaterialInventories.Add(transaction);
                await _context.SaveChangesAsync();
                await LoadTransactionsAsync();

                MessageBox.Show("Transaction saved.");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save failed: {ex.Message}");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtMaterialName.Clear();
            TransactiontypeDropbox.SelectedItem = null;
            SupplierID_Dropbox.SelectedItem = null;
            txtQuantity.Clear();
            txtRate.Clear();
            txtTotalCost.Clear();
            txtInvoiceNumber.Clear();
            txtDeliverChalanNo.Clear();
            txtTruckNumber.Clear();
            txtDriverName.Clear();
            TransactionsDataGrid.UnselectAll();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TransactionsDataGrid.SelectedItem is not Models.MaterialInventory selected)
                {
                    MessageBox.Show("Please select a transaction to delete.");
                    return;
                }

                var confirm = MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm", MessageBoxButton.YesNo);
                if (confirm != MessageBoxResult.Yes) return;

                _context.MaterialInventories.Remove(selected);
                await _context.SaveChangesAsync();
                await LoadTransactionsAsync();

                MessageBox.Show("Transaction deleted.");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete failed: {ex.Message}");
            }
        }

        private void RecalculateTotalCost()
        {
            if (double.TryParse(txtQuantity.Text, out var qty) && double.TryParse(txtRate.Text, out var rate))
            {
                txtTotalCost.Text = (qty * rate).ToString("F2");
            }
            else
            {
                txtTotalCost.Text = "0.00";
            }
        }

        private void txtMaterialName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtRemarks_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}

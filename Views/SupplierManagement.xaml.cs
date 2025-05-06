using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProdAndManagementSystem.Data;
using ProdAndManagementSystem.Models;

namespace ProdAndManagementSystem.Views
{
    public partial class SupplierManagement : Page
    {
        private readonly JustDbContext _context = new JustDbContext();
        private bool isEditMode = false;
        private int? currentSupplierId = null;

        public SupplierManagement()
        {
            InitializeComponent();
            LoadSuppliers();
            SetAddMode();
        }

        private void LoadSuppliers()
        {
            try
            {
                dgSupplier.ItemsSource = _context.SupplierMasters.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading suppliers: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SupplierbtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
                {
                    MessageBox.Show("Supplier name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (isEditMode && currentSupplierId.HasValue)
                {
                    var existingSupplier = _context.SupplierMasters.Find(currentSupplierId.Value);
                    if (existingSupplier != null)
                    {
                        existingSupplier.SupplierId = int.TryParse(txtSupplierId.Text, out int Id) ? Id : 0;
                        existingSupplier.SupplierName = txtSupplierName.Text;
                        existingSupplier.AddressLine1 = txtAddress1.Text;
                        existingSupplier.AddressLine2 = txtAddress2.Text;
                        existingSupplier.PhoneNumber = double.TryParse(txtPhoneNumber.Text, out double phone) ? phone : null;
                        existingSupplier.Gstnumber = txtGSTNumber.Text;
                        existingSupplier.Updatedate = DateTime.Now;

                        _context.SaveChanges();
                        MessageBox.Show("Supplier updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                else
                {
                    SupplierMaster supplier = new SupplierMaster
                    {
                        SupplierId = int.TryParse(txtSupplierId.Text, out int Id) ? Id : 0,
                        SupplierName = txtSupplierName.Text,
                        AddressLine1 = txtAddress1.Text,
                        AddressLine2 = txtAddress2.Text,
                        PhoneNumber = double.TryParse(txtPhoneNumber.Text, out double phone) ? phone : null,
                        Gstnumber = txtGSTNumber.Text,
                        Createdate = DateTime.Now,
                        Updatedate = DateTime.Now
                    };

                    _context.SupplierMasters.Add(supplier);
                    _context.SaveChanges();
                    MessageBox.Show("Supplier saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                LoadSuppliers();
                SetAddMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving supplier: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SupplierbtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgSupplier.SelectedItem is SupplierMaster selected)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm Delete",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        _context.SupplierMasters.Remove(selected);
                        _context.SaveChanges();
                        MessageBox.Show("Supplier deleted.", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadSuppliers();
                        SetAddMode();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a supplier to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting supplier: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SupplierbtnClear_Click(object sender, RoutedEventArgs e)
        {
            SetAddMode();
        }

        private void SupplierbtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string search = txtSearchSupplier.Text.ToLower();
                dgSupplier.ItemsSource = _context.SupplierMasters
                    .Where(s => s.SupplierName.ToLower().Contains(search))
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching suppliers: {ex.Message}", "Search Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtSearchSupplier_TextChanged(object sender, TextChangedEventArgs e)
        {
            SupplierbtnSearch_Click(sender, e);
        }

        private void dgSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgSupplier.SelectedItem is SupplierMaster selected)
                {
                    SetEditMode(selected);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting supplier: {ex.Message}", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearFields()
        {
            txtSupplierId.Clear();
            txtSupplierName.Clear();
            txtAddress1.Clear();
            txtAddress2.Clear();
            txtPhoneNumber.Clear();
            txtGSTNumber.Clear();
            dgSupplier.SelectedIndex = -1;
        }

        private void SetAddMode()
        {
            isEditMode = false;
            currentSupplierId = null;
            SupplierbtnSave.Content = "Add";
            ClearFields();
            txtSupplierId.IsEnabled = true;
        }

        private void SetEditMode(SupplierMaster supplier)
        {
            isEditMode = true;
            currentSupplierId = supplier.SupplierId;
            SupplierbtnSave.Content = "Update";
            txtSupplierId.Text = supplier.SupplierId.ToString();
            txtSupplierName.Text = supplier.SupplierName ?? string.Empty;
            txtAddress1.Text = supplier.AddressLine1 ?? string.Empty;
            txtAddress2.Text = supplier.AddressLine2 ?? string.Empty;
            txtPhoneNumber.Text = supplier.PhoneNumber?.ToString() ?? string.Empty;
            txtGSTNumber.Text = supplier.Gstnumber ?? string.Empty;
            txtSupplierId.IsEnabled = false;
        }
    }
}
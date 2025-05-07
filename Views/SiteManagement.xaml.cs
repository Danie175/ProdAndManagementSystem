using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProdAndManagementSystem.Data;
using ProdAndManagementSystem.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProdAndManagementSystem.Views
{
    public partial class SiteManagement : Page
    {
        private readonly JustDbContext _context;

        public SiteManagement()
        {
            _context = new JustDbContext();
            InitializeComponent();
            LoadSites();
        }

        // Add this method to properly dispose the context when the page is unloaded
        ~SiteManagement()
        {
            _context?.Dispose();
        }

        private void LoadSites()
        {
            // Use AsNoTracking to avoid tracking conflicts
            dgSite.ItemsSource = _context.Sites.AsNoTracking().ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSiteId.Text) || string.IsNullOrWhiteSpace(txtNumberSite.Text))
                {
                    MessageBox.Show("Site ID and Number are required.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int siteId = int.Parse(txtSiteId.Text);

                if (dgSite.SelectedItem is Site selected && selected.Siteid == siteId)
                {
                    _context.Entry(selected).State = EntityState.Detached;
                }

                var existing = _context.Sites.FirstOrDefault(s => s.Siteid == siteId);

                if (existing != null)
                {
                    // Update properties without changing entity
                    existing.Siteadd = txtAddressSite.Text;
                    existing.Sitenumber = txtNumberSite.Text;
                    existing.Updatedate = DateTime.Now;
                    existing.Sitename = txtSiteName.Text;
                }
                else
                {
                    var site = new Site
                    {
                        Siteid = siteId,
                        Sitename = txtSiteName.Text,
                        Siteadd = txtAddressSite.Text,
                        Sitenumber = txtNumberSite.Text,
                        Createdate = DateTime.Now,
                        Updatedate = DateTime.Now
                    };

                    _context.Sites.Add(site);
                }

                _context.SaveChanges();
                MessageBox.Show("Saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Refresh the data
                _context.ChangeTracker.Clear(); // Clear tracking
                LoadSites();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgSite.SelectedItem is Site selected)
            {
                var confirm = MessageBox.Show($"Are you sure to delete Site ID {selected.Siteid}?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        // Find the entity from the context to ensure correct tracking
                        var siteToDelete = _context.Sites.Find(selected.Siteid);
                        if (siteToDelete != null)
                        {
                            _context.Sites.Remove(siteToDelete);
                            _context.SaveChanges();
                        }

                        // Clear tracking after operation
                        _context.ChangeTracker.Clear();
                        LoadSites();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting: {ex.Message}", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a site from the list.", "Delete Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtSiteName.Text = "";
            txtSiteId.Text = "";
            txtAddressSite.Text = "";
            txtNumberSite.Text = "";
            dgSite.SelectedItem = null;
        }

        private void dgSite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgSite.SelectedItem is Site site)
            {
                txtSiteName.Text = site.Sitename;
                txtSiteId.Text = site.Siteid.ToString();
                txtAddressSite.Text = site.Siteadd;
                txtNumberSite.Text = site.Sitenumber;
            }
        }

        private void txtSiteSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSiteSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
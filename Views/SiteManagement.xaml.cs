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
            using JustDbContext context = new JustDbContext();
            InitializeComponent();
            _context = context;
            LoadSites();
        }

        private void LoadSites()
        {
            dgSite.ItemsSource = _context.Sites.ToList();
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
                var existing = _context.Sites.FirstOrDefault(s => s.Siteid == siteId);

                if (existing != null) 
                {
                    existing.Siteadd = txtAddressSite.Text;
                    existing.Sitenumber = txtNumberSite.Text;
                    existing.Updatedate = DateTime.Now;

                    _context.Sites.Update(existing);
                }
                else
                {
                    var site = new Site
                    {
                        Siteid = siteId,
                        //Sitename = txt,
                        Siteadd = txtAddressSite.Text,
                        Sitenumber = txtNumberSite.Text,
                        Createdate = DateTime.Now,
                        Updatedate = DateTime.Now
                    };

                    _context.Sites.Add(site);
                }

                _context.SaveChanges();
                MessageBox.Show("Saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    _context.Sites.Remove(selected);
                    _context.SaveChanges();
                    LoadSites();
                    ClearForm();
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
            txtSiteId.Text = "";
            txtAddressSite.Text = "";
            txtNumberSite.Text = "";
            dgSite.SelectedItem = null;
        }

        private void dgSite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgSite.SelectedItem is Site site)
            {
                txtSiteId.Text = site.Siteid.ToString();
                txtAddressSite.Text = site.Siteadd;
                txtNumberSite.Text = site.Sitenumber;
            }
        }

        //private void btnSiteSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    string keyword = txtSiteSearch.Text.Trim().ToLower();

        //    var filtered = _context.Sites
        //        .Where(s => s.Siteid.ToString().Contains(keyword)
        //                 || s.Sitenumber.ToLower().Contains(keyword)
        //                 || s.Siteadd.ToLower().Contains(keyword)
        //                 || s.Sitename.ToLower().Contains(keyword))
        //        .OrderByDescending(s => s.Updatedate ?? s.Createdate)
        //        .ToList();

        //    dgSite.ItemsSource = filtered;
        //}

        private void txtSiteSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSiteSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

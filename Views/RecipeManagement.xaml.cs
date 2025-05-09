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

namespace ProdAndManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for RecipeManagement.xaml
    /// </summary>
    public partial class RecipeManagement : Page
    {
        public RecipeManagement()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ClearForm()
        {
            foreach (var control in LogicalTreeHelper.GetChildren(this))
            {
                ClearTextBoxes(control);
            }
        }

        private void ClearTextBoxes(object parent)
        {
            if (parent is TextBox textBox)
            {
                textBox.Text = string.Empty;
            }
            else if (parent is Panel panel)
            {
                foreach (var child in panel.Children)
                {
                    ClearTextBoxes(child);
                }
            }
            else if (parent is ContentControl contentControl)
            {
                ClearTextBoxes(contentControl.Content);
            }
            //else if (parent is Decorator decorator)
            //{
            //    ClearTextBoxes(decorator.Child);
            //}
            //else if (parent is ItemsControl itemsControl)
            //{
            //    foreach (var item in itemsControl.Items)
            //    {
            //        ClearTextBoxes(item);
            //    }
            //}
        }

        private void txtRecipeId_TextChanged(object sender, TextChangedEventArgs e)
        {
       
        }

        private void txtRecipeName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void btnSaD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaA_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
    }
}

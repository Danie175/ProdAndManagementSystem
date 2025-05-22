using Microsoft.EntityFrameworkCore;
using ProdAndManagementSystem.Data;
using ProdAndManagementSystem.Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProdAndManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for RecipeManagement.xaml
    /// </summary>
    public partial class RecipeManagement : Page
    {
        private readonly JustDbContext _context;
        private Recipe _currentRecipe;
        private bool _isNewRecipe = true;
        private readonly Regex _numericRegex = new Regex("[^0-9.-]+");
        private bool isEditMode = false;

        public RecipeManagement()
        {
            InitializeComponent();
            _context = new JustDbContext();
            _currentRecipe = new Recipe();

            // Initialize date fields for new records
            _currentRecipe.Createdate = DateTime.Now;
            _currentRecipe.Updatedate = DateTime.Now;

            // Add event handlers for validation
            RegisterNumericValidationHandlers();
            txtSelRefID.IsReadOnly = false; 
            txtRecipeId.IsReadOnly = true; // Recipe ID read-only
            LoadRecipe();

        }

        private void RegisterNumericValidationHandlers()
        {
            // Register numeric validation for all STP value text boxes
            txtAgg1STP.PreviewTextInput += NumericValidation;
            txtAgg2STP.PreviewTextInput += NumericValidation;
            txtAgg3STP.PreviewTextInput += NumericValidation;
            txtAgg4STP.PreviewTextInput += NumericValidation;
            txtCement1STP.PreviewTextInput += NumericValidation;
            txtCement2STP.PreviewTextInput += NumericValidation;
            txtCement3STP.PreviewTextInput += NumericValidation;
            txtCement4STP.PreviewTextInput += NumericValidation;
            txtWater1STP.PreviewTextInput += NumericValidation;
            txtWater2STP.PreviewTextInput += NumericValidation;
            txtAdmix1STP.PreviewTextInput += NumericValidation;
            txtAdmix2STP.PreviewTextInput += NumericValidation;
            txtAdmix3STP.PreviewTextInput += NumericValidation;
            txtAdmixNewSTP.PreviewTextInput += NumericValidation;
        }

        private void NumericValidation(object sender, TextCompositionEventArgs e)
        {
            // Only allow numeric input for STP values
            e.Handled = _numericRegex.IsMatch(e.Text);
        }
        private string RecipeCodeGenerator(string prefix = "REC")
        {

            string recipeName = txtRecipeName.Text.Trim();

            if (string.IsNullOrWhiteSpace(recipeName))
                recipeName = "UNKNOWN";

            // Get initials from recipe name
            string initials = GetInitials(recipeName);

            // Timestamp in yyyyMMddHHmmss
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

            return $"{prefix.ToUpper()}-{initials}-{timestamp}";
        }
        private string GetInitials(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "XX";

            var words = input
                .Split(new[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries)
                .Take(2) // Use up to 2 initials
                .Select(word => char.ToUpper(word[0]));

            return string.Concat(words);
        }

        private void txtRecipeId_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void txtRecipeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Real-time validation for recipe name
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text))
            {
                txtRecipeName.BorderBrush = System.Windows.Media.Brushes.Red;
                txtRecipeName.ToolTip = "Recipe name cannot be empty";
            }
            else
            {
                txtRecipeName.BorderBrush = System.Windows.Media.Brushes.Gray;
                txtRecipeName.ToolTip = null;
            }
        }

        private void btnSaD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveRecipe(isApproved: false);
                MessageBox.Show("Recipe saved as draft successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving recipe: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSaA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateRecipe())
                {
                    SaveRecipe(isApproved: true);
                    MessageBox.Show("Recipe saved and approved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving recipe: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgRecipe.SelectedItem is not Recipe selectedRecipe)
                {
                    MessageBox.Show("No recipe selected to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                MessageBoxResult result = MessageBox.Show(
                    "Are you sure you want to delete this recipe? This cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    DeleteRecipe(selectedRecipe);
                    MessageBox.Show("Recipe deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting recipe: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            _isNewRecipe = true;
            dgRecipe.SelectedIndex = -1;
            ClearForm();
        }

        private void ClearForm()
        {
            // Clear all textboxes
            txtRecipeId.Clear();
            txtRecipeName.Clear();
            txtSelRefID.Clear();

            // Clear aggregates
            txtAgg1.Clear();
            txtAgg1STP.Clear();
            txtAgg2.Clear();
            txtAgg2STP.Clear();
            txtAgg3.Clear();
            txtAgg3STP.Clear();
            txtAgg4.Clear();
            txtAgg4STP.Clear();

            // Clear cement
            txtCement1.Clear();
            txtCement1STP.Clear();
            txtCement2.Clear();
            txtCement2STP.Clear();
            txtCement3.Clear();
            txtCement3STP.Clear();
            txtCement4.Clear();
            txtCement4STP.Clear();

            // Clear water
            txtWater1.Clear();
            txtWater1STP.Clear();
            txtWater2.Clear();
            txtWater2STP.Clear();

            // Clear admixtures
            txtAdmix1.Clear();
            txtAdmix1STP.Clear();
            txtAdmix2.Clear();
            txtAdmix2STP.Clear();
            txtAdmix3.Clear();
            txtAdmix3STP.Clear();
            txtAdmixNew.Clear();
            txtAdmixNewSTP.Clear();

            // Reset validation borders
            txtRecipeName.BorderBrush = System.Windows.Media.Brushes.Gray;
            txtRecipeName.ToolTip = null;
            btnSave.Content = "Save And Approve";

        }

        private void LoadRecipe()
        {
            try
            {
                var recipe = _context.Recipes.ToList();

                if (recipe != null)
                {
                    dgRecipe.ItemsSource = recipe;
                }
                else
                {
                    MessageBox.Show($"No Recipe found.", "Not Found", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading recipe: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private bool ValidateRecipe()
        {
            List<string> validationErrors = new List<string>();

            // Basic validation
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text))
                validationErrors.Add("Recipe name is required.");

            // At least one aggregate is required
            if (string.IsNullOrWhiteSpace(txtAgg1.Text) && string.IsNullOrWhiteSpace(txtAgg2.Text) &&
                string.IsNullOrWhiteSpace(txtAgg3.Text) && string.IsNullOrWhiteSpace(txtAgg4.Text))
                validationErrors.Add("At least one aggregate is required.");

            // At least one cement is required
            if (string.IsNullOrWhiteSpace(txtCement1.Text) && string.IsNullOrWhiteSpace(txtCement2.Text) &&
                string.IsNullOrWhiteSpace(txtCement3.Text) && string.IsNullOrWhiteSpace(txtCement4.Text))
                validationErrors.Add("At least one cement is required.");

            // At least one water source is required
            if (string.IsNullOrWhiteSpace(txtWater1.Text) && string.IsNullOrWhiteSpace(txtWater2.Text))
                validationErrors.Add("At least one water source is required.");

            // Validate STP values - if name is provided, STP value must also be provided
            if (!string.IsNullOrWhiteSpace(txtAgg1.Text) && string.IsNullOrWhiteSpace(txtAgg1STP.Text))
                validationErrors.Add("STP value is required for Aggregate 1.");

            if (!string.IsNullOrWhiteSpace(txtAgg2.Text) && string.IsNullOrWhiteSpace(txtAgg2STP.Text))
                validationErrors.Add("STP value is required for Aggregate 2.");

            if (!string.IsNullOrWhiteSpace(txtAgg3.Text) && string.IsNullOrWhiteSpace(txtAgg3STP.Text))
                validationErrors.Add("STP value is required for Aggregate 3.");

            if (!string.IsNullOrWhiteSpace(txtAgg4.Text) && string.IsNullOrWhiteSpace(txtAgg4STP.Text))
                validationErrors.Add("STP value is required for Aggregate 4.");

            if (!string.IsNullOrWhiteSpace(txtCement1.Text) && string.IsNullOrWhiteSpace(txtCement1STP.Text))
                validationErrors.Add("STP value is required for Cement 1.");

            if (!string.IsNullOrWhiteSpace(txtCement2.Text) && string.IsNullOrWhiteSpace(txtCement2STP.Text))
                validationErrors.Add("STP value is required for Cement 2.");

            if (!string.IsNullOrWhiteSpace(txtCement3.Text) && string.IsNullOrWhiteSpace(txtCement3STP.Text))
                validationErrors.Add("STP value is required for Cement 3.");

            if (!string.IsNullOrWhiteSpace(txtCement4.Text) && string.IsNullOrWhiteSpace(txtCement4STP.Text))
                validationErrors.Add("STP value is required for Cement 4.");

            if (!string.IsNullOrWhiteSpace(txtWater1.Text) && string.IsNullOrWhiteSpace(txtWater1STP.Text))
                validationErrors.Add("STP value is required for Water 1.");

            if (!string.IsNullOrWhiteSpace(txtWater2.Text) && string.IsNullOrWhiteSpace(txtWater2STP.Text))
                validationErrors.Add("STP value is required for Water 2.");

            if (!string.IsNullOrWhiteSpace(txtAdmix1.Text) && string.IsNullOrWhiteSpace(txtAdmix1STP.Text))
                validationErrors.Add("STP value is required for Admixture 1.");

            if (!string.IsNullOrWhiteSpace(txtAdmix2.Text) && string.IsNullOrWhiteSpace(txtAdmix2STP.Text))
                validationErrors.Add("STP value is required for Admixture 2.");

            if (!string.IsNullOrWhiteSpace(txtAdmix3.Text) && string.IsNullOrWhiteSpace(txtAdmix3STP.Text))
                validationErrors.Add("STP value is required for Admixture 3.");

            if (!string.IsNullOrWhiteSpace(txtAdmixNew.Text) && string.IsNullOrWhiteSpace(txtAdmixNewSTP.Text))
                validationErrors.Add("STP value is required for New Admixture.");

            // Check for numeric validity in STP values
            ValidateNumericField(txtAgg1STP.Text, "Aggregate 1 STP", validationErrors);
            ValidateNumericField(txtAgg2STP.Text, "Aggregate 2 STP", validationErrors);
            ValidateNumericField(txtAgg3STP.Text, "Aggregate 3 STP", validationErrors);
            ValidateNumericField(txtAgg4STP.Text, "Aggregate 4 STP", validationErrors);
            ValidateNumericField(txtCement1STP.Text, "Cement 1 STP", validationErrors);
            ValidateNumericField(txtCement2STP.Text, "Cement 2 STP", validationErrors);
            ValidateNumericField(txtCement3STP.Text, "Cement 3 STP", validationErrors);
            ValidateNumericField(txtCement4STP.Text, "Cement 4 STP", validationErrors);
            ValidateNumericField(txtWater1STP.Text, "Water 1 STP", validationErrors);
            ValidateNumericField(txtWater2STP.Text, "Water 2 STP", validationErrors);
            ValidateNumericField(txtAdmix1STP.Text, "Admixture 1 STP", validationErrors);
            ValidateNumericField(txtAdmix2STP.Text, "Admixture 2 STP", validationErrors);
            ValidateNumericField(txtAdmix3STP.Text, "Admixture 3 STP", validationErrors);
            ValidateNumericField(txtAdmixNewSTP.Text, "New Admixture STP", validationErrors);

            if (validationErrors.Any())
            {
                MessageBox.Show(
                    string.Join("\n", validationErrors),
                    "Validation Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void ValidateNumericField(string value, string fieldName, List<string> errors)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (!double.TryParse(value, out double _))
                {
                    errors.Add($"{fieldName} must be a valid numeric value.");
                }
            }
        }
        private double? TryParseDouble(string input)
        {
            if (double.TryParse(input, out double result))
                return result;
            return null;
        }

        private void SaveRecipe(bool isApproved)
        {
            if (!ValidateRecipe())
                return;

            try
            {
                // Assign values from form to recipe object
                _currentRecipe.Recipename = txtRecipeName.Text.Trim();
                _currentRecipe.SelRefId = txtSelRefID.Text.Trim();

                // Safe assignment helpers
                _currentRecipe.Agg1name = txtAgg1.Text.Trim();
                _currentRecipe.Agg1stp = TryParseDouble(txtAgg1STP.Text);
                _currentRecipe.Agg2name = txtAgg2.Text.Trim();
                _currentRecipe.Agg2stp = TryParseDouble(txtAgg2STP.Text);
                _currentRecipe.Agg3name = txtAgg3.Text.Trim();
                _currentRecipe.Agg3stp = TryParseDouble(txtAgg3STP.Text);
                _currentRecipe.Agg4name = txtAgg4.Text.Trim();
                _currentRecipe.Agg4stp = TryParseDouble(txtAgg4STP.Text);

                _currentRecipe.Cement1name = txtCement1.Text.Trim();
                _currentRecipe.Cement1stp = TryParseDouble(txtCement1STP.Text);
                _currentRecipe.Cement2name = txtCement2.Text.Trim();
                _currentRecipe.Cement2stp = TryParseDouble(txtCement2STP.Text);
                _currentRecipe.Cement3name = txtCement3.Text.Trim();
                _currentRecipe.Cement3stp = TryParseDouble(txtCement3STP.Text);
                _currentRecipe.Cement4name = txtCement4.Text.Trim();
                _currentRecipe.Cement4stp = TryParseDouble(txtCement4STP.Text);

                _currentRecipe.Water1name = txtWater1.Text.Trim();
                _currentRecipe.Water1stp = TryParseDouble(txtWater1STP.Text);
                _currentRecipe.Water2name = txtWater2.Text.Trim();
                _currentRecipe.Water2stp = TryParseDouble(txtWater2STP.Text);

                _currentRecipe.Admix1name = txtAdmix1.Text.Trim();
                _currentRecipe.Admix1stp = TryParseDouble(txtAdmix1STP.Text);
                _currentRecipe.Admix2name = txtAdmix2.Text.Trim();
                _currentRecipe.Admix2stp = TryParseDouble(txtAdmix2STP.Text);
                _currentRecipe.Admix3name = txtAdmix3.Text.Trim();
                _currentRecipe.Admix3stp = TryParseDouble(txtAdmix3STP.Text);
                _currentRecipe.Admixnewname = txtAdmixNew.Text.Trim();
                _currentRecipe.Admixnewstp = TryParseDouble(txtAdmixNewSTP.Text);

                

                _currentRecipe.Updatedate = DateTime.Now;

                // Save to DB
                if (_isNewRecipe)
                {
                    _currentRecipe.Id = RecipeCodeGenerator("REC"); 
                    _context.Recipes.Add(_currentRecipe);
                }
                else
                {
                    _context.Recipes.Update(_currentRecipe);
                }
                _context.SaveChanges();
                RefreshRecipeGrid();
                _isNewRecipe = false;
                txtRecipeId.Text = _currentRecipe.Id;
            }
            catch (DbUpdateException dbEx)
            {
                var inner = dbEx.InnerException?.Message ?? dbEx.Message;
                MessageBox.Show($"Database error:\n{inner}", "DB Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error:\n{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void RefreshRecipeGrid()
        {
            try
            {
                var recipes = _context.Recipes.ToList();
                dgRecipe.ItemsSource = recipes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteRecipe(Recipe recipeToDelete)
        {
            if (recipeToDelete == null || string.IsNullOrWhiteSpace(recipeToDelete.Id))
                return;

            try
            {
                // Check if recipe is referenced
                bool hasRelatedData = _context.Customers.Any(c => c.Customerid.ToString() == recipeToDelete.Id);
                //_context.Ordertables.Any(o => o.RecipeId == recipeToDelete.Id);

                if (hasRelatedData)
                {
                    MessageBox.Show(
                        "This recipe cannot be deleted because it is referenced by existing cycle data or orders.",
                        "Cannot Delete",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var selrecipe = _context.Recipes.SingleOrDefault(r => r.Id == recipeToDelete.Id);

                        if (selrecipe == null)
                        {
                            MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        _context.Recipes.Remove(selrecipe);
                        _context.SaveChanges();
                        transaction.Commit();

                        MessageBox.Show("Recipe deleted successfully.", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Clear selection, reload list, and reset form
                        dgRecipe.SelectedIndex = -1;
                        LoadRecipe(); // reload updated list
                        ClearForm();

                        _currentRecipe = new Recipe
                        {
                            Createdate = DateTime.Now,
                            Updatedate = DateTime.Now
                        };
                        _isNewRecipe = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (DbUpdateException dbEx)
            {
                MessageBox.Show($"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void txtSelRefID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SetEditMode(Recipe recipe)
        {
            if (recipe == null) return;
            _currentRecipe = recipe;
            _isNewRecipe = false;

            txtSelRefID.Text = recipe.SelRefId ?? string.Empty;

            txtRecipeId.Text = recipe.Id ?? string.Empty;
            txtRecipeName.Text = recipe.Recipename ?? string.Empty;

            txtAgg1.Text = recipe.Agg1name ?? string.Empty;
            txtAgg1STP.Text = recipe.Agg1stp?.ToString() ?? string.Empty;

            txtAgg2.Text = recipe.Agg2name ?? string.Empty;
            txtAgg2STP.Text = recipe.Agg2stp?.ToString() ?? string.Empty;

            txtAgg3.Text = recipe.Agg3name ?? string.Empty;
            txtAgg3STP.Text = recipe.Agg3stp?.ToString() ?? string.Empty;

            txtAgg4.Text = recipe.Agg4name ?? string.Empty;
            txtAgg4STP.Text = recipe.Agg4stp?.ToString() ?? string.Empty;

            txtCement1.Text = recipe.Cement1name ?? string.Empty;
            txtCement1STP.Text = recipe.Cement1stp?.ToString() ?? string.Empty;

            txtCement2.Text = recipe.Cement2name ?? string.Empty;
            txtCement2STP.Text = recipe.Cement2stp?.ToString() ?? string.Empty;

            txtCement3.Text = recipe.Cement3name ?? string.Empty;
            txtCement3STP.Text = recipe.Cement3stp?.ToString() ?? string.Empty;

            txtCement4.Text = recipe.Cement4name ?? string.Empty;
            txtCement4STP.Text = recipe.Cement4stp?.ToString() ?? string.Empty;

            txtWater1.Text = recipe.Water1name ?? string.Empty;
            txtWater1STP.Text = recipe.Water1stp?.ToString() ?? string.Empty;

            txtWater2.Text = recipe.Water2name ?? string.Empty;
            txtWater2STP.Text = recipe.Water2stp?.ToString() ?? string.Empty;

            txtAdmix1.Text = recipe.Admix1name ?? string.Empty;
            txtAdmix1STP.Text = recipe.Admix1stp?.ToString() ?? string.Empty;

            txtAdmix2.Text = recipe.Admix2name ?? string.Empty;
            txtAdmix2STP.Text = recipe.Admix2stp?.ToString() ?? string.Empty;

            txtAdmix3.Text = recipe.Admix3name ?? string.Empty;
            txtAdmix3STP.Text = recipe.Admix3stp?.ToString() ?? string.Empty;

            txtAdmixNew.Text = recipe.Admixnewname ?? string.Empty;
            txtAdmixNewSTP.Text = recipe.Admixnewstp?.ToString() ?? string.Empty;
        }


        private void dgRecipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnSave.Content = "Update And Approve";

            if (dgRecipe.SelectedItem is Recipe selectedRecipe)
            {
                SetEditMode(selectedRecipe);
            }
        }
    }
}

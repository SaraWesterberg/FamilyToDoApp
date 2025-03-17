using FamilyToDoApp.ViewModel; 
using Microsoft.Maui.Controls;

namespace FamilyToDoApp 
{
    public partial class ShoppingListPage : ContentPage
    {
        private ShoppingListViewModel _viewModel;

        public ShoppingListPage()
        {
            InitializeComponent(); 
            _viewModel = new ShoppingListViewModel();
            BindingContext = _viewModel;
        }

        private void OnAddItemClicked(object sender, EventArgs e)
        {
            _viewModel.AddItem();
        }

        private void OnRemoveItemClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is string item)
            {
                _viewModel.RemoveItem(item);
            }
        }
    } 
}

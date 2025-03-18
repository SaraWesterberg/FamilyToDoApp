using FamilyToDoApp.Model;
using FamilyToDoApp.ViewModel;
using System.Threading.Tasks;

namespace FamilyToDoApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _mainViewModel;

        public MainPage()
        {
             InitializeComponent();
            _mainViewModel = new MainViewModel();
            BindingContext = _mainViewModel;
            
        }

       
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _mainViewModel.StopTimer();
            
        }

      

        private async void OnGoToShoppingListClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new ShoppingListPage());
        }

        private async void OnFamilyMemberTapped(object sender, TappedEventArgs e)
        {
            if (sender is StackLayout stackLayout && stackLayout.BindingContext is FamilyMember selectedMember)
            {
    
                await Navigation.PushAsync(new FamilyMemberPage(selectedMember));
            }
        }

        private async void OnGoToBackpackListClicked(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new BackpackListPage());
        }
    }

}

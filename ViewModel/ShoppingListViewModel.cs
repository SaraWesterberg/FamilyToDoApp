using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;

namespace FamilyToDoApp.ViewModel 
{
    public class ShoppingListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static ShoppingListViewModel _instance;

        public ShoppingListViewModel()
        {
            ShoppingItems = new ObservableCollection<string>();
            LoadShoppingList();
        }

        public static ShoppingListViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ShoppingListViewModel();
                }
                return _instance;
            }
        }
        public ObservableCollection<string> ShoppingItems { get; set; }

        private string _newItem;
        public string NewItem
        {
            get { return _newItem; }
            set
            {
                _newItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewItem)));
            }
        }

      
        private const string ShoppingListKey = "ShoppingList";

        public void AddItem()
        {
            if (!string.IsNullOrWhiteSpace(NewItem))
            {
                ShoppingItems.Add(NewItem);
                NewItem = string.Empty;
                SaveShoppingList();
            }
        }

        public void RemoveItem(string item)
        {
            ShoppingItems.Remove(item);
            SaveShoppingList();
        }

        private void SaveShoppingList()
        {
            var json = JsonSerializer.Serialize(ShoppingItems);
            Preferences.Set(ShoppingListKey, json);
        }

        private void LoadShoppingList()
        {
            if (Preferences.ContainsKey(ShoppingListKey))
            {
                var json = Preferences.Get(ShoppingListKey, string.Empty);
                var savedItems = JsonSerializer.Deserialize<ObservableCollection<string>>(json);
                if(savedItems != null)
                {
                    foreach(var item in savedItems)
                    {
                        ShoppingItems.Add(item);
                    }
                }            
            }
        }
    }
}

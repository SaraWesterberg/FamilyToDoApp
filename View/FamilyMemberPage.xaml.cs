using FamilyToDoApp.Model;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace FamilyToDoApp
{
    public partial class FamilyMemberPage : ContentPage
    {
        private FamilyMember _familyMember;
        public ObservableCollection<string> Tasks { get; set; }

        public FamilyMemberPage(FamilyMember familyMember)
        {
            InitializeComponent();
            _familyMember = familyMember;
            Title = _familyMember.Name;

            // Ladda uppgifter från Preferences
            Tasks = LoadTasks();
            BindingContext = this; // Bind data till hela sidan
        }

        // När knappen för att lägga till en uppgift trycks
        private void OnAddTaskClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskEntry.Text))
            {
                Tasks.Add(TaskEntry.Text);
                SaveTasks();
                TaskEntry.Text = string.Empty;
            }
        }

        // Ladda uppgifter från Preferences
        private ObservableCollection<string> LoadTasks()
        {
            string key = $"tasks_{_familyMember.Name}";
            var savedTasks = Preferences.Get(key, string.Empty);
            return new ObservableCollection<string>(savedTasks.Split('|').Where(t => !string.IsNullOrEmpty(t)));
        }

        // Spara uppgifter till Preferences
        private void SaveTasks()
        {
            string key = $"tasks_{_familyMember.Name}";
            Preferences.Set(key, string.Join("|", Tasks));
        }
    }
}

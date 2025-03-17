using FamilyToDoApp.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Timers;
using System.Threading.Tasks;

namespace FamilyToDoApp.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Listan på familjemedlemmar
        public ObservableCollection<FamilyMember> FamilyMembers { get; set; }

        private string _currentDateTime;
        public string CurrentDateTime
        {
            get { return _currentDateTime; }
            set
            {
                if (_currentDateTime != value)
                {
                    _currentDateTime = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentDateTime)));
                }
            }
        }


        // Timer för att uppdatera klockan
        private System.Timers.Timer _timer;


        public MainViewModel()
        {
            

            // Här initialiseras familjemedlemmarna
            FamilyMembers = new ObservableCollection<FamilyMember>
            {
                new FamilyMember { Name = "Harry", Image = "harry.png", FrameColor = Colors.CornflowerBlue },
                new FamilyMember { Name = "Lily", Image = "lily.png", FrameColor = Colors.LightPink },
                new FamilyMember { Name = "Frans", Image = "frans.png", FrameColor = Colors.PaleGreen }
            };

            // Skapa och starta timern
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += UpdateTime;
            _timer.Start();

            CurrentDateTime = DateTime.Now.ToString("dddd, HH:mm");

        }

        private void UpdateTime(object sender, ElapsedEventArgs e)
        {
            var dayOfWeek = DateTime.Now.ToString("dddd");
            var formattedDay = char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1).ToLower(); // Gör första bokstaven stor

            // Uppdatera klockan varje sekund
            CurrentDateTime = formattedDay + ", " + DateTime.Now.ToString("HH:mm");
        }

        // Stänger av timern när den inte längre behövs
        public void StopTimer()
        {
            _timer?.Stop();
            _timer?.Dispose();
        }
    }
}

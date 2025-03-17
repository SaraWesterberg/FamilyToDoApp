using FamilyToDoApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyToDoApp.ViewModel
{
    public class ToDoListViewModel
    {
        public event PropertyChangingEventHandler PropertyChanged;

        public ObservableCollection<ToDoTask> Tasks { get; set; }

        private string _newTask;
        public string NewTask
        {
            get { return _newTask; }
            set
            {
                _newTask = value;
                PropertyChanged?.Invoke(this, new PropertyChangingEventArgs(nameof(NewTask)));
            }
        }

        public ToDoListViewModel()
        {
            Tasks = new ObservableCollection<ToDoTask>();
        }

        public void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTask))
            {
                Tasks.Add(new ToDoTask { Description = NewTask, IsDone = false });
                NewTask = string.Empty;
            }
        }
    }
}

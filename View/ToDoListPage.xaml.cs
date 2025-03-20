using FamilyToDoApp.Model;
using FamilyToDoApp.ViewModel;
using Microsoft.Maui.Controls;

namespace FamilyToDoApp;

public partial class ToDoListPage : ContentPage
{

	private ToDoListViewModel _viewModel;
	public ToDoListPage()
	{
		InitializeComponent();
		_viewModel = new ToDoListViewModel();
		BindingContext = _viewModel;
	}

    private void OnAddTaskClicked(object sender, EventArgs e)
    {
		_viewModel.AddTask();
    }

    private void OnRemoveTaskClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is ToDoTask task)
        {
            _viewModel.RemoveTask(task); 
        }
    }
}
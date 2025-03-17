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
}
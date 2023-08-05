using ProjectPanther.MAUI.ViewModels;

namespace ProjectPanther.MAUI.Views;

public partial class EmployeeView : ContentPage
{
	public EmployeeView()
	{
		InitializeComponent();

		BindingContext = new EmployeeViewModel();
	}

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as EmployeeViewModel).Search();
    }

    private void SearchClick(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).Search();
    }

    private void ReturnClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddEmployeeView");
    }

    private void EditClick(object sender, EventArgs e)
    {
        var employeeId = (BindingContext as EmployeeViewModel)?.SelectedEmployee?.Id ?? 0;
        if (employeeId != 0)
        {
            Shell.Current.GoToAsync($"//AddEmployeeView?employeeId={employeeId}");

        }
    }

    private void DeleteClick(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).Delete();
    }
}
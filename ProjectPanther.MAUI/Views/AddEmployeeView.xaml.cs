using ProjectPanther.MAUI.ViewModels;

namespace ProjectPanther.MAUI.Views;


[QueryProperty("EmployeeId", "employeeId")]
public partial class AddEmployeeView : ContentPage
{
    public int EmployeeId { get; set; }

	public AddEmployeeView()
	{
		InitializeComponent();
	}

    private void ReturnClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EmployeeView");
    }

    private void SubmitClick(object sender, EventArgs e)
    {
        (BindingContext as AddEmployeeViewModel).Add();
        Shell.Current.GoToAsync("//EmployeeView");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddEmployeeViewModel(EmployeeId);
    }
}
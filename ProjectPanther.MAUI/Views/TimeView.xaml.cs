using ProjectPanther.MAUI.ViewModels;

namespace ProjectPanther.MAUI.Views;

public partial class TimeView : ContentPage
{
	public TimeView()
	{
		InitializeComponent();

    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeViewModel();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddTimeView");

    }

    private void EditClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddTimeView");

    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).Delete();
    }

    private void SearchClicked(object sender, EventArgs e)
    {

    }
}
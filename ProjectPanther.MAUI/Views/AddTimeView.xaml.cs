using ProjectPanther.Library.Models;
using ProjectPanther.MAUI.ViewModels;

namespace ProjectPanther.MAUI.Views;

public partial class AddTimeView : ContentPage
{
    public Time Model { get; set; }


    public AddTimeView()
	{
		InitializeComponent();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//TimeView");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if(Model == null)
        {
            BindingContext = new TimeViewModel();
        }
        else
        {
            BindingContext = new TimeViewModel();
        }
    }

    private void SubmitClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//TimeView");
    }
}
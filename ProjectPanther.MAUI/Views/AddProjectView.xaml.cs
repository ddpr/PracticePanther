using PracticeManagement.Library.Models;
using ProjectPanther.MAUI.ViewModels;

namespace ProjectPanther.MAUI.Views;

[QueryProperty("ClientId", "clientId")]
[QueryProperty("ProjectId", "projectId")]
[QueryProperty("NewProj", "newProj")]

public partial class AddProjectView : ContentPage
{
	public int ClientId { get; set; }
    public int ProjectId { get; set; }
    public bool NewProj { get; set; }
	public AddProjectView()
	{
		InitializeComponent();
	}

    private void ReturnClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//AddClientView?clientId={ClientId}");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if (NewProj)
        {
            BindingContext = new AddProjectViewModel(ClientId,NewProj);
        }
        else
        {
            BindingContext = new AddProjectViewModel(ClientId,ProjectId);
        }
    }

    private void SubmitClicked(object sender, EventArgs e)
    {
        (BindingContext as AddProjectViewModel).Add();
        Shell.Current.GoToAsync($"//AddClientView?clientId={ClientId}");
    }
}
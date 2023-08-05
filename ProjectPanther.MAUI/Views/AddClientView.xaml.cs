using PracticeManagement.Library.Models;
using ProjectPanther.MAUI.ViewModels;

namespace ProjectPanther.MAUI.Views;

[QueryProperty("ClientId", "clientId")]
public partial class AddClientView : ContentPage
{
    public int ClientId { get; set; }
	public AddClientView()
	{
		InitializeComponent();
	}

    private void ReturnClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientView");
    }

    private void SubmitClicked(object sender, EventArgs e)
    {
        (BindingContext as AddClientViewModel).Add();
        Shell.Current.GoToAsync("//ClientView");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddClientViewModel(ClientId);
        //(BindingContext as AddClientViewModel).Search();
    }

    private void ProjectDeleteClick(object sender, EventArgs e)
    {
        (BindingContext as AddClientViewModel).DeleteProject();
    }

    private void AddProjectClick(object sender, EventArgs e)
    {
        var clientId = (BindingContext as AddClientViewModel)?.Model?.Id ?? 0;
        if(clientId != 0)
        {
            var newProj = true;
            Shell.Current.GoToAsync($"//AddProjectView?newProj={newProj}&clientId={clientId}");
        }
    }

    private void EditProjectClick(object sender, EventArgs e)
    {
        var clientId = (BindingContext as AddClientViewModel)?.Model?.Id ?? 0;
        var projectId = (BindingContext as AddClientViewModel)?.SelectedProject?.Id ?? 0;
        if (clientId != 0 && projectId != 0)
        {
            var newProj = false;
            Shell.Current.GoToAsync($"//AddProjectView?newProj={newProj}&clientId={clientId}&projectId={projectId}");
        }
    }
}
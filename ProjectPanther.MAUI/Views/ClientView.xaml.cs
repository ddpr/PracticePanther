using ProjectPanther.MAUI.ViewModels;

namespace ProjectPanther.MAUI.Views
{
    public partial class ClientView : ContentPage
    {

        public ClientView()
        {
            InitializeComponent();
            //MyTextBox.Text = "Hello, World";
            BindingContext = new ClientViewModel();
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            (BindingContext as ClientViewModel).Delete();
        }

        private void SearchClick(object sender, EventArgs e)
        {
            (BindingContext as ClientViewModel).Search();
        }

        private void AddClick(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//AddClientView");
        }

        private void EditClick(object sender, EventArgs e)
        {
            var clientId = (BindingContext as ClientViewModel)?.SelectedClient?.Id ?? 0;
            if(clientId != 0)
            {
                Shell.Current.GoToAsync($"//AddClientView?clientId={clientId}");

            }
        }

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            (BindingContext as ClientViewModel).Search();
        }

        private void ReturnClick(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MainPage");

        }
    }
}
using ProjectPanther.MAUI.ViewModels;

namespace ProjectPanther.MAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            //MyTextBox.Text = "Hello, World";
        }


        private void ClientsClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//ClientView");
        }
        private void EmployeeClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//EmployeeView");
        }

        private void TimeClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//TimeView");
        }


    }
}
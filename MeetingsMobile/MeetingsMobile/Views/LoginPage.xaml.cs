
using MeetingsMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeetingsMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginViewModel login;
		
		public LoginPage ()
		{
			InitializeComponent ();
			login = new LoginViewModel();
			BindingContext = login;
		}

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await login.LoginAsync();
            if (Helpers.Settings.IsLoggedIn) {
                
                //felipe
                await ((NavigationPage)this.Parent).PushAsync(new AboutPage(),true);
                //fin felipe
            }
        }
    }
}
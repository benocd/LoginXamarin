using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeetingsMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			InitializeComponent ();
		}

        public void LogOutBtn() {
            Helpers.Settings.LogOut();
            ((NavigationPage)this.Parent).PushAsync(new LoginPage(), true);
        }
	}
}
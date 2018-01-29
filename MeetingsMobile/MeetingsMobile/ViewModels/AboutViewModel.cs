using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace MeetingsMobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
            //LogOut = new Command(() => Helpers.Settings.LogOut());
        }

        public ICommand OpenWebCommand { get; }
        //public ICommand LogOut { get; }

    }
}
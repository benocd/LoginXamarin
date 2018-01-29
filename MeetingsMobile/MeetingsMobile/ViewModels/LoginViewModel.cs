using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MeetingsMobile.Models;
using MeetingsMobile.Helpers;
using MeetingsMobile.Services;
using System.Threading.Tasks;

namespace MeetingsMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; set; }

        private AuthService login;
        public string Name
        {
            get
            {
                return Settings.UserName;
            }
        }
        private string _username;
        public string username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        // service
        public LoginViewModel()
        {
            // se logeo
            Settings.UserName= "PEPE";
            login = new AuthService();
            //servicio(username, password);
            LoginCommand = new Command(async () => await ExecuteLoginCommand());


        }


        async Task ExecuteLoginCommand()
        {
            

            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var res = await login.Authenticate(username, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task LoginAsync()
        {
            IsBusy = true;

            //var ctx = new ServiceContext<bool>();

            try
            {
                var isAuthenticated = await login.Authenticate(username, password);
                if (isAuthenticated)
                {
                    //ResultAsync = true;
                   
                    Settings.UserName = username; 

                     /*await userViewModel.GetScaffoldUserAsync(WorkingVariables.Token.UserId);
                    _deviceViewModel.RegisterDevice();
                     Application.Current.MainPage = new MainContentMDP();*/
                }
                else
                {
                   /*
                    * ResultAsync = false;
                    *  LoginError = !ResultAsync;
                    */
                }
            }
            catch (Exception ex)
            {
            }

            IsBusy = false;
        }
    }
}

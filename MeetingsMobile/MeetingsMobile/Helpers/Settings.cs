using MeetingsMobile.Views;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

namespace MeetingsMobile.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string GeneralSettings
        {
            get => AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }
        public static string UserToken
        {
            get => AppSettings.GetValueOrDefault(nameof(UserToken), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserToken), value);
        }

        public static bool IsLoggedIn {
            get => AppSettings.GetValueOrDefault(nameof(IsLoggedIn), false);
            set => AppSettings.AddOrUpdateValue(nameof(IsLoggedIn), value);
        } 

        public static void LogOut() {
            AppSettings.Clear();
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;

namespace MeetingsMobile.Services
{
    public class ServiceUrls
    {
        private static string UrlBase()
        {
            return "http://identityindustry.azurewebsites.net";
        }

        public static string LoginUrl()
        {
            return UrlBase() + "/Connect/Token";
        }
    }
}
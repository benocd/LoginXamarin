using MeetingsMobile.Helpers;
using MeetingsMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsMobile.Services
{
    public class AuthService 
    {
        public async Task<bool> Authenticate(string user, string pass)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                var requestParams = new List<KeyValuePair<string, string>>() { 
                    new KeyValuePair<string, string>("client_id", "UserClient"),
                    new KeyValuePair<string, string>("client_secret", "usersecret"),
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", user),
                    new KeyValuePair<string, string>("password", pass),

                };

                var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                var tokenServiceResponse = await client.PostAsync(ServiceUrls.LoginUrl(), requestParamsFormUrlEncoded);
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                var responseCode = tokenServiceResponse.StatusCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    var newToken = JsonConvert.DeserializeObject<AuthToken>(responseString);
                    if (newToken != null)
                    {
                        WorkingVariables.Token = newToken;
                        //WorkingVariables.SetRoles(newToken.Roles);
                    }
                }
                return (responseCode == HttpStatusCode.OK);
            }
        }
    }
}

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
    public class ServiceContext<T>
    {

        public async Task<T> Get(string serviceUrl)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WorkingVariables.Token.access_token);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(serviceUrl);
                if (response.IsSuccessStatusCode)
                {
                    var objectResponse = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    return objectResponse;
                }
                try
                {
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                    return default(T);
                }
            }
        }

        public async Task<List<T>> GetAll(string serviceUrl)
        {
            if (WorkingVariables.Token == null) return null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WorkingVariables.Token.access_token);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(serviceUrl);
                if (response.IsSuccessStatusCode)
                {
                    //var objectResponse = (object)JsonConvert.DeserializeObject<T>(task.Result.Content.ReadAsStringAsync());
                    var responseString = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var plants = JsonConvert.DeserializeObject<List<T>>(responseString);
                        var returnObj = (object)plants;
                        return (List<T>)returnObj;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                        throw;
                    }
                }
                return null;
            }
        }

        internal Task Authenticate(object email, object password)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Post(string serviceUrl, object obj)
        {
            if (WorkingVariables.Token == null) return default(T);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WorkingVariables.Token.access_token);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = JsonConvert.SerializeObject(obj);
                var response = await client.PostAsync(serviceUrl, new StringContent(content, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var objectResponse = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    return objectResponse;
                }
                return default(T);
            }
        }

        public async Task<T> Put(string serviceUrl, object obj)
        {
            if (WorkingVariables.Token == null) return default(T);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WorkingVariables.Token.access_token);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = JsonConvert.SerializeObject(obj);
                var response = await client.PutAsync(serviceUrl, new StringContent(content, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var objectResponse = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    return objectResponse;
                }
                return default(T);
            }
        }

        public async Task<T> Delete(string serviceUrl)
        {
            if (WorkingVariables.Token == null) return default(T);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WorkingVariables.Token.access_token);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.DeleteAsync(serviceUrl);
                if (response.IsSuccessStatusCode)
                {
                    var objectResponse = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    return objectResponse;
                }
                return default(T);
            }
        }

        public async Task<T> Patch(string serviceUrl, List<object> model)
        {
            if (WorkingVariables.Token == null) return default(T);
            using (var client = new HttpClient())
            {
                var method = new HttpMethod("PATCH");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WorkingVariables.Token.access_token);
                client.DefaultRequestHeaders.Accept.Clear();
                string stringData = JsonConvert.SerializeObject(model);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json-patch+json");
                var request = new HttpRequestMessage(method, serviceUrl)
                {
                    Content = contentData,
                };
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var objectResponse = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    return objectResponse;
                }
                return default(T);
            }
        }
    }

}

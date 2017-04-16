using KosanCrisTrips.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace KosanCrisTrips.Web.Utilities
{
    public class WebApiClientUtility
    {
        public static string APIUrl = "http://183.82.63.139/api/";
        public static async Task<T> Get<T>(string relativeUrl, List<KeyValuePair<string, string>> parameters)
        {
            T result = default(T);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(WebApiClientUtility.APIUrl + relativeUrl);
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpBody"></param>
        /// <param name="parameters"></param>
        /// <param name="param0">User Id</param>
        /// <param name="param1"> Name of the method.</param>
        /// <param name="param2-N">Any required params as necessary.</param>
        /// <returns></returns>
        public static async Task<ApiResponse> Post<T>(string relativeUrl,object httpBody,params object[] parameters)
        {
            T postObject = (T)httpBody;
            HttpResponseMessage response = null;
            ApiResponse apiResponse = null;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("UserId", parameters[0]?.ToString());
                client.DefaultRequestHeaders.Add("Method", parameters[1]?.ToString());
                //if (parameters != null && parameters.Count() > 1)
                //{
                //    foreach (var item in parameters)
                //    {

                //    }
                //}
                response = client.PostAsJsonAsync<T>(APIUrl + relativeUrl, postObject).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseJsonString = response.Content.ReadAsStringAsync();
                    apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseJsonString.Result);

                }
            }

            return apiResponse;
        }
        public static async Task<T> Post<T>(string relativeUrl, List<KeyValuePair<string, string>> parameters)
        {

            //string url = "http://myserver/method";
            //string content = "param1=1&param2=2";
            //HttpClientHandler handler = new HttpClientHandler();
            //HttpClient httpClient = new HttpClient(handler);
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            //HttpResponseMessage response = await httpClient.SendAsync(request, content);

            string content = "username=test&password=test";
            //var formContent = new FormUrlEncodedContent(parameters);

            T result = default(T);
            using (HttpClient client = new HttpClient())
            {
                if (parameters != null && parameters.Any())
                {
                    foreach (var param in parameters)
                    {
                        client.DefaultRequestHeaders.Add(param.Key, param.Value);
                    }
                }

                //HttpResponseMessage response = await client.PostAsync(APIUrl + relativeUrl, formContent);
            }

            return result;
        }
    }
}
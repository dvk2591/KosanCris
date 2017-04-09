using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace KosanCrisTrips.Web.Utilities
{
    public class WebApiClientUtility
    {
        public static async Task<T> Get<T>(List<KeyValuePair<string,string>> parameters)
        {
            T result = default(T);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("");
            }

            return result;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyShopify
{
    public class Shopify
    {
        static HttpClient client = new HttpClient();
        public string Url { get; }

        public Shopify(String token, String password, String domain)
        {
            Url = string.Concat("https://", token, ":", password, "@", domain, ".myshopify.com/admin/");
            client.DefaultRequestHeaders.Add("X-Shopify-Access-Token", password);
        }

        private Object ProcessResults(String content) {
            Object ret_json;
            try
            {
                ret_json = JsonConvert.DeserializeObject(content);
            }
            catch (Exception)
            {
                return content;
            }

            return ret_json;
        }

        public async Task<Object> Get(String endpoint, List<KeyValuePair<string, string>> data = null)
        {
            if (data != null)
            {
                endpoint += "?";

                foreach (KeyValuePair<string, string> dict in data)
                {
                    endpoint += dict.Key + "=" + dict.Value + "&";
                }
            }

            HttpResponseMessage response = await client.GetAsync(new UriBuilder(this.Url + endpoint).ToString());

            return ProcessResults(await response.Content.ReadAsStringAsync());
        }

        public async Task<Object> Post(String endpoint, String data)
        {
            var product = new StringContent(
                    data,
                    Encoding.UTF8,
                "application/json");
            
            var response = await client.PostAsync(new UriBuilder(this.Url + endpoint).ToString(), product);

            return ProcessResults(await response.Content.ReadAsStringAsync());
        }

        public async Task<Object> Put(String endpoint, String data)
        {
            var product = new StringContent(
                    data,
                    Encoding.UTF8,
                    "application/json");

            var response = await client.PutAsync(new UriBuilder(this.Url + endpoint).ToString(), product);

            return ProcessResults(await response.Content.ReadAsStringAsync());
        }

        public async Task<Object> Delete(String endpoint)
        {
            var response = await client.DeleteAsync(new UriBuilder(this.Url + endpoint).ToString());

            return ProcessResults(await response.Content.ReadAsStringAsync());
        }

    }
}

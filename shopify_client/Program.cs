using MyShopify;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shopify_client
{
    class MainClass
    {
        public static async Task<object> getShop()
        {
            Shopify s = new Shopify("f53db014d644405dbea1dca767167039", "bd3ab6592ef0208b0e6edc037baaf733", "fuck-the-winter");

            var res = await s.Get("shop.json").ConfigureAwait(true);

            return res;
        }

        public static async Task<object> getProduct()
        {
            Shopify s = new Shopify("f53db014d644405dbea1dca767167039", "bd3ab6592ef0208b0e6edc037baaf733", "fuck-the-winter");

            var arg = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("limit", "1")
            };

            var res = await s.Get("products.json", arg).ConfigureAwait(true);

            return res;
        }

        public static async Task<object> createProduct()
        {
            Shopify s = new Shopify("f53db014d644405dbea1dca767167039", "bd3ab6592ef0208b0e6edc037baaf733", "fuck-the-winter");

            Dictionary<string, string> param = new Dictionary<string, string>
            {
                    {"title", "Burton Custom Freestyle 151"},
                    {"body_html", "<strong>Great snowboard</strong>"},
                    {"vendor", "Burton"},
                    {"product_type", "Snowboard"},
                    {"tags", "Barnes & Noble, John's Fav, Big Air"}
            };

            Dictionary<string, Dictionary<string, string>> product = new Dictionary<string, Dictionary<string, string>>
            {
                {"product", param}
            };

            var res = await s.Post("products.json", JsonConvert.SerializeObject(product)).ConfigureAwait(true);

            return res;
        }

        public static async Task<object> deleteProduct()
        {
            Shopify s = new Shopify("f53db014d644405dbea1dca767167039", "bd3ab6592ef0208b0e6edc037baaf733", "fuck-the-winter");
            var res = await s.Delete("products/314329530417.json");

            return res;
        }

        public static async Task<object> putProduct()
        {
            Shopify s = new Shopify("f53db014d644405dbea1dca767167039", "bd3ab6592ef0208b0e6edc037baaf733", "fuck-the-winter");

            Dictionary<string, string> param = new Dictionary<string, string>
            {
                    {"title", "Really good snowboard"},
                    {"body_html", "<strong>Great snowboard</strong>"},
                    {"vendor", "Twitch"},
                    {"product_type", "Twitch Snowbaord"},
                    {"tags", "Barnes & Noble, John's Fav, Big Air"}
            };

            Dictionary<string, Dictionary<string, string>> product = new Dictionary<string, Dictionary<string, string>>
            {
                {"product", param}
            };

            var res = await s.Put("products/314329923633.json", JsonConvert.SerializeObject(product)).ConfigureAwait(true);

            return res;
        }

        static async Task Main(string[] args)
        {
            // Console.WriteLine(await getShop());
            // Console.WriteLine(await getProduct());
            // Console.WriteLine(await createProduct());
            // Console.WriteLine(await deleteProduct());
            // Console.WriteLine(await putProduct());
            Console.ReadLine();
        }
    }
}

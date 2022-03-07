using MigraineTrackingApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MigraineTrackingApp.Services
{
    public class OpenFoodFacts
    {
        string url = "https://world.openfoodfacts.org/api/v0/product/";
        HttpClient _client;

        public OpenFoodFacts()
        {
            _client = new HttpClient();
        }
        public async Task<string> getFoodNameFromBarcode(string barcode)
        {
            try
            {
                string query = url + barcode;
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Product product = JsonConvert.DeserializeObject<Product>(content);
                    string productName = product.foodDetails.ProductName;
                    query = "";
                    return productName;
                }
            }
            catch (Exception ex)
            {
                return "Could Not Scan Item!, Please Try Again Or Enter Product Manually On Previous Screen";
            }

            //return weatherData;
            return "";
        }
    }
}

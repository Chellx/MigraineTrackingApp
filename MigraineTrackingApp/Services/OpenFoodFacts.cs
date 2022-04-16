/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

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
        string[] foodDetails = new string[2];

        public OpenFoodFacts()
        {
            _client = new HttpClient();
        }
        public async Task<string[]> getFoodNameFromBarcode(string barcode)
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
                    string allergens = product.foodDetails.Allergens;
                    foodDetails[0] = productName;
                    foodDetails[1] = allergens;
                    query = "";
                    return foodDetails;
                }
            }
            catch (Exception ex)
            {
                foodDetails[0] = "Could Not Scan Item!, Please Try Again Or Enter Product Manually On Previous Screen";
                return foodDetails;
            }

            //return foodData;
            return null;
        }
    }
}

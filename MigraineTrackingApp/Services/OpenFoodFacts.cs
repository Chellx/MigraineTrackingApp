/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 18/4/2022
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
    /// <summary>
    /// this class accesses the openfoodfacts API through Http requests
    /// </summary>
    public class OpenFoodFacts
    {
        string url = "https://world.openfoodfacts.org/api/v0/product/";
        HttpClient _client;
        string[] foodDetails = new string[2];

        /// <summary>
        /// this creates instance of http client
        /// </summary>
        public OpenFoodFacts()
        {
            _client = new HttpClient();
        }
        /// <summary>
        /// this method takes in a barcode as a string attaches to the openfoodfacts url, sends the string in a query to openfoodfacts
        /// gets response if 200 will deserialise JSON response and stores in models
        /// if 400 response fails
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public async Task<string[]> getFoodNameFromBarcode(string barcode)
        {
            try
            {
                string query = url + barcode;
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync(); //gets back JSON object from openfoodfacts
                    Product product = JsonConvert.DeserializeObject<Product>(content); //formats JSON object
                    string productName = product.foodDetails.ProductName; //find product name from JSON object
                    string allergens = product.foodDetails.Allergens; // find allergen list from JSON object
                    foodDetails[0] = productName;
                    foodDetails[1] = allergens;
                    query = "";
                    return foodDetails;
                }
            }
            catch (Exception ex) // if bad response 
            {
                foodDetails[0] = "Could Not Scan Item!, Please Try Again Or Enter Product Manually On Previous Screen";
                return foodDetails;
            }

            //return foodData;
            return null;
        }
    }
}

/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu 
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Intro
{
    class Parsing {
        public static void Demo() {
            // You can also open the URL in a browser to see the JSON data interpreted by the browser. 
            String URL = "https://developer.nps.gov/api/v1/alerts?parkCode=grsm&api_key=pfJKDXPzTykVL73ehnPyY8pkDQLjfq5cz5LqCkl3";
            // This URL will return {"total":"1","data":[{"title":"Road Closures Due to Weather Conditions","id":"4BC5C336-E9F3-EE6B-0BE8C1EB8C44B9FD","description":"Weather and road conditions can vary greatly in different elevations. Go to https:\/\/twitter.com\/smokiesroadsnps for the latest road and facility closures.","category":"Information","url":"https:\/\/twitter.com\/smokiesroadsnps","parkCode":"grsm"}],"limit":"50","start":"1"}
            var client = new WebClient();
            var jsonString = client.DownloadString(URL);
            Print(jsonString);
            Traverse(jsonString);
        }
        /// <summary>
        /// Print the contents of the JSON string using the names of the keys.
        /// This is an effective approach if I know the names of the keys and the underlying structure contained in the string
        /// </summary>
        /// <param name="jsonString"></param>
        private static void Print(string jsonString) {
            Console.WriteLine("Printing the JSON String by key...");
            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            Console.WriteLine("total = " + values["total"]);
            JArray data = (JArray)values["data"];
            // data is an array (also called a list in JSON parlance) of dictionaries (also called JObjects in NewtonSoft) of length 0 or more. 
            // We can iterate over the elements of the array as individual dictionaries
            foreach (JObject jObject in data) {
                Console.WriteLine("title = " + jObject["title"]);
                Console.WriteLine("id = " + jObject["id"]);
                Console.WriteLine("description = " + jObject["description"]);
                Console.WriteLine("category = " + jObject["category"]);
                Console.WriteLine("url = " + jObject["url"]);
                Console.WriteLine("parkCode = " + jObject["parkCode"]);
            }
            Console.WriteLine("limit = " + values["limit"]);
            Console.WriteLine("start = " + values["start"]);
        }
        /// <summary>
        /// We can walk through a JSON string without knowing the keys or the values.
        /// This is an effective approach if I have a JSON string and I don't know the structure
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        private static void Traverse(string jsonString) {
            Console.WriteLine("Traversing the JSON String...");
            // https://stackoverflow.com/questions/1207731/how-can-i-deserialize-json-to-a-simple-dictionarystring-string-in-asp-net
            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            var values2 = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> d in values) {
                // if (d.Value.GetType().FullName.Contains("Newtonsoft.Json.Linq.JObject"))
                Console.WriteLine("Value is of type " + d.Value.GetType());
                if (d.Value is JArray) {
                    foreach (Object o in (JArray)d.Value) {
                        Traverse(o.ToString());
                    }
                }
                else if (d.Value is JObject) {
                    Traverse(d.Value.ToString());
                } else {
                    Console.WriteLine("Found Key/value pair: " + d.Key.ToString() + ":" + d.Value.ToString());
                }
            }
        }
    }
}

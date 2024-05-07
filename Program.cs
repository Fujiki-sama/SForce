namespace Weather_of_Tbilisi__API_
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net.Http;

    namespace Weather_of_Tbilisi__API_
    {
        public class Program
        {
            static void Main(string[] args)
            {
                // My API Key: fa3871e648f64a0a978a7bc78d9c35c1 

                var client = new HttpClient();

                Console.Write("Welcome to the Open Weather API!\nPlease input your API Key: ");
                var api_key = Console.ReadLine();

                Console.Write("\nThank you.\n\nEnter the city: ");
                var city_name = Console.ReadLine().ToLower();

                var userURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={api_key}&units=metric";

                var weatherResponse = client.GetStringAwait(userURL).Result;

                var formattedResponseMain = JObject.Parse(weatherResponse).GetValue("main").ToString();
                var formattedResponseTemp = JObject.Parse(formattedResponseMain).GetValue("temp").ToString();

                Console.WriteLine($"\n{formattedResponseTemp} degrees Celsius.");
            }
        }
    }
}

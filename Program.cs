using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/users";
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            List<UserModel> parsedResult = JsonConvert.DeserializeObject<List<UserModel>>(result);

            string input = "";
            Console.WriteLine("Hello, I'm HTTP client demo app!");

            while (input != "Exit")
            {
                Console.WriteLine("Please input User name or fragment of it");
                string name_ = Console.ReadLine();
                input = name_;

                try
                {
                    if (input != "Exit")
                    { 
                    UserModel selectedUser = parsedResult.First(a => a.Name.Contains(input));
                    Console.WriteLine($"'Street': {selectedUser.Address.Street} 'Suite': {selectedUser.Address.Suite}" +
                        $" 'City': {selectedUser.Address.City} 'ZIP code': {selectedUser.Address.Zipcode}");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(":( Sorry, we cannot find such value in the dataset...");
                }
            }
        }

    }
}
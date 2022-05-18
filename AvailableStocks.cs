using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Bankkonto
{
    internal static class AvailableStocks
    {
        //A method that gets the name of some companies that include the word you've chosen.
        public static void StockExchange(string userinput)
        {
            //Jag måste tacka Jonathan för hjälp med att få mycket av det här att fungera.
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://yfapi.net/");
            httpClient.DefaultRequestHeaders.Add("X-API-KEY",
                "Ni8fJWEWio4SYjMNFtjdX3CHXhRL5qz84wxzv5Db");
            httpClient.DefaultRequestHeaders.Add("accept",
                "application/json");

            var response = httpClient.GetAsync(
                $"v6/finance/autocomplete?region=US&lang=en&query={userinput}").Result;
            var responseBody = response.Content.ReadAsStringAsync().Result;
            JContainer data = JsonConvert.DeserializeObject<JContainer>(responseBody);
            int length = 0;
            for (int i = 0; i < 10; i++)
            {
                if (data.SelectToken($"ResultSet.Result[{i}].name") != null)
                {
                    length++;
                }
            }

            List<string> Stocks = new List<string>();

            Stocks.Add("Choose a Company");

            for (int i = 0; i < length; i++)
            {
                Stocks.Add(i + ": " + data.SelectToken($"ResultSet.Result[{i}].name"));
            }

            if (length > 0)
            {
                Window.Write(Stocks.Count + 2, Stocks.ToArray());
                StockPrice.Price((string)data.SelectToken($"ResultSet.Result[{Convert.ToInt32(Console.ReadLine())}].symbol"));
            }
        }
    }
}
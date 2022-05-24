using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Bankkonto
{
    internal static class StockPrice
    {
        //A method that gets the cost for the stocks of the company you've chosen.
        public static void Price(string symbol)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://yfapi.net/");
            httpClient.DefaultRequestHeaders.Add("X-API-KEY",
                "Ni8fJWEWio4SYjMNFtjdX3CHXhRL5qz84wxzv5Db");
            httpClient.DefaultRequestHeaders.Add("accept",
                "application/json");

            var response = httpClient.GetAsync(
                $"v11/finance/quoteSummary/{symbol}?lang=en&region=US&modules=defaultKeyStatistics%2CassetProfile%2CsummaryDetail").Result;
            var responseBody = response.Content.ReadAsStringAsync().Result;
            JContainer data = JsonConvert.DeserializeObject<JContainer>(responseBody);

            List<string> stock = new List<string>();
            if (data.SelectToken($"quoteSummary.result[{0}].summaryDetail.open.raw") != null)
            {
                stock.Add("Stock Price Now: " + (string)data.SelectToken($"quoteSummary.result[{0}].summaryDetail.open.raw") + " USD");
                stock.Add("Lowest Stock Price Today: " + (string)data.SelectToken($"quoteSummary.result[{0}].summaryDetail.dayLow.raw") + " USD");
                stock.Add("Highest Stock Price Today: " + (string)data.SelectToken($"quoteSummary.result[{0}].summaryDetail.dayHigh.raw") + " USD");
                Window.Write(stock.Count + 2, stock.ToArray());
            }
            else
            {
                Window.Write(Messages.CompanyErrorMessage.Length + 2, Messages.CompanyErrorMessage);
            }
        }
    }
}
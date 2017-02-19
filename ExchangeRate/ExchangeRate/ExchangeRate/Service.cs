using Newtonsoft.Json;
using Org.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate
{
    class Service
    {
        public async Task<List<InnerModel>> GetExchangeRateByDate(string date)
        {
            List<InnerModel> list = new List<InnerModel>();
            using (var client = new HttpClient(new ModernHttpClient.NativeMessageHandler()))
            {
                var url = new Uri("https://api.privatbank.ua/p24api/exchange_rates?json&date="+date);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Model>(responseContent.ToString());
                    if(result.exchangeRate.Count!=0)
                    {
                        list = result.exchangeRate;
                        list[0].date = date;
                        list[0].rowHeight = 60;
                        list[0].rowHeight2 = 48;
                        list[0].saleRateSTR = "PB Sale Rate";
                        list[0].saleRateNBSTR = "NB Sale Rate";
                        list[0].purchaseRateSTR = "PB Purchase Rate";
                        list[0].purchaseRateNBSTR = "NB Purchase Rate";
                    }                    
                }
                return list;
            }
        }
    }
}

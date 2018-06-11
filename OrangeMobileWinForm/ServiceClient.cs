using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OrangeMobileSelfhost;

namespace OrangeMobileWinForm
{
    class ServiceClient
    {
        internal async static Task<List<clsPhone>> GetPhoneListAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsPhone>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/phone/GetPhoneList/"));
        }

        internal async static Task<List<clsPhoneCategories>> GetPhoneCategoriesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsPhoneCategories>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/phone/GetPhoneCategories/"));
        }

        internal async static Task<string> InsertProductAsync(clsPhone prPhone)
        {
            return await InsertOrUpdateAsync(prPhone, "http://localhost:60064/api/phone/PostPhone", "POST");
        }

        internal async static Task<string> UpdateProductAsync(clsPhone prPhone)
        {
            
            return await InsertOrUpdateAsync(prPhone, "http://localhost:60064/api/phone/PutPhone", "PUT");
        }

        internal async static Task<List<clsOrders>> GetPhonePendingOrdersAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrders>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/phone/GetPhonePendingOrders"));
        }

        internal async static Task<List<clsOrders>> GetPhoneCompletedOrdersAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrders>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/phone/GetPhoneCompletedOrders"));
        }

        internal async static Task<string> ConfirmOrderAsync(clsOrders prOrder)
        {

            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/phone/PutConfirmOrder", "PUT");
        }


        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content = new StringContent(JsonConvert.SerializeObject(prItem), Encoding.Default, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
    }
}

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

        internal async static Task<string> InsertProductAsync(clsPhone prPhone)
        {
            return await InsertOrUpdateAsync(prPhone, "http://localhost:60064/api/phone/PostPhone", "POST");
        }

        internal async static Task<string> UpdateProductAsync(clsPhone prPhone)
        {
            
            return await InsertOrUpdateAsync(prPhone, "http://localhost:60064/api/phone/PutPhone", "PUT");
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

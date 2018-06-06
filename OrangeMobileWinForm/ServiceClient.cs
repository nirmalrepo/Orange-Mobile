﻿using Newtonsoft.Json;
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
        //internal async static Task<List<clsPhone>> GetPhoneListAsync()
        //{
        //    using (HttpClient lcHttpClient = new HttpClient())
        //        return JsonConvert.DeserializeObject<List<string>>
        //            (await lcHttpClient.GetStringAsync("http://localhost:60064/api/phone/GetPhoneList/"));
        //}
        //internal async static Task<clsArtist> GetArtistAsync(string prArtistName)
        //{
        //    using (HttpClient lcHttpClient = new HttpClient())
        //        return JsonConvert.DeserializeObject<clsArtist>(await lcHttpClient.GetStringAsync("http://localhost:60064/api/gallery/GetArtist?Name=" + prArtistName));
        //}


        //private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        //{
        //    using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
        //    using (lcReqMessage.Content = new StringContent(JsonConvert.SerializeObject(prItem), Encoding.Default, "application/json"))
        //    using (HttpClient lcHttpClient = new HttpClient()) { HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
        //        return await lcRespMessage.Content.ReadAsStringAsync();
        //    }
        //}

        //internal async static Task<string> InsertArtistAsync(clsArtist prArtist)
        //{
        //    return await InsertOrUpdateAsync(prArtist, "http://localhost:60064/api/gallery/PostArtist", "POST");
        //}

        //internal async static Task<string> UpdateArtistAsync(clsArtist prArtist)
        //{
        //    return await InsertOrUpdateAsync(prArtist, "http://localhost:60064/api/gallery/PutArtist", "PUT");
        //}
    }
}

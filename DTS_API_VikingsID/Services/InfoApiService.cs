using DTS_API_VikingsID.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DTS_API_VikingsID.Services
{
    public class InfoApiService
    {
        private readonly string _baseUrl = "https://sb-auth.vikings.com.vn";

        public async Task<MyIdentityResponse> GetMyIdentityAsync(string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                // Thêm Authorization vào Header
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                // Gửi request
                var response = await httpClient.GetAsync($"{_baseUrl}/api/profile/my-identity");

                if (response.IsSuccessStatusCode)
                {

                    var responseString = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<MyIdentityResponse>(responseString);
                }

                return null;
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTS_API_VikingsID.Models;
using Newtonsoft.Json;

namespace DTS_API_VikingsID.Services
{
        public class ApiService
        {
            private readonly string _baseUrl = "https://sb-auth.vikings.com.vn";

            public async Task<LoginResponse> LoginAsync(string username, string password)
            {
                using (var httpClient = new HttpClient())
                {
                    // Tạo nội dung JSON cho body yêu cầu
                    var payload = new
                    {
                        userNameOrEmailAddress = username,
                        password = password
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                    // Gửi yêu cầu POST
                    var response = await httpClient.PostAsync($"{_baseUrl}/api/auth/sign-in", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc dữ liệu JSON từ phản hồi
                        var responseString = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseString); // Kiểm tra JSON trả về

                        // Deserialize JSON thành đối tượng
                        return JsonConvert.DeserializeObject<LoginResponse>(responseString);
                    }

                    throw new Exception("Không thể kết nối đến API.");
                //return null;
                }
            }
        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS_API_VikingsID.Models
{
    public class LoginResponse
    {
        public ResultData Result { get; set; }
        public bool Success { get; set; }

        public class ResultData
        {
            public string AccessToken { get; set; }
            public string EncryptedAccessToken { get; set; }
            public int ExpireInSeconds { get; set; }
            public int UserId { get; set; }
            public string RefreshToken { get; set; }
        }
    }
}

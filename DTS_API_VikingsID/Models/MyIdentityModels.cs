using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS_API_VikingsID.Models
{
    public class MyIdentityResponse
    {
        public MyIdentityResult Result { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }

    public class MyIdentityResult
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public bool IsVerified { get; set; }
        public double MainBalance { get; set; }
        public double ExpBalance { get; set; }
        public double PennyBalance { get; set; }
        public string MembershipName { get; set; }
        public string MemberSince { get; set; }
    }
}

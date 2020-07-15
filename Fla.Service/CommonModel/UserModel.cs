using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.CommonModel
{
    public class UserModel
    {
        public long Id { get; set; }
        public long DriverId { get; set; }
        public string UserName { get; set; }
        public string DriverName { get; set; }
        public string ClientName { get; set; }
        public string Password { get; set; }
        public long ClientId { get; set; }
        public string ClientCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Token { get; set; }
    }
}

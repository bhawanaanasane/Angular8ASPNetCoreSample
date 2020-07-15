using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.AngularModels.A_ClientModel
{
    public class A_ClientModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public long? StateProvinceId { get; set; }
        public long ClientId { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string StartingDriverCodeNumber { get; set; }
        public string StartingOrderNumber { get; set; }
        public byte[] CompanyImage { get; set; }
        public long UserId { get; set; }
        public string ClientCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        //login
        public long UserLoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long ParentId { get; set; }
        public bool Active { get; set; }
        public bool LoggedIn { get; set; }
        public DateTime? TimeOutDate { get; set; }
        public string Token { get; set; }
        public long RoleId { get; set; }
    }
}

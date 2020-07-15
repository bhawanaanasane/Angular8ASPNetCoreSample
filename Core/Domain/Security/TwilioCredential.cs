using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Security
{
    public class TwilioCredential : BaseEntity
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string PhoneNumber { get; set; }
        public string ShaKey { get; set; }
    }
}

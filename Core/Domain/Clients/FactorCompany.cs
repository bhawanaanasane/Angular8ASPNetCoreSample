using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Clients
{
   public class FactorCompany:BaseEntity
    {
        public string FactorsCompany { get; set; }
        public string FactorAddress1 { get; set; }
        public string FactorAddress2 { get; set; }
        public long ClientId { get; set; }
        public string FactorCity { get; set; }
        public long FactorState { get; set; }
        public string FactorZipCode { get; set; }
        public string FactorPhoneNumber { get; set; }
        public string FactorFaxNumber { get; set; }
        public long UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}

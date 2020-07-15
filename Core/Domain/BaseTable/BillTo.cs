using FLA.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.BaseTable
{
    public partial class BillTo:BaseEntity
    {
        
        public long ClientId { get; set; }
        public long TermsId { get; set; }
        public long UserLoginId { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public long? StateProvinceId { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string InvoiceEmailAddress { get; set; }
        public string FaxNumber { get; set; }
        public bool Factor { get; set; }
        public bool EDI { get; set; }
        public bool Active { get; set; }
        public long InvoicePreferenceId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public InvoicePreference invoicePreference
        {
            get { return (InvoicePreference)InvoicePreferenceId; }
            set { InvoicePreferenceId = (long)value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Scheduling
{
    public class PayType:BaseEntity
    {
        public string AddOnDescription { get; set; }
        public decimal PayAmount { get; set; }
    }
}

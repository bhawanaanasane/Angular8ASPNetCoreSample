using FLA.Core.Domain.Orders;
using FLA.Core.EnumStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Orders
{
    public partial class Containers:BaseEntity
    {
        public long OrderId { get; set; }
        public virtual Order orders {get;set;}
        public virtual Size Size { get; set; }
        public long? SizeId { get; set; }
        public string ContainerNumber { get; set; }
        public long? ChassisId { get; set; }
        public long ClientId { get; set; }
        public string SealNumber { get; set; }
        public long? Temperature { get; set; }
        public decimal? Weight { get; set; }
       
        public bool POPChassisFlag { get; set; }
        public long UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public long StatusId { get; set; }
        public Status Status
        {
            get { return (Status)StatusId; }
            set { StatusId = (long)value; }
        }
    }
}

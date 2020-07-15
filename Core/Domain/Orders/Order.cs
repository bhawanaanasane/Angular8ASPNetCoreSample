using FLA.Core.EnumStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Orders
{
    public partial class Order:BaseEntity
    {
        public long OrderNumber { get; set; }
        public long DeliveryID { get; set; }
        public long PickupID { get; set; }
        public long BillToID { get; set; }
        public long ClientId { get; set; }
        public long ReturnLocationID { get; set; }
        public long? SalesRepID { get; set; }
        public long? SalesPersonId { get; set; }
        public long OrderStatusId { get; set; }
        public OrderStatus OrderStatus
        {
            get { return (OrderStatus)OrderStatusId; }
            set
            {
                OrderStatusId = (long)value;
            }
        }
        public long Import_ExportId { get; set; }
        public Import_ExportStatus Import_ExportStatus
        {
            get { return (Import_ExportStatus)Import_ExportId; }
            set
            {
                Import_ExportId = (long)value;
            }
        }
        public string BillofLading { get; set; }
        public string BookingNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string BrokerRefNumber { get; set; }
        public string InvoiceNotes { get; set; }
        public string DriverNotes { get; set; }
        public string PoNumber { get; set; }
        public bool InvoiceExceptionFlag { get; set; }
        public bool ReturnPickup { get; set; }
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

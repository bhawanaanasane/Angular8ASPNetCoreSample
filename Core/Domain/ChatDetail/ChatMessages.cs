using FLA.Core.EnumStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.ChatDetail
{
    public class ChatMessages:BaseEntity
    {
        public long MessageId { get; set; }
        public virtual Message Message { get; set; }
        public bool IsSenderDeleted { get; set; }
        public bool IsReceiverDeleted { get; set; }
        public bool IsRead { get; set; }
        public bool IsRecieved { get; set; }
        public bool IsSend { get; set; }
        public long ClientId { get; set; }
        public long DriverId { get; set; }
        public long UserId { get; set; }
        public string OrderNo { get; set; }
        public string ContainerNo { get; set; }
        public bool OrderHeader { get; set; }
        public long SenderTypeId { get; set; }
        public SenderType SenderType
        {
            get { return (SenderType)SenderTypeId; }
            set { SenderTypeId = (long)value; }
        }
    }
}

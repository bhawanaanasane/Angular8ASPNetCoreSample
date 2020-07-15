using FLA.Core.Domain.Drivers;
using FLA.Core.EnumStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FLA.Core.Domain.ChatDetail
{
    public class Message:BaseEntity
    {
       public long ClientId { get; set; }
        public long DriverId { get; set; }
        public long UserId { get; set; }
        public string Text { get; set; }
        public DateTime MessageTime { get; set; }
        public DateTime? ReadTime { get; set; }
        public bool IsRead { get; set; }
        public string Url { get; set; }
        public long MediaType { get; set; }
        public bool IsHidden { get; set; }
        public bool Deleted { get; set; }
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

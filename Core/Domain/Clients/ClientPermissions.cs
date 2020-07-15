using System;
using System.Collections.Generic;
using System.Text;

namespace FLA.Core.Domain.Clients
{
    public partial class ClientPermissions : BaseEntity
    {
        private ICollection<Client> _clients;
        public long ClientId { get; set; }
        public bool Active { get; set; }
        public bool OrderEntry { get; set; }
        public bool DriverApp { get; set; }
        public bool Availability { get; set; }
        public bool SMSUpdate { get; set; }
        public bool QuickBooks { get; set; }
        public bool EDI { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual ICollection<Client> Client
        {
            get { return _clients ?? (_clients = new List<Client>()); }
           protected set { _clients = value; }
        }
    }
}

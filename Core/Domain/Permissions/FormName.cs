using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLA.Core.Domain.Permissions
{
    public partial class FormName:BaseEntity
    {
        public string Tittle { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}

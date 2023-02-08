using System;
using System.Collections.Generic;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public partial class Supplier:BaseEntity
    {
        public Supplier()
        {
            PurchaseMasters = new HashSet<PurchaseMaster>();
        }

        
        public long ItemId { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public  Item Item { get; set; }
        public  ICollection<PurchaseMaster> PurchaseMasters { get; set; }
    }
}

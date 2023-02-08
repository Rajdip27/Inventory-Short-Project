using System;
using System.Collections.Generic;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public partial class PurchaseMaster:BaseEntity
    {
        public PurchaseMaster()
        {
            PurchaseDetails = new HashSet<PurchaseDetail>();
        }

       
        public long SupplierId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }

        public  Supplier Supplier { get; set; }
        public  ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}

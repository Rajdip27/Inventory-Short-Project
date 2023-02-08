using System;
using System.Collections.Generic;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public partial class PurchaseDetail:BaseEntity
    {
       
        public long PurchaseId { get; set; }
        public long ItemId { get; set; }
        public double Qty { get; set; }
        public double Rate { get; set; }

        public  Item Item { get; set; }
        public  PurchaseMaster Purchase { get; set; }
    }
}

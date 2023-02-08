using System;
using System.Collections.Generic;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public partial class SalesMaster:BaseEntity
    {
        public SalesMaster()
        {
            SalesDetails = new HashSet<SalesDetail>();
        }

       
        public long CustomerId { get; set; }
        public DateTime SalesDate { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }

        public  Customer Customer { get; set; }
        public  ICollection<SalesDetail> SalesDetails { get; set; }
    }
}

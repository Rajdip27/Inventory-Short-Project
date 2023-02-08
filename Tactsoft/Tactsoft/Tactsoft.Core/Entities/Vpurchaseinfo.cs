using System;
using System.Collections.Generic;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public partial class Vpurchaseinfo:BaseEntity
    {
       
        public DateTime PurchaseDate { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public double Total { get; set; }
    }
}

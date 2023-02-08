using System;
using System.Collections.Generic;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public partial class VsalesInfo:BaseEntity
    {
        
        public DateTime SalesDate { get; set; }
        public string CustomerName { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public double Total { get; set; }
    }
}

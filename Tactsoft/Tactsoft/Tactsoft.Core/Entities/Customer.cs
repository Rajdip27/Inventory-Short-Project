using System;
using System.Collections.Generic;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public partial class Customer:BaseEntity
    {
        public Customer()
        {
            SalesMasters = new HashSet<SalesMaster>();
        }

        
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public  ICollection<SalesMaster> SalesMasters { get; set; }
    }
}

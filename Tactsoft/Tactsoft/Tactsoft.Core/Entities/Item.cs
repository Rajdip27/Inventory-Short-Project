using System;
using System.Collections.Generic;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public partial class Item:BaseEntity
    {
        public Item()
        {
            PurchaseDetails = new HashSet<PurchaseDetail>();
            Returns = new HashSet<Return>();
            SalesDetails = new HashSet<SalesDetail>();
            Suppliers = new HashSet<Supplier>();
        }

       
        public long CategoryId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        public  Category Category { get; set; }
        public  ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public  ICollection<Return> Returns { get; set; }
        public  ICollection<SalesDetail> SalesDetails { get; set; }
        public  ICollection<Supplier> Suppliers { get; set; }
    }
}

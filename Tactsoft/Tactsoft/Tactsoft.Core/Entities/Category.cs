using System;
using System.Collections.Generic;
using Tactsoft.Core.Base;

namespace  Tactsoft.Core.Entities
{
    public partial class Category:BaseEntity
    {
      

       
        public string CategoryName { get; set; }

        public  ICollection<Item> Items { get; set; }
    }
}

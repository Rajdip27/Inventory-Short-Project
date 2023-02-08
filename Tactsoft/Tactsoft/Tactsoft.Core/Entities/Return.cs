using System;
using System.Collections.Generic;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public partial class Return:BaseEntity
    {
        
        public long ItemId { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Comments { get; set; }

        public  Item  Item { get; set; }
    }
}

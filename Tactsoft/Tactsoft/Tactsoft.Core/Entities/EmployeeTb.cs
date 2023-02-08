using System;
using System.Collections.Generic;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public partial class EmployeeTb:BaseEntity
    {
        
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public double Basic { get; set; }
    }
}

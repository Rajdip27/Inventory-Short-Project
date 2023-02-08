using System;
using System.Collections.Generic;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public partial class EmployeeSalaryTb:BaseEntity
    {
       
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public double Basic { get; set; }
        public double Hr { get; set; }
        public double Pf { get; set; }
        public double Ta { get; set; }
        public double Ma { get; set; }
        public double Bonus { get; set; }
        public double Gross { get; set; }
    }
}

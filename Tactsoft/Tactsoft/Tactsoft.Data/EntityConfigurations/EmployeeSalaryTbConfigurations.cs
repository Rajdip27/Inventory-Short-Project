using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.EntityConfigurations
{
    public class EmployeeSalaryTbConfigurations : IEntityTypeConfiguration<EmployeeSalaryTb>
    {
        public void Configure(EntityTypeBuilder<EmployeeSalaryTb> builder)
        {
           builder.HasKey(e => e.Id);
        }
    }
}

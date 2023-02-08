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
    public class SalesMasterConfigurations : IEntityTypeConfiguration<SalesMaster>
    {
        public void Configure(EntityTypeBuilder<SalesMaster> builder)
        {
           builder.HasKey(x => x.Id);
            builder.HasOne(d => d.Customer).WithMany(p => p.SalesMasters).HasForeignKey(d => d.CustomerId);
        }
    }
}

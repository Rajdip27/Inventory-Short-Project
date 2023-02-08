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
    public class SalesDetailConfigurations : IEntityTypeConfiguration<SalesDetail>
    {
        public void Configure(EntityTypeBuilder<SalesDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(d => d.Item).WithMany(p => p.SalesDetails).HasForeignKey(d => d.ItemId);
            builder.HasOne(d => d.Sales).WithMany(p => p.SalesDetails).HasForeignKey(d => d.SalesId);
        }
    }
}

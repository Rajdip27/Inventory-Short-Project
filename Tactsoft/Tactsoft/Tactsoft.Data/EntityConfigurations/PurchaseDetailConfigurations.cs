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
    public class PurchaseDetailConfigurations : IEntityTypeConfiguration<PurchaseDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(d => d.Item).WithMany(p => p.PurchaseDetails).HasForeignKey(d => d.ItemId);
            builder.HasOne(d => d.Purchase).WithMany(p => p.PurchaseDetails).HasForeignKey(d => d.PurchaseId);
        }
    }
}

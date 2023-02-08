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
    public class PurchaseMasterConfigurations : IEntityTypeConfiguration<PurchaseMaster>
    {
        public void Configure(EntityTypeBuilder<PurchaseMaster> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(d => d.Supplier).WithMany(p => p.PurchaseMasters).HasForeignKey(d => d.SupplierId);
        }
    }
}

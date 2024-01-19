using CounThings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounThings.Infra.Context.Mappings
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

            builder.Property(x => x.AmountPaid)
            .HasColumnName("amount_paid")
            .IsRequired();

            builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

            builder.Property(x => x.ActivityId)
            .HasColumnName("activity_id")
            .IsRequired();

            builder.HasOne(x => x.Activity)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.ActivityId);

        }
    }
}

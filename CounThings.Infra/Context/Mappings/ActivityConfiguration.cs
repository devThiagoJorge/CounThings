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
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("activity");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

            builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired();

            builder.Property(x => x.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

            builder.Property(x => x.Total)
            .HasColumnName("total");

            builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

            builder.Property(x => x.ItsCalculable)
            .HasColumnName("its_calculable")
            .IsRequired();

            builder.HasMany(x => x.Payments)
            .WithOne(f => f.Activity)
            .HasForeignKey(f => f.ActivityId)
            .IsRequired();
        }
    }
}

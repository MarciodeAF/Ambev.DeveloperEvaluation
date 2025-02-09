using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.NumberSale).IsRequired();
        builder.Property(u => u.CreatedSale).IsRequired();
        builder.Property(u => u.Customer).IsRequired().HasMaxLength(100);
        builder.Property(u => u.TotalValue);
        builder.Property(u => u.Agency).IsRequired().HasMaxLength(50); ;
        builder.Property(u => u.UpdatedAt).IsRequired();

        builder.Property(u => u.Status)
           .HasConversion<string>()
           .HasMaxLength(20);
    }
}

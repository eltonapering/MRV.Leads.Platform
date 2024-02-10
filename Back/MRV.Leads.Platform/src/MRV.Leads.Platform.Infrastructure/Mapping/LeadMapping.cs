using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MRV.Leads.Platform.Domain.Entities;

namespace MRV.Leads.Platform.Infrastructure.Mapping;

public class LeadMapping : IEntityTypeConfiguration<Intent>
{
    public void Configure(EntityTypeBuilder<Intent> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Description).IsRequired().HasMaxLength(500);
        builder.Property(l => l.Price).HasColumnType("decimal(18,2)");
        builder.HasOne(l => l.Contact).WithMany().HasForeignKey("ContactId");
    }
}

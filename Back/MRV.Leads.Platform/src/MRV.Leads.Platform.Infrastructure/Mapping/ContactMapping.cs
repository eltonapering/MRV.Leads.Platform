using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MRV.Leads.Platform.Domain.Entities;

namespace MRV.Leads.Platform.Infrastructure.Mapping;

public class ContactMapping : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FullName).IsRequired().HasMaxLength(200);
        builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(15);        
    }
}

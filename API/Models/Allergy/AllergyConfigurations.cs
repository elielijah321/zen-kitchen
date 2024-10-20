using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Function;

namespace Project.Configuration{

    public class AllergyConfigurations : IEntityTypeConfiguration<Allergy>
    {
        public void Configure(EntityTypeBuilder<Allergy> builder)
        {
            builder.ToTable("Allergies", "dbo");
            
            builder.HasKey(e => e.Id)
                    .HasName("PK__Allergy");

            builder.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.CreatedAt)
                    .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
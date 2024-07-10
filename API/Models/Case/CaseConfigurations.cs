using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Function;

namespace Project.Configuration{

    public class CasesConfigurations : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            builder.ToTable("Cases", "dbo");
            
            builder.HasKey(e => e.Id)
                    .HasName("PK__Case");

            builder.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()");
        }
    }
}
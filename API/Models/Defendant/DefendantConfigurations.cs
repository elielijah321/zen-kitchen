using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Function;

namespace Project.Configuration{

    public class DefendantConfigurations : IEntityTypeConfiguration<Defendant>
    {
        public void Configure(EntityTypeBuilder<Defendant> builder)
        {
            builder.ToTable("Defendants", "dbo");
            
            builder.HasKey(e => e.Id)
                    .HasName("PK__Defendant");

            builder.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()");
        }
    }
}
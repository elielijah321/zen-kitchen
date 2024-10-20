using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Function;

namespace Project.Configuration{

    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus", "dbo");
            
            builder.HasKey(e => e.Id)
                    .HasName("PK__Menu");

            builder.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.CreatedAt)
                    .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
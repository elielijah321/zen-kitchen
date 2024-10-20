using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Function;

namespace Project.Configuration{

    public class MenuItemConfigurations : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("MenuItems", "dbo");
            
            builder.HasKey(e => e.Id)
                    .HasName("PK__MenuItem");

            builder.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.CreatedAt)
                    .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
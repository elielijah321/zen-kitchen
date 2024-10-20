using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Function;

namespace Project.Configuration{

    public class SettingConfigurations : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Settings", "dbo");
            
            builder.HasKey(e => e.Id)
                    .HasName("PK__Setting");

            builder.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.CreatedAt)
                    .HasDefaultValue(DateTime.UtcNow);


            var guid = Guid.Parse(SettingConstants.CURRENT_MENU_ID);

            var setting = new Setting()
            {
                Id = guid,
                Name = "Current Menu",
                Value = ""
            };

            builder.HasData(setting);
        }
    }
}
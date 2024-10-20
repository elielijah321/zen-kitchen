using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Function;

namespace Project.Configuration{

    public class IngredientConfigurations : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredients", "dbo");
            
            builder.HasKey(e => e.Id)
                    .HasName("PK__Ingredient");

            builder.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.CreatedAt)
                    .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
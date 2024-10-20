using System;
using System.Collections.Generic;
using AzureFunctions.Database;
using Microsoft.EntityFrameworkCore;

namespace Project.Function
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();

            // var connectionString = Environment.GetEnvironmentVariable("MARINEL_DEV_CONNECTION_STRING");
            var connectionString = "Server=tcp:zen-kitchen-mssqlserver-prod.database.windows.net,1433;Initial Catalog=zen;Persist Security Info=False;User ID=zen-manchester;Password=AbbieKitchen!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeItem> RecipeItems { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Setting> Settings { get; set; }

    }
}
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
            var connectionString = "Server=tcp:court-app-template.database.windows.net,1433;Initial Catalog=court-app;Persist Security Info=False;User ID=elijah;Password=Kabiyesi2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Defendant> Defendants { get; set; }
    }
}
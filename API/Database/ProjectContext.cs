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

            var connectionString = "Server=tcp:gym-template-dev.database.windows.net,1433;Initial Catalog=Gym;Persist Security Info=False;User ID=elijah;Password=Weights1995;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
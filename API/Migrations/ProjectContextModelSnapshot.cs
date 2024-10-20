﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Function;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Project.Function.Allergy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(2129));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Allergy");

                    b.ToTable("Allergies", "dbo");
                });

            modelBuilder.Entity("Project.Function.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(2692));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Protein")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Ingredient");

                    b.ToTable("Ingredients", "dbo");
                });

            modelBuilder.Entity("Project.Function.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(3192));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Menu");

                    b.ToTable("Menus", "dbo");
                });

            modelBuilder.Entity("Project.Function.MenuItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(3878));

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__MenuItem");

                    b.HasIndex("MenuId");

                    b.HasIndex("RecipeId");

                    b.ToTable("MenuItems", "dbo");
                });

            modelBuilder.Entity("Project.Function.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(4405));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id")
                        .HasName("PK__Recipe");

                    b.ToTable("Recipes", "dbo");
                });

            modelBuilder.Entity("Project.Function.RecipeItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(4936));

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__RecipeItem");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeItems", "dbo");
                });

            modelBuilder.Entity("Project.Function.Setting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 10, 20, 13, 14, 0, 118, DateTimeKind.Utc).AddTicks(5424));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Setting");

                    b.ToTable("Settings", "dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a74feeb4-f3e5-4b85-aef9-6b6b9e482a1f"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Current Menu",
                            Value = ""
                        });
                });

            modelBuilder.Entity("Project.Function.MenuItem", b =>
                {
                    b.HasOne("Project.Function.Menu", null)
                        .WithMany("Recipes")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Function.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Project.Function.RecipeItem", b =>
                {
                    b.HasOne("Project.Function.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Function.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Project.Function.Menu", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("Project.Function.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}

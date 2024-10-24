using System;
using System.Collections.Generic;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Capitale> Capitales { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Profesione> Profesiones { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Capitale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC279FA2A21A");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Acronimo).HasMaxLength(10);
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .UseCollation("Latin1_General_BIN2");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PaisId).HasColumnName("PaisID");

            entity.HasOne(d => d.Pais).WithMany(p => p.Capitales)
                .HasForeignKey(d => d.PaisId)
                .HasConstraintName("FK__Capitales__PaisI__68487DD7");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC274FE57C78");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Acronimo)
                .HasMaxLength(10)
                .UseCollation("Latin1_General_BIN2");
            entity.Property(e => e.CodigoPais).HasMaxLength(10);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Profesione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesio__3214EC27607541ED");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ApellidoProfesional).HasMaxLength(100);
            entity.Property(e => e.NombreProfesion).HasMaxLength(100);
            entity.Property(e => e.NombreProfesional).HasMaxLength(100);
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehiculo__3214EC27A0536483");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Marca).HasMaxLength(100);
            entity.Property(e => e.NombreVehiculo).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

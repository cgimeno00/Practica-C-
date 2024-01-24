using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CLAvaPersistCore.DB;

public partial class AvaBbddcloud01Context : DbContext
{
    public AvaBbddcloud01Context()
    {
    }

    public AvaBbddcloud01Context(DbContextOptions<AvaBbddcloud01Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Direccione> Direcciones { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EmpleadosDireccione> EmpleadosDirecciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //Aqui va la connection string
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A10B83BE2AA");

            entity.Property(e => e.IdCategoria).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SueldoMax).HasColumnType("numeric(9, 2)");
            entity.Property(e => e.SueldoMin).HasColumnType("numeric(9, 2)");
        });

        modelBuilder.Entity<Direccione>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__1F8E0C764B3F6BA4");

            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E04F5E550");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sueldo).HasColumnType("numeric(9, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleados_Categorias");
        });

        modelBuilder.Entity<EmpleadosDireccione>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.IdDireccionNavigation).WithMany()
                .HasForeignKey(d => d.IdDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpleadosDirecciones_Direccion");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany()
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpleadosDirecciones_Empleado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

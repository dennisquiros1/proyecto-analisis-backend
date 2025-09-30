using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Análisis_Backend.Models;

public partial class PHAtlanticoContext : DbContext  
{
    private readonly IConfiguration _configuration;

    public PHAtlanticoContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public PHAtlanticoContext(DbContextOptions<PHAtlanticoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoordinadorCarrera> CoordinadorCarreras { get; set; }

    public virtual DbSet<CoordinadorDocencia> CoordinadorDocencia { get; set; }

    public virtual DbSet<CoordinadorSeccion> CoordinadorSeccions { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoordinadorCarrera>(entity =>
        {
            entity.HasKey(e => e.Usuario).HasName("PK__Coordina__9AFF8FC74D6C67F8");

            entity.ToTable("CoordinadorCarrera", "usuario");

            entity.Property(e => e.Usuario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.GradoAcademico)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gradoAcademico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<CoordinadorDocencia>(entity =>
        {
            entity.HasKey(e => e.Usuario).HasName("PK__Coordina__9AFF8FC79F97F852");

            entity.ToTable("CoordinadorDocencia", "usuario");

            entity.Property(e => e.Usuario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.GradoAcademico)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gradoAcademico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<CoordinadorSeccion>(entity =>
        {
            entity.HasKey(e => e.Usuario).HasName("PK__Coordina__9AFF8FC7F4473EF9");

            entity.ToTable("CoordinadorSeccion", "usuario");

            entity.Property(e => e.Usuario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.GradoAcademico)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gradoAcademico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.Usuario).HasName("PK__Registro__9AFF8FC7C7CD1328");

            entity.ToTable("Registro", "usuario");

            entity.Property(e => e.Usuario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

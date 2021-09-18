using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TrabajadoresPrueba.Models.DB
{
    public partial class TrabajadoresPruebaContext : DbContext
    {
        public TrabajadoresPruebaContext()
        {
        }

        public TrabajadoresPruebaContext(DbContextOptions<TrabajadoresPruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Trabajadores> Trabajadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database=TrabajadoresPrueba; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.NombreDepartamento)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.Property(e => e.NombreDistrito)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Distrito)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK__Distrito__IdProv__164452B1");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.Property(e => e.NombreProvincia)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Provincia)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK__Provincia__IdDep__173876EA");
            });

            modelBuilder.Entity<Trabajadores>(entity =>
            {
                entity.Property(e => e.Nombres)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK__Trabajado__IdDep__182C9B23");

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdDistrito)
                    .HasConstraintName("FK__Trabajado__IdDis__1920BF5C");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK__Trabajado__IdPro__1A14E395");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class DBESANDWContext : DbContext
    {
        public DBESANDWContext()
        {
        }

        public DBESANDWContext(DbContextOptions<DBESANDWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mascota> Mascota { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<ModuloRol> ModuloRol { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=DB-ESAN-DW;Trusted_Connection=true;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Raza)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Icono)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Ruta)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ModuloRol>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Modulo_Rol");

                entity.HasOne(d => d.Modulo)
                    .WithMany()
                    .HasForeignKey(d => d.ModuloId)
                    .HasConstraintName("FK_Modulo_Rol_2");

                entity.HasOne(d => d.Rol)
                    .WithMany()
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_Modulo_Rol_1");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Materno)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.NumDoc)
                    .HasMaxLength(12)
                    .IsFixedLength(true);

                entity.Property(e => e.Paterno)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.Property(e => e.TipDoc)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Login)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_Usuario_Persona");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

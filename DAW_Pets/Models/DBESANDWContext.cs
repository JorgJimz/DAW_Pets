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

        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Maestro> Maestro { get; set; }
        public virtual DbSet<Mascota> Mascota { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<ModuloRol> ModuloRol { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vacuna> Vacuna { get; set; }

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

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.Property(e => e.Comentario1)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Comentario");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.MascotaId).HasColumnName("Mascota_Id");

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");

                entity.HasOne(d => d.Mascota)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.MascotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Comentario_fk1");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Comentario_fk0");
            });

            modelBuilder.Entity<Maestro>(entity =>
            {
                entity.Property(e => e.Atributo1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Atributo2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Atributo3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Grupo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.Property(e => e.ActividadFisica)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Actividad_Fisica");

                entity.Property(e => e.Alimentacion)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Altura).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Caracter)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Clima)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EsperanzaVida).HasColumnName("Esperanza_Vida");

                entity.Property(e => e.Habitat)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen).HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Peso).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Raza)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Situacion)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Tamaño)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
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
                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Fijo).HasMaxLength(20);

                entity.Property(e => e.Materno).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.NumDoc)
                    .HasMaxLength(12)
                    .IsFixedLength(true);

                entity.Property(e => e.Paterno).HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TipDoc)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Trabajo).HasMaxLength(20);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(20);
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.Property(e => e.Detalle)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.MascotaId).HasColumnName("Mascota_Id");

                entity.Property(e => e.QPersonas).HasColumnName("Q_Personas");

                entity.Property(e => e.TipoDomicilio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Tipo_Domicilio");

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");

                entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("Solicitud_fk2");

                entity.HasOne(d => d.Mascota)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.MascotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Solicitud_fk1");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Solicitud_fk0");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Login).HasMaxLength(500);

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.Property(e => e.Sal).HasMaxLength(500);

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_Usuario_Persona");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            modelBuilder.Entity<Vacuna>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.MascotaId).HasColumnName("Mascota_Id");

                entity.Property(e => e.VacunaId).HasColumnName("Vacuna_Id");

                entity.HasOne(d => d.Mascota)
                    .WithMany(p => p.Vacuna)
                    .HasForeignKey(d => d.MascotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vacuna_fk0");

                entity.HasOne(d => d.VacunaNavigation)
                    .WithMany(p => p.Vacuna)
                    .HasForeignKey(d => d.VacunaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vacuna_fk1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

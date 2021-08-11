using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LibreriaProject.Models;

#nullable disable

namespace LibreriaProject.Data
{
    public partial class LibreriaAFPContext : DbContext
    {
        public LibreriaAFPContext()
        {
        }

        public LibreriaAFPContext(DbContextOptions<LibreriaAFPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetalleOperacion> DetalleOperacions { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Operacione> Operaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-JQPKLTO4\\SQLEXPRESS; database=LibreriaAFP; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdU).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Categoria1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Categoria");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdU).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Dui)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdU).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DetalleOperacion>(entity =>
            {
                entity.ToTable("DetalleOperacion");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdU).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.DetalleOperacions)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetalleOperacion_Clientes");

                entity.HasOne(d => d.Libro)
                    .WithMany(p => p.DetalleOperacions)
                    .HasForeignKey(d => d.LibroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetalleOperacion_Libros");

                entity.HasOne(d => d.Operacion)
                    .WithMany(p => p.DetalleOperacions)
                    .HasForeignKey(d => d.OperacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetalleOperacion_Operaciones");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");

                entity.Property(e => e.IdU).HasDefaultValueSql("((1))");

                entity.Property(e => e.Imagen).IsRequired();

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.AutorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Libros_Autores");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Libros_Categorias");
            });

            modelBuilder.Entity<Operacione>(entity =>
            {
                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdU).HasDefaultValueSql("((1))");

                entity.Property(e => e.Operacion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

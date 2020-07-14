using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Datos.Entities;

namespace Datos.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CONTACTO> CONTACTO { get; set; }
        public virtual DbSet<DIRECCION> DIRECCION { get; set; }
        public virtual DbSet<LOG_GENERAL> LOG_GENERAL { get; set; }
        public virtual DbSet<PERSONA> PERSONA { get; set; }
        public virtual DbSet<TIPO_CONTACTO> TIPO_CONTACTO { get; set; }
        public virtual DbSet<TIPO_PERSONA> TIPO_PERSONA { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server = ANDRES; Database = Usuario_db; User Id = andresdb; password = root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CONTACTO>(entity =>
            {
                entity.HasKey(e => e.CON_ID)
                    .HasName("PK__CONTACTO__0387EBFDBF6D905D");

                entity.HasIndex(e => e.CON_ID)
                    .HasName("CONTACTO_PK")
                    .IsUnique();

                entity.HasIndex(e => e.PER_ID)
                    .HasName("RELATIONSHIP_5_FK");

                entity.HasIndex(e => e.TIP_CON_ID)
                    .HasName("RELATIONSHIP_3_FK");

                entity.Property(e => e.CON_DESCRIPCION)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PER_)
                    .WithMany(p => p.CONTACTO)
                    .HasForeignKey(d => d.PER_ID)
                    .HasConstraintName("FK__CONTACTO__PER_ID__2C3393D0");

                entity.HasOne(d => d.TIP_CON_)
                    .WithMany(p => p.CONTACTO)
                    .HasForeignKey(d => d.TIP_CON_ID)
                    .HasConstraintName("FK__CONTACTO__TIP_CO__2B3F6F97");
            });

            modelBuilder.Entity<DIRECCION>(entity =>
            {
                entity.HasKey(e => e.DIR_ID)
                    .HasName("PK__DIRECCIO__B28024E2852DA39B");

                entity.HasIndex(e => e.DIR_ID)
                    .HasName("DIRECCION_PK")
                    .IsUnique();

                entity.HasIndex(e => e.PER_ID)
                    .HasName("RELATIONSHIP_4_FK");

                entity.Property(e => e.DIR_CALLE_PRINCIPAL)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DIR_CALLE_SECUNDARIA)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DIR_NUMERACION)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DIR_REFERENCIA)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PER_)
                    .WithMany(p => p.DIRECCION)
                    .HasForeignKey(d => d.PER_ID)
                    .HasConstraintName("FK__DIRECCION__PER_I__2F10007B");
            });

            modelBuilder.Entity<LOG_GENERAL>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LG_DESCRIPCION)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LG_FECHA).HasColumnType("datetime");

                entity.Property(e => e.LG_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.LG_USUARIO)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PERSONA>(entity =>
            {
                entity.HasKey(e => e.PER_ID)
                    .HasName("PK__PERSONA__8FE383B32649FFE7");

                entity.HasIndex(e => e.PER_ID)
                    .HasName("PERSONA_PK")
                    .IsUnique();

                entity.HasIndex(e => e.TIP_ID)
                    .HasName("RELATIONSHIP_2_FK");

                entity.Property(e => e.PER_APELLIDO2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PER_APELLODO1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PER_NOMBRE1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PER_NOMBRE2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PER_NOMBRE3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TIP_)
                    .WithMany(p => p.PERSONA)
                    .HasForeignKey(d => d.TIP_ID)
                    .HasConstraintName("FK__PERSONA__TIP_ID__286302EC");
            });

            modelBuilder.Entity<TIPO_CONTACTO>(entity =>
            {
                entity.HasKey(e => e.TIP_CON_ID)
                    .HasName("PK__TIPO_CON__66271DC4A4AF9F21");

                entity.HasIndex(e => e.TIP_CON_ID)
                    .HasName("TIPO_CONTACTO_PK")
                    .IsUnique();

                entity.Property(e => e.TIP_CON_DESCRIPCION)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TIP_CON_NOMBRE)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TIPO_PERSONA>(entity =>
            {
                entity.HasKey(e => e.TIP_ID)
                    .HasName("PK__TIPO_PER__0D5DFDADF6FBF6CB");

                entity.HasIndex(e => e.TIP_ID)
                    .HasName("TIPO_PERSONA_PK")
                    .IsUnique();

                entity.Property(e => e.TIP_DESCRIPCION)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TIP_NOMBRE)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

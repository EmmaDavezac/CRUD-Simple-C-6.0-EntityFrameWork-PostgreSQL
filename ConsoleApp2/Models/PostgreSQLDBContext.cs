using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp2.Models
{
    public partial class PostgreSQLDBContext : DbContext
    {
        /*
        * Información importante:
        * ConnectionString = "Host=babar.db.elephantsql.com;Database=;Username=;Password=KPziajwe2MM-T3JSjrsL4vmnxz41mylH";
        * Paquetes Utilizados:
        *     Microsoft.EntityFrameworkCore.Design
              Microsoft.EntityFrameworkCore.Tools.DotNet
              Microsoft.NETCore.App
              Npgsql.EntityFrameworkCore.PostgreSQL
              Npgsql.EntityFrameworkCore.PostgreSQL.Design
        Comandos En la terminal para la ingerieria inversa de la base de datos:
        dotnet restore
        dotnet ef dbcontext scaffold ConnectionString Npgsql.EntityFrameworkCore.PostgreSQL -o Models
        El mapeto se guarda en la carpeta Model (-o Models)
        */

        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              
                optionsBuilder.UseNpgsql("Host=babar.db.elephantsql.com;Database=;Username=;Password=KPziajwe2MM-T3JSjrsL4vmnxz41mylH");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2");

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("blog");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Blogid).HasColumnName("blogid");

                entity.Property(e => e.Content)
                    .HasMaxLength(240)
                    .HasColumnName("content");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.Blogid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("post_blogid_fkey");
            });

            modelBuilder.HasSequence("idseq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

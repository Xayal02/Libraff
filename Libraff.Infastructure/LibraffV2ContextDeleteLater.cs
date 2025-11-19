//using System;
//using System.Collections.Generic;
//using Libraff.Infrastructure.Persistence.Entities.Content;
//using Microsoft.EntityFrameworkCore;

//namespace Libraff.Infrastructure;

//public partial class LibraffV2Context : DbContext
//{
//    public LibraffV2Context()
//    {
//    }

//    public LibraffV2Context(DbContextOptions<LibraffV2Context> options)
//        : base(options)
//    {
//    }


//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Database=libraff_v2;Username=postgres;Password=0702534040x");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Author>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("authors_pk");

//            entity.ToTable("authors", "content");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
//            entity.Property(e => e.DateOfDeath).HasColumnName("date_of_death");
//            entity.Property(e => e.FirstName)
//                .HasColumnType("character varying")
//                .HasColumnName("first_name");
//            entity.Property(e => e.GenderId).HasColumnName("gender_id");
//            entity.Property(e => e.LastName)
//                .HasColumnType("character varying")
//                .HasColumnName("last_name");
//            entity.Property(e => e.Patronymic)
//                .HasColumnType("character varying")
//                .HasColumnName("patronymic");
//        });

//        modelBuilder.Entity<Book>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("books_pk");

//            entity.ToTable("books", "content");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.AuthorId).HasColumnName("author_id");
//            entity.Property(e => e.GenreId).HasColumnName("genre_id");
//            entity.Property(e => e.Name)
//                .HasMaxLength(150)
//                .HasColumnName("name");
//            entity.Property(e => e.PrintDate).HasColumnName("print_date");

//            entity.HasOne(d => d.Author).WithMany(p => p.Books)
//                .HasForeignKey(d => d.AuthorId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("fk_books_author");

//            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
//                .HasForeignKey(d => d.GenreId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("fk_books_genre");
//        });

//        modelBuilder.Entity<Genre>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("genres_pk");

//            entity.ToTable("genres", "content");

//            entity.HasIndex(e => e.Name, "genres_unique").IsUnique();

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.Name)
//                .HasColumnType("character varying")
//                .HasColumnName("name");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Content
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("books_pk");

            entity.ToTable("books", "content");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.PrintDate).HasColumnName("print_date");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_books_author");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_books_genre");
        }
    }
}

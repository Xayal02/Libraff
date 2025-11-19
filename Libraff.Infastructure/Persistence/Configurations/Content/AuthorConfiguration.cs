using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Content
{
    public class AuthorConfiguration : IEntityTypeConfiguration<AuthorEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("authors_pk");

            entity.ToTable("authors", "content");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.DateOfDeath).HasColumnName("date_of_death");
            entity.Property(e => e.FirstName)
                .HasColumnType("character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.LastName)
                .HasColumnType("character varying")
                .HasColumnName("last_name");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying")
                .HasColumnName("patronymic");
        }
    }
}

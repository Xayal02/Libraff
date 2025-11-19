using Libraff.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> entity)
        {
			entity.HasKey(e => e.Id).HasName("persons_pkey");

			entity.ToTable("persons", "organization");

			entity.HasIndex(e => e.Pin, "persons_pin_key").IsUnique();

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.ContactNumber)
				.HasMaxLength(20)
				.HasColumnName("contact_number");
			entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
			entity.Property(e => e.FirstName)
				.HasMaxLength(40)
				.HasColumnName("first_name");
			entity.Property(e => e.InsertedDate)
				.HasDefaultValueSql("CURRENT_TIMESTAMP")
				.HasColumnType("timestamp without time zone")
				.HasColumnName("inserted_date");
			entity.Property(e => e.LastName)
				.HasMaxLength(50)
				.HasColumnName("last_name");
			entity.Property(e => e.Patronymic)
				.HasMaxLength(40)
				.HasColumnName("patronymic");
			entity.Property(e => e.Pin)
				.HasMaxLength(7)
				.HasColumnName("pin");
			entity.Property(e => e.ResidentialAddress)
				.HasMaxLength(150)
				.HasColumnName("residential_address");
			entity.Property(e => e.UpdatedDate)
				.HasColumnType("timestamp without time zone")
				.HasColumnName("updated_date");
		}
	}
}

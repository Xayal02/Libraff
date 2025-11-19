namespace Libraff.Infrastructure.Persistence.Entities;

public partial class PersonEntity
{
    public int Id { get; set; }

    public string Pin { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? ResidentialAddress { get; set; }

    public string ContactNumber { get; set; } = null!;

    public DateTime InsertedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<EmploymentHistoryEntity> EmploymentHistories { get; set; } = new List<EmploymentHistoryEntity>();
}

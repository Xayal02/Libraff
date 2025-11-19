namespace Libraff.Infrastructure.Persistence.Entities;

public partial class AuthorEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public DateOnly? DateOfDeath { get; set; }

    public int GenderId { get; set; }

    public virtual ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();
}

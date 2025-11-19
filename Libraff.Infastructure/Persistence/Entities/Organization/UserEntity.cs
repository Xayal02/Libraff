namespace Libraff.Infrastructure.Persistence.Entities;

public partial class UserEntity
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHashed { get; set; } = null!;

    public int EmployeeId { get; set; }

    public int RoleId { get; set; }

    public string EmailAddress { get; set; } = null!;

    public bool IsActive { get; set; }
}

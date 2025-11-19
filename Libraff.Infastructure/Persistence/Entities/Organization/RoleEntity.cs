namespace Libraff.Infrastructure.Persistence.Entities;

public partial class RoleEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}

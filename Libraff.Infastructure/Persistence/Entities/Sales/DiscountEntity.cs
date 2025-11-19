namespace Libraff.Infrastructure.Persistence.Entities;

public partial class DiscountEntity
{
    public int Id { get; set; }

    public int DiscountTypeId { get; set; }

    public int ReferenceId { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }

    public decimal Percent { get; set; }
}

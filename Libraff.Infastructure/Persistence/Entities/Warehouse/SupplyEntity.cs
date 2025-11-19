namespace Libraff.Infrastructure.Persistence.Entities;

public partial class SupplyEntity
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public int SupplierId { get; set; }

    public DateTime SupplyDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<SupplyDetailEntity> SupplyDetails { get; set; } = new List<SupplyDetailEntity>();
}

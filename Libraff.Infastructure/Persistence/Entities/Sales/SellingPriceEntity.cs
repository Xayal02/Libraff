namespace Libraff.Infrastructure.Persistence.Entities;

public partial class SellingPriceEntity
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public int SupplyDetailId { get; set; }

    public decimal Price { get; set; }

    public virtual SupplyDetailEntity SupplyDetail { get; set; } = null!;
}

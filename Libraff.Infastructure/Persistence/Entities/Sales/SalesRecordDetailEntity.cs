namespace Libraff.Infrastructure.Persistence.Entities;

public partial class SalesRecordDetailEntity
{
    public int Id { get; set; }

    public int SalesRecordId { get; set; }

    public int SupplyDetailId { get; set; }

    public short Quantity { get; set; }

    public decimal FixedPrice { get; set; }

    public decimal? PriceAfterDiscount { get; set; }

    public virtual SalesRecordEntity SalesRecord { get; set; } = null!;

    public virtual SupplyDetailEntity SupplyDetail { get; set; } = null!;
}

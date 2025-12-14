namespace Libraff.Infrastructure.Persistence.Entities;

public partial class SupplyDetailEntity
{
    public int Id { get; set; }

    public int SupplyId { get; set; }

    public int BookId { get; set; }

    public int InitialCount { get; set; }

    public decimal PricePerBook { get; set; }

    public virtual ICollection<BranchStockEntity> BranchStocks { get; set; } = new List<BranchStockEntity>();

    public virtual ICollection<BranchTransferEntity> BranchTransfers { get; set; } = new List<BranchTransferEntity>();

    public virtual ICollection<SalesRecordDetailEntity> SalesRecordDetails { get; set; } = new List<SalesRecordDetailEntity>();

    public virtual ICollection<SellingPriceEntity> SellingPrices { get; set; } = new List<SellingPriceEntity>();

    public virtual ICollection<StockEntity> Stocks { get; set; } = new List<StockEntity>();

    public virtual SupplyEntity Supply { get; set; } = null!;
}

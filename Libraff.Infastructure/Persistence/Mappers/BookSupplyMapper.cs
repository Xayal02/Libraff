using Libraff.Domain;

namespace Libraff.Infrastructure.Persistence.Mappers
{
    internal class BookSupplyMapper
    {
        public static (SupplyEntity, List<SupplyDetailEntity>, List<StockEntity>) ToEntities(BookSupply bookSupply)
        {
            SupplyEntity supplyEntity = new()
            {
                InvoiceNumber = bookSupply.InvoiceNumber.Value,
                SupplierId = bookSupply.SupplierId,
                SupplyDate = bookSupply.SupplyDate,
                CreatedAt = DateTime.Now
            };

            List<SupplyDetailEntity> supplyDetailEntities = new();

            List<StockEntity> stockEntities = new();

            foreach (var bookSupplyDetail in bookSupply.BookItems)
            {
                SupplyDetailEntity supplyDetailEntity = new()
                {
                    BookId = bookSupplyDetail.BookId,
                    InitialCount = bookSupplyDetail.Count,
                    PricePerBook = bookSupplyDetail.PricePerBook,
                    Supply = supplyEntity

                };

                supplyDetailEntities.Add(supplyDetailEntity);


                StockEntity stockEntity = new()
                {
                    AvailableCount = bookSupplyDetail.Count,
                    SupplyDetail = supplyDetailEntity
                };

                stockEntities.Add(stockEntity);


            }

            return (supplyEntity, supplyDetailEntities, stockEntities);

        }
    }
}

using Libraff.Domain;

namespace Libraff.Infrastructure.Persistence.Mappers
{
    internal class BookSupplyMapper
    {
        public static (SupplyEntity, List<SupplyDetailEntity>, List<StockEntity>) ToNewEntities(BookSupply bookSupply)
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

        public static (SupplyDetailEntity,StockEntity) ToNewSupplyDetailAndStockEntities(int supplyId,   BookSupplyDetail bookSupplyDetail)
        {

            SupplyDetailEntity supplyDetailEntity = new SupplyDetailEntity()
            {
                SupplyId = supplyId,
                BookId = bookSupplyDetail.BookId,
                InitialCount = bookSupplyDetail.Count,
                PricePerBook = bookSupplyDetail.PricePerBook
            };

            StockEntity stockEntity = new()
            { 
                AvailableCount = bookSupplyDetail.Count,
                SupplyDetail = supplyDetailEntity
            };

            return (supplyDetailEntity, stockEntity);

        }

        public static (SupplyDetailEntity, StockEntity) ToUpdatedSupplyDetailAndStockEntities(BookSupplyDetail bookSupplyDetail, SupplyDetailEntity supplyDetailEntity, StockEntity stockEntity )
        {
            supplyDetailEntity.InitialCount += bookSupplyDetail.Count;
            stockEntity.AvailableCount += bookSupplyDetail.Count; //also possible to add modified_at and modified_by in future (I didnt take into consideration this properties)

            return (supplyDetailEntity, stockEntity);
        }

    }

}

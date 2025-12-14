using Libraff.Domain.Constants;
using Libraff.Domain.Exceptions;

namespace Libraff.Domain
{
    public class BookSupply
    {
        public int Id { get; }
        public InvoiceNumber InvoiceNumber { get; }
        public int SupplierId { get; }
        public DateTime SupplyDate { get; }
        public IList<BookSupplyDetail> BookItems { get; private set; }

        private BookSupply(InvoiceNumber invoiceNumber, int supplierId,DateTime? supplyDate, IList<BookSupplyDetail>? bookItems)
        {
            if (supplierId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(SupplierId)));

            InvoiceNumber = invoiceNumber;  
            SupplierId = supplierId;
            SupplyDate = supplyDate ?? DateTime.Now;
            BookItems = bookItems ?? new List<BookSupplyDetail>(); 
        }  

        internal static BookSupply Create(InvoiceNumber invoiceNumber, int suppliedId, DateTime? supplyDate, IList<BookSupplyDetail>? bookItems)
        {
            return new BookSupply(invoiceNumber, suppliedId,  supplyDate, bookItems);
        }

        

    }

}

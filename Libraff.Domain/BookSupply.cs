using Libraff.Domain.Constants;

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
                throw new ArgumentException(DomainErrorMessages.Required(nameof(SupplierId)));

            InvoiceNumber = invoiceNumber;  
            SupplierId = supplierId;
            SupplyDate = supplyDate ?? DateTime.Now;
            BookItems = bookItems ?? new List<BookSupplyDetail>(); // dont sure about this collection IList, ICollection
        }  

        internal static BookSupply Create(InvoiceNumber invoiceNumber, int suppliedId, DateTime? supplyDate, IList<BookSupplyDetail>? bookItems)
        {
            return new BookSupply(invoiceNumber, suppliedId,  supplyDate, bookItems);
        }

        internal void AddBookItem(BookSupplyDetail bookItem)
        {
            if (BookItems.Any(b => b.BookId == bookItem.BookId &&
                                   b.PricePerBook == bookItem.PricePerBook))
                throw new InvalidOperationException(""); //error

            BookSupplyDetail? addedBookItem = BookItems.
                Where(b => b.BookId == bookItem.BookId)
                .FirstOrDefault();

            if (addedBookItem is null)
                BookItems.Add(bookItem);
            else
            {
                if (addedBookItem.PricePerBook != bookItem.PricePerBook)
                    throw new InvalidOperationException(""); //errorMessage

                addedBookItem.Count += bookItem.Count;
            }

        }

        internal void AddAdditionalBookItem(int bookId, int count = 1)
        {
            if (bookId <= 0)
                throw new ArgumentException(DomainErrorMessages.Required(nameof(bookId)));

            BookSupplyDetail? addedBookItem = BookItems.
                Where(b => b.BookId == bookId)
                .FirstOrDefault();

            if (addedBookItem is null)
                throw new ArgumentException(""); //error message

            addedBookItem.Count += count;

        }

        internal void RemoveBookItem(int bookId)
        {
            if (bookId <= 0)
                throw new ArgumentException(DomainErrorMessages.Required(nameof(bookId)));

            BookSupplyDetail? bookItem = BookItems
                .Where(b => b.BookId == bookId)
                .FirstOrDefault();

            if (bookItem is null)
                throw new ArgumentException(""); //error message

            BookItems.Remove(bookItem);

        }

        internal void UpdateBookItemCount(int bookId, int count )
        {
            if (bookId <= 0)
                throw new ArgumentException(DomainErrorMessages.Required(nameof(bookId)));

            if (count <= 0)
                throw new ArgumentException(DomainErrorMessages.Required(nameof(count)));

            BookSupplyDetail? bookItem = BookItems.
                Where(b => b.BookId == bookId)
                .FirstOrDefault();

            if (bookItem is null)
                throw new ArgumentException(""); //error message

            bookItem.Count = count;
        }

        //I neeed here count

    }

}

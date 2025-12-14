using Libraff.Domain.Constants;
using Libraff.Domain.Exceptions;

namespace Libraff.Domain
{
    public class BookSupplyDetail
    {
        public int BookId { get;  }
        public decimal PricePerBook { get; private set; }
        public int Count { get; internal set; } 

        private BookSupplyDetail(int bookId, decimal pricePerBook, int count)
        {
            if (bookId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(BookId)));

            if (pricePerBook <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(PricePerBook)));

            BookId = bookId;
            PricePerBook = pricePerBook;
            Count = count;
        }

        public static BookSupplyDetail Create(int bookId, decimal pricePerBook, int count = 1)
        {
            return new BookSupplyDetail(bookId, pricePerBook, count);

        }

        public static BookSupplyDetail? Empty()
        {
            return null;
        }
    }

}

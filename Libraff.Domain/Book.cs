using Libraff.Domain.Constants;

namespace Libraff.Domain
{
    public class Book
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int AuthorId { get; private set; }
        public int GenreId { get; private set; }
        public DateOnly PrintDate { get; private set; }

        private Book(string name, int authorId, int genreId, DateOnly printDate)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(DomainErrorMessages.Required(nameof(Name)));

            if (authorId <= 0)
                throw new ArgumentException(DomainErrorMessages.MustBeGreaterThanZero(nameof(AuthorId)));

            if (genreId <= 0)
                throw new ArgumentException(DomainErrorMessages.MustBeGreaterThanZero(nameof(genreId)));

            Name = name;
            AuthorId = authorId;
            GenreId = genreId;
            PrintDate = printDate;
        }

        public Book Create(string name, int authorId, int genreId, DateOnly printDate)
        {
            return new Book(name, authorId, genreId, printDate);
        }
    }




}

using System;
using System.Collections.Generic;

namespace Libraff.Infrastructure.Persistence.Entities;

public partial class BookEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AuthorId { get; set; }

    public int GenreId { get; set; }

    public DateOnly PrintDate { get; set; }

    public virtual AuthorEntity Author { get; set; } = null!;

    public virtual GenreEntity Genre { get; set; } = null!;
}

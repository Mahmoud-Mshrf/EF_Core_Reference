using System;
using System.Collections.Generic;

namespace ReverseEngineering.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public int AuthorId { get; set; }

    public virtual Authorss Author { get; set; } = null!;
}

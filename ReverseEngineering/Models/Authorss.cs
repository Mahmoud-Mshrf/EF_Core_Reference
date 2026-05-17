using System;
using System.Collections.Generic;

namespace ReverseEngineering.Models;

public partial class Authorss
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int NationalityId { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Nationality Nationality { get; set; } = null!;
}

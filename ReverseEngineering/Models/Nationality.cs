using System;
using System.Collections.Generic;

namespace ReverseEngineering.Models;

public partial class Nationality
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Authorss> Authorsses { get; set; } = new List<Authorss>();
}

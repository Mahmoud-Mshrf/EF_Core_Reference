using System;
using System.Collections.Generic;

namespace Database_Scaffolding.Models;

public partial class WishList
{
    public int WishId { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

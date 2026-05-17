using System;
using System.Collections.Generic;

namespace Database_Scaffolding.Models;

public partial class Seller
{
    public int SellerId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int AdminId { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

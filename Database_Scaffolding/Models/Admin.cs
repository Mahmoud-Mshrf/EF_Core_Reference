using System;
using System.Collections.Generic;

namespace Database_Scaffolding.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}

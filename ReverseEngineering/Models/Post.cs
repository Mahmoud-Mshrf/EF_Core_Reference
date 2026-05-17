using System;
using System.Collections.Generic;

namespace ReverseEngineering.Models;

public partial class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int BlogId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Blog Blog { get; set; } = null!;
}

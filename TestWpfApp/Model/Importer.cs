using System;
using System.Collections.Generic;

namespace TestWpfApp.Model;

public partial class Importer
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

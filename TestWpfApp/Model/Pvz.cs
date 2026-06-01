using System;
using System.Collections.Generic;

namespace TestWpfApp.Model;

public partial class Pvz
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

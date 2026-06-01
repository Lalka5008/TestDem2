using System;
using System.Collections.Generic;

namespace TestWpfApp.Model;

public partial class Status
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

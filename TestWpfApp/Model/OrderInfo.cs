using System;
using System.Collections.Generic;

namespace TestWpfApp.Model;

public partial class OrderInfo
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public string? ArticleId { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? Article { get; set; }

    public virtual Order? Order { get; set; }
}

using System;
using System.Collections.Generic;

namespace TestWpfApp.Model;

public partial class Product
{
    public string Article { get; set; } = null!;

    public int? NameId { get; set; }

    public decimal? Price { get; set; }

    public int? ImporterId { get; set; }

    public int? ProducerId { get; set; }

    public int? CategoryId { get; set; }

    public int? CurrentSale { get; set; }

    public int? Quantity { get; set; }

    public string? Info { get; set; }

    public string? Photo { get; set; }

    public string ImageFullPath => !string.IsNullOrWhiteSpace(Photo) ? $"Images/{Photo}" : "Images/picture.png";

    public int? UnitId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Importer? Importer { get; set; }

    public virtual ProductName? Name { get; set; }

    public virtual ICollection<OrderInfo> OrderInfos { get; set; } = new List<OrderInfo>();

    public virtual Producer? Producer { get; set; }

    public virtual UnitType? Unit { get; set; }
}

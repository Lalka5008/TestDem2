using System;
using System.Collections.Generic;

namespace TestWpfApp.Model;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly? PurschaseDay { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public int? Pvzid { get; set; }

    public int? UserNameId { get; set; }

    public int? SecurityCode { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<OrderInfo> OrderInfos { get; set; } = new List<OrderInfo>();

    public virtual Pvz? Pvz { get; set; }

    public virtual Status? Status { get; set; }

    public virtual User? UserName { get; set; }
}

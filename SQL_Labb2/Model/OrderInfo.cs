using System;
using System.Collections.Generic;

namespace SQL_Labb2.Model;

public partial class OrderInfo
{
    public int OrderId { get; set; }

    public string Isbn { get; set; } = null!;

    public int? Antal { get; set; }

    public decimal? PrisPerEnhet { get; set; }

    public int Id { get; set; }

    public virtual Böcker IsbnNavigation { get; set; } = null!;

    public virtual ICollection<Ordrar> Ordrars { get; set; } = new List<Ordrar>();
}

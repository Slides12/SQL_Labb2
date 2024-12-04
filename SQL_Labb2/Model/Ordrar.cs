using System;
using System.Collections.Generic;

namespace SQL_Labb2.Model;

public partial class Ordrar
{
    public int Id { get; set; }

    public int KundId { get; set; }

    public DateTime? Datum { get; set; }

    public virtual OrderInfo IdNavigation { get; set; } = null!;

    public virtual KundInfo Kund { get; set; } = null!;
}

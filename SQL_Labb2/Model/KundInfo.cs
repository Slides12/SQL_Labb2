using System;
using System.Collections.Generic;

namespace SQL_Labb2.Model;

public partial class KundInfo
{
    public int KundId { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public string? Email { get; set; }

    public string? Telefonnummer { get; set; }

    public string? Personnummer { get; set; }

    public virtual ICollection<Ordrar> Ordrars { get; set; } = new List<Ordrar>();
}

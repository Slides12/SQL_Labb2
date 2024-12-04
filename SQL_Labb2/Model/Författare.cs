using System;
using System.Collections.Generic;

namespace SQL_Labb2.Model;

public partial class Författare
{
    public int Id { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public DateOnly? Födelesedatum { get; set; }

    public virtual ICollection<Böcker> Isbns { get; set; } = new List<Böcker>();
}

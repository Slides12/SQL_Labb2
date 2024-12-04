using System;
using System.Collections.Generic;

namespace SQL_Labb2.Model;

public partial class PersonalInfo
{
    public int PersonalId { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public string? Email { get; set; }

    public int ButikId { get; set; }

    public virtual Butiker Butik { get; set; } = null!;
}

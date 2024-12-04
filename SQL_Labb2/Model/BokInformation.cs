using System;
using System.Collections.Generic;
using SQL_Labb2.Model;
namespace SQL_Labb2;

public partial class BokInformation
{
    public string Isbn { get; set; } = null!;

    public string? Beskrivning { get; set; }

    public string? Genre { get; set; }

    public string? Utgivare { get; set; }

    public virtual Böcker? Böcker { get; set; }
}

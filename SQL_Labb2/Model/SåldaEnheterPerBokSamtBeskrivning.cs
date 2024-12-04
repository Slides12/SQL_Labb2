using System;
using System.Collections.Generic;

namespace SQL_Labb2.Model;

public partial class SåldaEnheterPerBokSamtBeskrivning
{
    public string? Titel { get; set; }

    public string Författare { get; set; } = null!;

    public string? Beskrivning { get; set; }

    public string? Genre { get; set; }

    public string? PrisPerBok { get; set; }

    public int? AntalSålda { get; set; }

    public string? TotalSåltPerBok { get; set; }

    public string AntalILager { get; set; } = null!;

    public string? Lagervärde { get; set; }
}

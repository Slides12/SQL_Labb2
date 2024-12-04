using System;
using System.Collections.Generic;

namespace SQL_Labb2.Model;

public partial class Butiker
{
    public int Id { get; set; }

    public string? ButiksNamn { get; set; }

    public string? Adressuppgifter { get; set; }

    public virtual ICollection<LagerSaldo> LagerSaldos { get; set; } = new List<LagerSaldo>();

    public virtual ICollection<PersonalInfo> PersonalInfos { get; set; } = new List<PersonalInfo>();
}

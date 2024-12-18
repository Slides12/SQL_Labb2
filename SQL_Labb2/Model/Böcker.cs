﻿using System;
using System.Collections.Generic;
using System.IO;

namespace SQL_Labb2.Model;

public partial class Böcker
{
    public string Isbn { get; set; } = null!;

    public string? Titel { get; set; }

    public string? Språk { get; set; }

    public decimal? Pris { get; set; }

    public DateOnly? Utgivningsdatum { get; set; }

    public virtual BokInformation IsbnNavigation { get; set; } = null!;

    public virtual ICollection<LagerSaldo> LagerSaldos { get; set; } = new List<LagerSaldo>();

    public virtual ICollection<OrderInfo> OrderInfos { get; set; } = new List<OrderInfo>();

    public virtual ICollection<Författare> Författares { get; set; } = new List<Författare>();


    public string Omslag
    {
        get
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Books", $"{Isbn}.jpg");

            if (File.Exists(filePath))
            {
                return filePath;
            }
            else
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Books", "0.jpg");
            }
        }
    }

}

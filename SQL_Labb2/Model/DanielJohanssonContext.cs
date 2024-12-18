using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SQL_Labb2.Model;

public partial class DanielJohanssonContext : DbContext
{
    public DanielJohanssonContext()
    {
    }

    public DanielJohanssonContext(DbContextOptions<DanielJohanssonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BokInformation> BokInformations { get; set; }

    public virtual DbSet<Butiker> Butikers { get; set; }

    public virtual DbSet<Böcker> Böckers { get; set; }

    public virtual DbSet<Författare> Författares { get; set; }

    public virtual DbSet<KundInfo> KundInfos { get; set; }

    public virtual DbSet<LagerSaldo> LagerSaldos { get; set; }

    public virtual DbSet<OrderInfo> OrderInfos { get; set; }

    public virtual DbSet<Ordrar> Ordrars { get; set; }

    public virtual DbSet<PersonalInfo> PersonalInfos { get; set; }

    public virtual DbSet<SåldaEnheterPerBokSamtBeskrivning> SåldaEnheterPerBokSamtBeskrivnings { get; set; }


    public virtual DbSet<TitlarPerFörfattare> TitlarPerFörfattares { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().AddUserSecrets<DanielJohanssonContext>().Build();
        var connectionString = config["ConnectionString"];
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BokInformation>(entity =>
        {
            entity.HasKey(e => e.Isbn);

            entity.ToTable("BokInformation");

            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Utgivare).HasMaxLength(50);
        });

        modelBuilder.Entity<Butiker>(entity =>
        {
            entity.ToTable("Butiker");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adressuppgifter).HasMaxLength(40);
            entity.Property(e => e.ButiksNamn)
                .HasMaxLength(40)
                .HasColumnName("Butiks Namn");
        });

        modelBuilder.Entity<Böcker>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__Böcker__447D36EB1BDFC5FF");

            entity.ToTable("Böcker");

            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");
            entity.Property(e => e.Pris).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Språk).HasMaxLength(20);
            entity.Property(e => e.Titel).HasMaxLength(50);

            entity.HasOne(d => d.IsbnNavigation).WithOne(p => p.Böcker)
                .HasForeignKey<Böcker>(d => d.Isbn)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Böcker_BokInformation");

            entity.HasMany(d => d.Författares).WithMany(p => p.Isbns)
                .UsingEntity<Dictionary<string, object>>(
                    "BöckerFörfattare",
                    r => r.HasOne<Författare>().WithMany()
                        .HasForeignKey("FörfattareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_BöckerFörfattare_Författare"),
                    l => l.HasOne<Böcker>().WithMany()
                        .HasForeignKey("Isbn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_BöckerFörfattare_Böcker"),
                    j =>
                    {
                        j.HasKey("Isbn", "FörfattareId").HasName("PK__BöckerFö__5C7927A6F9FFF6D6");
                        j.ToTable("BöckerFörfattare");
                        j.IndexerProperty<string>("Isbn")
                            .HasMaxLength(13)
                            .HasColumnName("ISBN");
                        j.IndexerProperty<int>("FörfattareId").HasColumnName("FörfattareID");
                    });
        });

        modelBuilder.Entity<Författare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Författa__3214EC274D5D5810");

            entity.ToTable("Författare");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Efternamn).HasMaxLength(15);
            entity.Property(e => e.Förnamn).HasMaxLength(40);
        });

        modelBuilder.Entity<KundInfo>(entity =>
        {
            entity.HasKey(e => e.KundId).HasName("PK__KundInfo__F2B5DEAC6A79B7A8");

            entity.ToTable("KundInfo");

            entity.Property(e => e.KundId).HasColumnName("KundID");
            entity.Property(e => e.Efternamn).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.Förnamn).HasMaxLength(20);
            entity.Property(e => e.Personnummer).HasMaxLength(30);
            entity.Property(e => e.Telefonnummer).HasMaxLength(30);
        });

        modelBuilder.Entity<LagerSaldo>(entity =>
        {
            entity.HasKey(e => new { e.ButikId, e.Isbn }).HasName("PK__LagerSal__1191B894AFF37367");

            entity.ToTable("LagerSaldo");

            entity.Property(e => e.ButikId).HasColumnName("ButikID");
            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");

            entity.HasOne(d => d.Butik).WithMany(p => p.LagerSaldos)
                .HasForeignKey(d => d.ButikId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LagerSaldo_Butiker");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.LagerSaldos)
                .HasForeignKey(d => d.Isbn)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LagerSaldo_Böcker");
        });

        modelBuilder.Entity<OrderInfo>(entity =>
        {
            entity.ToTable("OrderInfo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PrisPerEnhet).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.OrderInfos)
                .HasForeignKey(d => d.Isbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderInfo_Böcker");
        });

        modelBuilder.Entity<Ordrar>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.KundId }).HasName("PK_Ordrar_1");

            entity.ToTable("Ordrar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.KundId).HasColumnName("KundID");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Ordrars)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ordrar_OrderInfo");

            entity.HasOne(d => d.Kund).WithMany(p => p.Ordrars)
                .HasForeignKey(d => d.KundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ordrar_KundInfo");
        });

        modelBuilder.Entity<PersonalInfo>(entity =>
        {
            entity.HasKey(e => e.PersonalId);

            entity.ToTable("PersonalInfo");

            entity.Property(e => e.PersonalId)
                .ValueGeneratedNever()
                .HasColumnName("PersonalID");
            entity.Property(e => e.ButikId).HasColumnName("ButikID");
            entity.Property(e => e.Efternamn).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.Förnamn).HasMaxLength(20);

            entity.HasOne(d => d.Butik).WithMany(p => p.PersonalInfos)
                .HasForeignKey(d => d.ButikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonalInfo_Butiker");
        });

        modelBuilder.Entity<SåldaEnheterPerBokSamtBeskrivning>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SåldaEnheterPerBokSamtBeskrivning");

            entity.Property(e => e.AntalILager)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Antal i lager");
            entity.Property(e => e.AntalSålda).HasColumnName("Antal Sålda");
            entity.Property(e => e.Författare).HasMaxLength(56);
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Lagervärde).HasMaxLength(4000);
            entity.Property(e => e.PrisPerBok)
                .HasMaxLength(4000)
                .HasColumnName("Pris Per/Bok");
            entity.Property(e => e.Titel).HasMaxLength(50);
            entity.Property(e => e.TotalSåltPerBok)
                .HasMaxLength(4000)
                .HasColumnName("Total sålt Per/Bok");
        });

        

        modelBuilder.Entity<TitlarPerFörfattare>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TitlarPerFörfattare");

            entity.Property(e => e.Lagervärde).HasMaxLength(4000);
            entity.Property(e => e.Namn).HasMaxLength(56);
            entity.Property(e => e.Ålder)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

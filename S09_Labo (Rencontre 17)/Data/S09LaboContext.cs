using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using S09_Labo.Models;

namespace S09_Labo.Data;

public partial class S09LaboContext : DbContext
{
    public S09LaboContext()
    {
    }

    public S09LaboContext(DbContextOptions<S09LaboContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Changelog> Changelogs { get; set; }

    public virtual DbSet<Chanson> Chansons { get; set; }

    public virtual DbSet<Chanteur> Chanteurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=S09_Labo");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Changelog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__changelo__3213E83FC62D092F");

            entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Chanson>(entity =>
        {
            entity.HasKey(e => e.ChansonId).HasName("PK_Chanson_ChansonID");

            entity.HasOne(d => d.Chanteur).WithMany(p => p.Chansons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chanson_ChanteurID");
        });

        modelBuilder.Entity<Chanteur>(entity =>
        {
            entity.HasKey(e => e.ChanteurId).HasName("PK_Chanteur_ChanteurID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

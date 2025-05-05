using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WrapUpBilleterie.Models;

namespace WrapUpBilleterie.Data;

public partial class R22_BilleterieContext : DbContext
{
    public R22_BilleterieContext()
    {
    }

    public R22_BilleterieContext(DbContextOptions<R22_BilleterieContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Affiche> Affiches { get; set; }

    public virtual DbSet<Billet> Billets { get; set; }

    public virtual DbSet<Changelog> Changelogs { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Representation> Representations { get; set; }

    public virtual DbSet<Spectacle> Spectacles { get; set; }

    public virtual DbSet<VwSpectaclesRepresentationSpectateur> VwSpectaclesRepresentationSpectateurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=R22_Billeterie");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Affiche>(entity =>
        {
            entity.HasKey(e => e.AfficheId).HasName("PK_Affiche_AfficheID");

            entity.Property(e => e.Identifiant).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Spectacle).WithMany(p => p.Affiches).HasConstraintName("FK_Affiche_SpectacleID");
        });

        modelBuilder.Entity<Billet>(entity =>
        {
            entity.HasKey(e => e.BilletId).HasName("PK_Billet_BilletID");

            entity.HasOne(d => d.Client).WithMany(p => p.Billets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Billet_ClientID");

            entity.HasOne(d => d.Representation).WithMany(p => p.Billets).HasConstraintName("FK_Billet_RepresentationID");
        });

        modelBuilder.Entity<Changelog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__changelo__3213E83FE4E0D099");

            entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK_Client_ClientID");
        });

        modelBuilder.Entity<Representation>(entity =>
        {
            entity.HasKey(e => e.RepresentationId).HasName("PK_Representation_RepresentationID");

            entity.Property(e => e.DateHeureRepresentation).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Spectacle).WithMany(p => p.Representations).HasConstraintName("FK_Representation_SpectacleID");
        });

        modelBuilder.Entity<Spectacle>(entity =>
        {
            entity.HasKey(e => e.SpectacleId).HasName("PK_Spectacle_SpectacleID");
        });

        modelBuilder.Entity<VwSpectaclesRepresentationSpectateur>(entity =>
        {
            entity.ToView("VW_SpectaclesRepresentationSpectateurs", "Spectacles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

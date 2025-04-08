using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using S08_Labo.Models;

namespace S08_Labo.Data;

public partial class S08EmployesContext : DbContext
{
    public S08EmployesContext()
    {
    }

    public S08EmployesContext(DbContextOptions<S08EmployesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artiste> Artistes { get; set; }

    public virtual DbSet<Employe> Employes { get; set; }

    public virtual DbSet<VwListeArtiste> VwListeArtistes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=EmployesBD");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artiste>(entity =>
        {
            entity.HasKey(e => e.ArtisteId).HasName("PK_Artiste_ArtisteID");

            entity.ToTable("Artiste", "Employes", tb => tb.HasTrigger("trg_dArtiste"));

            entity.HasOne(d => d.Employe).WithMany(p => p.Artistes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Artiste_EmployeID");
        });

        modelBuilder.Entity<Employe>(entity =>
        {
            entity.HasKey(e => e.EmployeId).HasName("PK_Employe_EmployeID");

            entity.Property(e => e.NoTel).IsFixedLength();
        });

        modelBuilder.Entity<VwListeArtiste>(entity =>
        {
            entity.ToView("VW_ListeArtistes", "Employes");

            entity.Property(e => e.NoTel).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

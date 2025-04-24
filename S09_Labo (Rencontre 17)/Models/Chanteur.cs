using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace S09_Labo.Models;

[Table("Chanteur", Schema = "Musique")]
public partial class Chanteur
{
    [StringLength(50)]
    public string Nom { get; set; } = null!;

    public DateOnly DateNaissance { get; set; }

    [Key]
    [Column("ChanteurID")]
    public int ChanteurId { get; set; }

    [InverseProperty("Chanteur")]
    public virtual ICollection<Chanson> Chansons { get; set; } = new List<Chanson>();
}

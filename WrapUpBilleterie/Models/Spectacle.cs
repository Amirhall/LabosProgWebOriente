using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WrapUpBilleterie.Models;

[Table("Spectacle", Schema = "Spectacles")]
[Index("Nom", Name = "UC_Spectacle_Nom", IsUnique = true)]
public partial class Spectacle
{
    [Key]
    [Column("SpectacleID")]
    public int SpectacleId { get; set; }

    [StringLength(80)]
    public string Nom { get; set; } = null!;

    public DateOnly Debut { get; set; }

    public DateOnly Fin { get; set; }

    [Column(TypeName = "money")]
    public decimal Prix { get; set; }

    [InverseProperty("Spectacle")]
    public virtual ICollection<Affiche> Affiches { get; set; } = new List<Affiche>();

    [InverseProperty("Spectacle")]
    public virtual ICollection<Representation> Representations { get; set; } = new List<Representation>();
}

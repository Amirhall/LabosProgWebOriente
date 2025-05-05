using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WrapUpBilleterie.Models;

[Table("Representation", Schema = "Spectacles")]
public partial class Representation
{
    [Key]
    [Column("RepresentationID")]
    public int RepresentationId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateHeureRepresentation { get; set; }

    [Column("SpectacleID")]
    public int SpectacleId { get; set; }

    [InverseProperty("Representation")]
    public virtual ICollection<Billet> Billets { get; set; } = new List<Billet>();

    [ForeignKey("SpectacleId")]
    [InverseProperty("Representations")]
    public virtual Spectacle Spectacle { get; set; } = null!;
}

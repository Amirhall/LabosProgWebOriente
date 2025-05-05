using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WrapUpBilleterie.Models;

[Keyless]
public partial class VwSpectaclesRepresentationSpectateur
{
    [Column("SpectacleID")]
    public int SpectacleId { get; set; }

    [StringLength(80)]
    public string Nom { get; set; } = null!;

    public DateOnly Debut { get; set; }

    public DateOnly Fin { get; set; }

    [Column(TypeName = "money")]
    public decimal Prix { get; set; }

    public int? NbRepresentations { get; set; }

    public int? NbBilletsVendus { get; set; }
}

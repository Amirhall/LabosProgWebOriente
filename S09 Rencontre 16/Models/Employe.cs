﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace S08_Labo.Models;

[Table("Employe", Schema = "Employes")]
public partial class Employe
{
    [Key]
    [Column("EmployeID")]
    public int EmployeId { get; set; }

    [StringLength(50)]
    public string Prenom { get; set; } = null!;

    [StringLength(50)]
    public string Nom { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string NoTel { get; set; } = null!;

    [StringLength(255)]
    public string? Courriel { get; set; }

    public DateOnly DateEmbauche { get; set; }

    [StringLength(50)]
    public string Poste { get; set; } = null!;

    [InverseProperty("Employe")]
    public virtual ICollection<Artiste> Artistes { get; set; } = new List<Artiste>();
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Entities.POCOs;
[Table("Seguros")]
public class Seguro
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("IdSeguro")]
    public int IdSeguro { get; set; }
    [Required]
    [StringLength(100)]
    [Column("Nombre")]
    public string Nombre { get; set; }=String.Empty;
    [Required]
    [StringLength(10)]
    [Column("Codigo")]
    public string Codigo { get; set; }=String.Empty;
    [Required]
    [Column("SumaAsegurada", TypeName = "decimal(10,2)")]
    [Precision(10,2)]
    public decimal SumaAsegurada { get; set; }
    [Required]
    [Column("Prima", TypeName = "decimal(10,2)")]
    [Precision(10, 2)]
    public decimal Prima { get; set; }    
    [Required]
    [Column("IdCliente")]
    public int IdCliente { get; set; }
    [ForeignKey("IdCliente")]
    public virtual Cliente? Cliente { get; set; }
}

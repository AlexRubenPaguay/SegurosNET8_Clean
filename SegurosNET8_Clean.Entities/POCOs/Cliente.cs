using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Entities.POCOs;
[Table("Clientes")]
[Index(nameof(Cedula), IsUnique = true)]
public class Cliente
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("IdCliente")]
    public int IdCliente { get; set; }
    [Required]
    [StringLength(10)]    
    [Column("Cedula")]
    public string? Cedula { get; set; }
    [Required]
    [StringLength(100)]
    [Column("Nombre")]
    public string? Nombre { get; set; }    
    [StringLength(10)]
    [Column("Telefono")]
    public string? Telefono { get; set; }
    [Required]    
    [Column("Edad")]
    public int Edad { get; set; }
    public virtual ICollection<Seguro> Seguros { get; set; } = new List<Seguro>();
}

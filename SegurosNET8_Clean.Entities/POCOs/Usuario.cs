using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Entities.POCOs;
[Table("Usuarios")]
[Index(nameof(Correo), IsUnique = true)]
[Index(nameof(NombreUsuario),IsUnique =true)]
public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("IdUsuario")]
    public int IdUsuario { get; set; }
    [Required]
    [Column("Usuario")]
    [StringLength(15)]
    public String NombreUsuario { get; set; }=String.Empty;
    [Required]    
    [StringLength(10)]
    public String Password { get; set; }=String.Empty;  
    [Required]
    [StringLength(100)]
    public String NombreCompleto { get; set; }=String.Empty;
    [Required]
    [StringLength(40)]
    public String Correo { get; set; }=String.Empty;
    [Required]
    public DateTime FechaCreacion { get; set; }
    [Required]
    [StringLength(15)]
    public String TipoUsuario { get; set; }=String.Empty ;
}

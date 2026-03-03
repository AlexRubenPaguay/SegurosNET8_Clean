using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.DTOs;

public class ResponseUsuarioDTO
{
    public int IdUsuario { get; set; }
    public String NombreUsuario { get; set; } = String.Empty;
    public String Password { get; set; } = String.Empty;
    public String NombreCompleto { get; set; } = String.Empty;
    public String Correo { get; set; } = String.Empty;
    public DateTime FechaCreacion { get; set; }
    public String TipoUsuario { get; set; } = String.Empty;
}

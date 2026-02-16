using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.DTOs;
public class ResponseClienteDTO
{
    public int IdCliente { get; set; }
    public string? Cedula { get; set; }
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    public int Edad { get; set; }
}

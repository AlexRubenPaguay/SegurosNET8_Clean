using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.DTOs;

public class CrearSeguroDTO
{
    public string? Nombre { get; set; }
    public string? Codigo { get; set; }
    public decimal Suma { get; set; }
    public decimal Prima { get; set; }
    public int IdCliente { get; set; }
}

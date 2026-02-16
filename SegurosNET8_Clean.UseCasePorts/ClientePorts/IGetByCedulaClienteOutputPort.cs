using SegurosNET8_Clean.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCasePorts.ClientePorts;

public interface IGetByCedulaClienteOutputPort
{
    Task Handle(ResponseClienteDTO clientesDTO);
}

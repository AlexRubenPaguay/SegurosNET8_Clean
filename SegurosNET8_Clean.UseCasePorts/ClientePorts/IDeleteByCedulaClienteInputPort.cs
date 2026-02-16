using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCasePorts.ClientePorts;

public interface IDeleteByCedulaClienteInputPort
{
    Task Handle(string cedula);
}

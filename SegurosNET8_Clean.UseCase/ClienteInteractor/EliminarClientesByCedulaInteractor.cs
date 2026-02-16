using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.Cliente;

public class EliminarClientesByCedulaInteractor(IClienteRepository _repository, IDeleteByCedulaClienteOutputPort outputPort) : IDeleteByCedulaClienteInputPort
{
    public Task Handle(string cedula)
    {
        _repository.Delete(cedula);
        outputPort.Handle($"Cliente con cédula [{cedula}] se ha eliminado correctamente.");
        return Task.CompletedTask;
    }
}

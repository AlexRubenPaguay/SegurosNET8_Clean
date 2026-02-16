using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.Cliente;

public class ObtenerClientesByCedulaInteractor(IClienteRepository _repository, IGetByCedulaClienteOutputPort outputPort) : IGetByCedulaClienteInputPort
{
    public Task Handle(string cedula)
    {
        var cliente = _repository.Get(cedula);

        var clienteDTO = new ResponseClienteDTO
        {
            IdCliente = cliente.Result.IdCliente,
            Cedula = cliente.Result.Cedula,
            Nombre = cliente.Result.Nombre,
            Telefono = cliente.Result.Telefono,
            Edad = cliente.Result.Edad
        };

        outputPort.Handle(clienteDTO);
        return Task.CompletedTask;
    }
}

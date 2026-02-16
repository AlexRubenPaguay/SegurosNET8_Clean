using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.Entities.POCOs;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.RequestClienteInteractor;

public class ActualizarClienteInteractor(IClienteRepository _repository, IUpdateClienteOutputPort outputPort) : IUpdateClienteInputPort
{
    public Task Handle(int IdCliente, CrearClienteDTO clienteDTO)
    {
        var newCliente = new Entities.POCOs.Cliente
        {
            Cedula = clienteDTO.Cedula,
            Nombre = clienteDTO.Nombre,
            Telefono = clienteDTO.Telefono,
            Edad = clienteDTO.Edad
        };
        _repository.update(IdCliente, newCliente);
        outputPort.Handle($"El cliente con cédula [{clienteDTO.Cedula}] se ha actualizado correctamente.");
        return Task.CompletedTask;
    }
}

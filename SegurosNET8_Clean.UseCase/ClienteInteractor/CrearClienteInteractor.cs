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

public class CrearClienteInteractor(IClienteRepository _repository, ICrearClienteOutputPort outputPort) : ICrearClienteInputPort
{
    public Task Handle(CrearClienteDTO clienteDTO)
    {
        var newCiente = new Entities.POCOs.Cliente
        {
            Cedula = clienteDTO.Cedula,
            Nombre = clienteDTO.Nombre,
            Telefono = clienteDTO.Telefono,
            Edad = clienteDTO.Edad
        };
        try
        {
            _repository.save(newCiente);
            outputPort.Handle($"El cliente con cédula [{newCiente.Cedula}] se ha creado exitosamente.");
        }
        catch (Exception ex)
        {
            outputPort.Handle($"Error al guardar el cliente: {ex}");
        }
        return Task.CompletedTask;
    }
}

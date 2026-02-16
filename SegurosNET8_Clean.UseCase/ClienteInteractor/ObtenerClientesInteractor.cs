using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.Cliente;

public class ObtenerClientesInteractor(IClienteRepository _repository, IGetAllClienteOutputPort outputPort) : IGetAllClienteInputPort
{
    public Task Handle()
    {
        List<ResponseClienteDTO> clientesDTO = new List<ResponseClienteDTO>();
        var clientes = _repository.GetAll();
        foreach (var cliente in clientes.Result)
        {
            var clienteDTO = new ResponseClienteDTO
            {
                IdCliente = cliente.IdCliente,
                Cedula = cliente.Cedula,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono,
                Edad = cliente.Edad
            };
            clientesDTO.Add(clienteDTO);
        }
        outputPort.Handle(clientesDTO);
        return Task.CompletedTask;
    }
}

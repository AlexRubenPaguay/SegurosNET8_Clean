using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.ClienteInteractor;

public class ObtenerClientesByIdInteractor(IClienteRepository _repository, IGetByIdClienteOutputPort outputPort) : IGetByIdClienteInputPort
{
    public async Task Handle(int IdCliente)
    {
        try
        {
            var cliente = await _repository.GetById(IdCliente);
            if (cliente == null)
            {
                await outputPort.Handle(null);
                return;
            }
            var clienteDTO = new ResponseClienteDTO
            {
                IdCliente = cliente.IdCliente,
                Cedula = cliente.Cedula,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono,
                Edad = cliente.Edad
            };
            await outputPort.Handle(clienteDTO);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}

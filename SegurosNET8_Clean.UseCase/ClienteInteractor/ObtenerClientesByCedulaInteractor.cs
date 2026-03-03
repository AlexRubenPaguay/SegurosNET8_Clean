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
    public async Task Handle(string cedula)
    {
        try
        {
            var cliente = await _repository.Get(cedula);
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

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
    public async Task Handle(string cedula)
    {
        try
        {
            Boolean eliminado = await _repository.Delete(cedula);
            if (!eliminado)
            {
                await outputPort.Handle(null);
                return;
            }
            await outputPort.Handle($"Cliente con cédula [{cedula}] se ha eliminado correctamente.");
        }
        catch (Exception)
        {
            throw;
        }
        
        
    }
}

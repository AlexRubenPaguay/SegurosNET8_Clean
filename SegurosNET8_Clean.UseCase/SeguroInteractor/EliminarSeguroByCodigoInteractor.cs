using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.RequestSeguro;

public class EliminarSeguroByCodigoInteractor(ISeguroRepository _repository, IDeleteByCodigoSeguroOutputPort outputPort) : IDeleteByCodigoSeguroInputPort
{
    public async Task Handle(int IdSeguro)
    {
        try
        {
            Boolean eliminado = await _repository.Delete(IdSeguro);
            if (!eliminado)
            {
                await outputPort.Handle(null);
                return;
            }
            await outputPort.Handle($"Seguro con ID [{IdSeguro}] se ha eliminado correctamente.");
        }
        catch (Exception)
        {
            throw;
        }
    }
}

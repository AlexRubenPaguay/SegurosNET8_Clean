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
    public Task Handle(int IdSeguro)
    {
        _repository.Delete(IdSeguro);
        outputPort.Handle($"Seguro con ID [{IdSeguro}] se ha eliminado correctamente.");
        return Task.CompletedTask;
    }
}

using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.SeguroInteractor;

public class ObtenerSeguroByIdInteractor(ISeguroRepository _repository, IGetByIdSeguroOutputPort outputPort) : IGetByIdSeguroInputPort
{
    public Task Handle(int IdSeguro)
    {
        var segurosResult = _repository.GetById(IdSeguro);
        ResponseSeguroDTO segurosDTO = new ResponseSeguroDTO
        {
            IdSeguro = segurosResult.Result.IdSeguro,
            Nombre = segurosResult.Result.Nombre,
            Codigo = segurosResult.Result.Codigo,
            Suma = segurosResult.Result.SumaAsegurada,
            Prima = segurosResult.Result.Prima,
            IdCliente = segurosResult.Result.IdCliente
        };
        outputPort.Handle(segurosDTO);
        return Task.CompletedTask;
    }
}

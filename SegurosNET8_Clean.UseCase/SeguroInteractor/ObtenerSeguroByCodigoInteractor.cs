using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.RequestSeguro;

public class ObtenerSeguroByCodigoInteractor(ISeguroRepository _repository, IGetByCodigoSeguroOutputPort outputPort) : IGetByCodigoSeguroInputPort
{
    public Task Handle(string codigoSeguro)
    {
        var segurosResult = _repository.Get(codigoSeguro);
        List<ResponseSeguroDTO> segurosDTO = new List<ResponseSeguroDTO>();
        foreach (var seguro in segurosResult.Result)
        {
            segurosDTO.Add(new ResponseSeguroDTO
            {
                IdSeguro = seguro.IdSeguro,
                Nombre = seguro.Nombre,
                Codigo = seguro.Codigo,
                Suma = seguro.SumaAsegurada,
                Prima = seguro.Prima,
                IdCliente = seguro.IdCliente
            });
        }
        outputPort.Handle(segurosDTO);
        return Task.CompletedTask;
    }
}

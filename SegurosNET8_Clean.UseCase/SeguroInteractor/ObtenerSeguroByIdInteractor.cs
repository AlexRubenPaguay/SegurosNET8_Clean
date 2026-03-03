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
    public async Task Handle(int IdSeguro)
    {
        try
        {
            var segurosResult = await _repository.GetById(IdSeguro);
            if (segurosResult == null)
            {
                await outputPort.Handle(null);
                return;
            }

            ResponseSeguroDTO segurosDTO = new ResponseSeguroDTO
            {
                IdSeguro = segurosResult.IdSeguro,
                Nombre = segurosResult.Nombre,
                Codigo = segurosResult.Codigo,
                Suma = segurosResult.SumaAsegurada,
                Prima = segurosResult.Prima,
                IdCliente = segurosResult.IdCliente
            };
            await outputPort.Handle(segurosDTO);

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}

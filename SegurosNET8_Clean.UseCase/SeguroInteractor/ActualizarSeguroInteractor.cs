using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.Entities.POCOs;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.RequestSeguro;

public class ActualizarSeguroInteractor(ISeguroRepository _repository, IUpdateSeguroOutputPort outputPort) : IUpdateSeguroInputPort
{
    public Task Handle(int IdSeguro, CrearSeguroDTO seguroDTO)
    {
        var newSeguro = new Entities.POCOs.Seguro
        {
            Nombre = seguroDTO.Nombre,
            Codigo = seguroDTO.Codigo,
            SumaAsegurada = seguroDTO.Suma,
            Prima = seguroDTO.Prima,
            IdCliente = seguroDTO.IdCliente
        };
        _repository.Update(IdSeguro, newSeguro);
        outputPort.Handle($"El seguro con ID [{IdSeguro}] se ha actualizado correctamente.");
        return Task.CompletedTask;
    }
}

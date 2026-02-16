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

public class CrearSeguroInteractor(ISeguroRepository _repository, ICrearSeguroOutputPort outputPort) : ICrearSeguroInputPort
{
    public Task Handle(CrearSeguroDTO seguroDTO)
    {
        try
        {
            var newSeguro = new Entities.POCOs.Seguro
            {
                Nombre = seguroDTO.Nombre,
                Codigo = seguroDTO.Codigo,
                SumaAsegurada = seguroDTO.Suma,
                Prima = seguroDTO.Prima,
                IdCliente = seguroDTO.IdCliente
            };
            _repository.Save(newSeguro);
            outputPort.Handle($"El seguro con código [{newSeguro.Codigo}] se ha creado exitosamente.");
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            return outputPort.Handle($"Error al guardar el seguro: {ex.Message}");
        }

    }
}

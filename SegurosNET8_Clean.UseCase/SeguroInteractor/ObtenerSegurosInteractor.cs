using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.Seguro
{
    public class ObtenerSegurosInteractor(ISeguroRepository _repository, IGetAllSeguroOutputPort outputPort) : IGetAllSeguroInputPort
    {
        public Task Handle()
        {
            List<ResponseSeguroDTO> segurosDTO = new List<ResponseSeguroDTO>();
            var seguros = _repository.GetAll();
            foreach (var seguro in seguros.Result)
            {
                var seguroDTO = new ResponseSeguroDTO
                {
                    IdSeguro = seguro.IdSeguro,
                    Nombre = seguro.Nombre,
                    Codigo = seguro.Codigo,
                    Suma = seguro.SumaAsegurada,
                    Prima = seguro.Prima,
                    IdCliente = seguro.IdCliente
                };
                segurosDTO.Add(seguroDTO);
            }
            outputPort.Handle(segurosDTO);
            return Task.CompletedTask;
        }
    }
}

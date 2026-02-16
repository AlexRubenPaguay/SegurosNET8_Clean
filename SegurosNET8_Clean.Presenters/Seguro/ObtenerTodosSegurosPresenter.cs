using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Presenters.Seguro;

public class ObtenerTodosSegurosPresenter : IGetAllSeguroOutputPort, IPresenter<IEnumerable<ResponseSeguroDTO>>
{
    public IEnumerable<ResponseSeguroDTO> Content { get; set; }
    public Task Handle(IEnumerable<ResponseSeguroDTO> segurosDTO)
    {
        Content= segurosDTO;
        return Task.CompletedTask;
    }
}

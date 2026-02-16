using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Presenters.Seguro;

public class ObtenerByIdSeguroPresenter : IGetByIdSeguroOutputPort, IPresenter<ResponseSeguroDTO>
{
    public ResponseSeguroDTO Content { get; set; }
    public Task Handle(ResponseSeguroDTO seguroDTO)
    {
        Content = seguroDTO;
        return Task.CompletedTask;
    }
}

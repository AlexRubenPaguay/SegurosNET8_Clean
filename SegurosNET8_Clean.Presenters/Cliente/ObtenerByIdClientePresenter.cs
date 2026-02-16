using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Presenters.Cliente;

public class ObtenerByIdClientePresenter : IGetByIdClienteOutputPort, IPresenter<ResponseClienteDTO>
{
    public ResponseClienteDTO Content { get; set; }
    public Task Handle(ResponseClienteDTO clientesDTO)
    {
        Content = clientesDTO;
        return Task.CompletedTask;
    }
}

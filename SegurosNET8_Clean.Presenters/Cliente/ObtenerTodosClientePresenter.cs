using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Presenters.Cliente;

public class ObtenerTodosClientePresenter : IGetAllClienteOutputPort, IPresenter<IEnumerable<ResponseClienteDTO>>
{
    public IEnumerable<ResponseClienteDTO> Content { get; set; }
    public Task Handle(IEnumerable<ResponseClienteDTO> clientesDTO)
    {
        Content = clientesDTO;
        return Task.CompletedTask;
    }
}

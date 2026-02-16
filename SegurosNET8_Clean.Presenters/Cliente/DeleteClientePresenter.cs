using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Presenters.Cliente;

public class DeleteClientePresenter : IDeleteByCedulaClienteOutputPort, IPresenter<string>
{
    public string Content { get; private set; }
    public Task Handle(string mensaje)
    {
        Content = mensaje;
        return Task.CompletedTask;
    }
}

using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Presenters.Seguro;

public class CrearSeguroPresenter : ICrearSeguroOutputPort, IPresenter<string>
{
    public string Content { get;private set; }
    public Task Handle(string mensaje)
    {
        Content = mensaje;
        return Task.CompletedTask;
    }
}

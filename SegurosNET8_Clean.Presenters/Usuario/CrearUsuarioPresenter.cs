using SegurosNET8_Clean.UseCasePorts.UsuarioPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Presenters.Usuario;

public class CrearUsuarioPresenter : ICrearUsuarioOutputPort, IPresenter<String>
{
    public string Content { get; set; }

    public Task Handle(string mensaje)
    {
        Content = mensaje;
        return Task.CompletedTask;
    }
}

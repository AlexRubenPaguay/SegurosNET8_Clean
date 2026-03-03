using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.UseCasePorts.UsuarioPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Presenters.Usuario;

public class ObtenerByUsuarioUsuarioPresenter : IGetByUsuarioUsuarioOutputPort, IPresenter<ResponseUsuarioDTO>
{
    public ResponseUsuarioDTO Content { get; private set; }

    public Task Handle(ResponseUsuarioDTO responseUsuarioDTO)
    {
        Content = responseUsuarioDTO;
        return Task.CompletedTask;
    }
}

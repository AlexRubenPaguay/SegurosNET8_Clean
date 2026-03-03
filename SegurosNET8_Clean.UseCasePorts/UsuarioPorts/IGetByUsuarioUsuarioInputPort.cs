using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCasePorts.UsuarioPorts;

public interface IGetByUsuarioUsuarioInputPort
{
    Task Handle(String usuario, String pass);
}

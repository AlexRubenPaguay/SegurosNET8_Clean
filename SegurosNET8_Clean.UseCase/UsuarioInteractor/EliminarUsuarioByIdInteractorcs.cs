using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.Entities.POCOs;
using SegurosNET8_Clean.UseCasePorts.UsuarioPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.UsuarioInteractor;

public class EliminarUsuarioByIdInteractorcs(IUsuarioRepository _repository, IDeleteByIdUsuarioOutputPort outputPort) : IDeleteByIdUsuarioInputPort
{
    public async Task Handle(int IdUsuario)
    {
        try
        {            
            Boolean eliminado = await _repository.Delete(IdUsuario);
            if (!eliminado)
            {
                await outputPort.Handle(null);
                return;
            }
            await outputPort.Handle($"El usuario con ID [{IdUsuario}] se ha eliminado correctamente.");
        }
        catch (Exception )
        {
            throw;
        }
    }
}

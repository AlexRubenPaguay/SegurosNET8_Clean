using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.Entities.POCOs;
using SegurosNET8_Clean.UseCasePorts.UsuarioPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.UsuarioInteractor;

public class ActualizarUsuarioInteractor(IUsuarioRepository _repository, IUpdateUsuarioOutputPort outputPort) : IUpdateUsuarioInputPort
{
    public async Task Handle(int IdUsuario, UsuarioDTO usuarioDTO)
    {
        try
        {
            if (usuarioDTO == null)
            {
                await outputPort.Handle(null);
                return;
            }

            var updateUsuario = new Usuario
            {
                IdUsuario = IdUsuario,
                NombreUsuario = usuarioDTO.NombreUsuario,
                Password = usuarioDTO.Password,
                NombreCompleto = usuarioDTO.NombreCompleto,
                Correo = usuarioDTO.Correo
            };
            await _repository.Update(IdUsuario, updateUsuario);
            await outputPort.Handle($"El usuario [{updateUsuario.NombreUsuario}] se ha actualizado correctamente.");

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

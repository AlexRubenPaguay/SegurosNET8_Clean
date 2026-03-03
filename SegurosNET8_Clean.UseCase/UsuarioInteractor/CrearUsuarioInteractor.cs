using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.Entities.POCOs;
using SegurosNET8_Clean.UseCasePorts.UsuarioPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase.UsuarioInteractor;

public class CrearUsuarioInteractor(IUsuarioRepository _repository, ICrearUsuarioOutputPort outputPort) : ICrearUsuarioInputPort
{
    public async Task Handle(UsuarioDTO usuarioDTO)
    {
        try
        {
            if (usuarioDTO == null)
            {
                await outputPort.Handle(null);
                return;
            }
            var newUsuario = new Usuario
            {
                NombreUsuario = usuarioDTO.NombreUsuario,
                Password = usuarioDTO.Password,
                NombreCompleto = usuarioDTO.NombreCompleto,
                Correo = usuarioDTO.Correo,
            };
            await _repository.save(newUsuario);
            await outputPort.Handle($"El usuario [{newUsuario.NombreUsuario}] se ha creado exitosamente.");
            
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}

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

public class ObtenerUsuarioByUsuarioInteractor(IUsuarioRepository _repository, IGetByUsuarioUsuarioOutputPort outputPort) : IGetByUsuarioUsuarioInputPort
{
    public async Task Handle(string usuario, string pass)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(pass))
            {
                throw new ArgumentException("Usuario y contraseña son requeridos");
            }

            var getUsuario = await _repository.GetByUsuario(usuario, pass);

            if (getUsuario == null)
            {                
                await outputPort.Handle(null);
                return;
            }

            ResponseUsuarioDTO responseUsuario = new ResponseUsuarioDTO
            {
                IdUsuario = getUsuario.IdUsuario,
                NombreUsuario = getUsuario.NombreUsuario,
                Password = getUsuario.Password,
                NombreCompleto = getUsuario.NombreCompleto,
                Correo = getUsuario.Correo,
                FechaCreacion = getUsuario.FechaCreacion,
                TipoUsuario = getUsuario.TipoUsuario
            };
            await outputPort.Handle(responseUsuario);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}

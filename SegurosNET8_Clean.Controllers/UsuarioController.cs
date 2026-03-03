using Microsoft.AspNetCore.Mvc;
using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Presenters;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using SegurosNET8_Clean.UseCasePorts.UsuarioPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Controllers;
[Route("api/v1/[Controller]")]
[ApiController]
public class UsuarioController(
    ICrearUsuarioInputPort inputPortCrear,
    ICrearUsuarioOutputPort outputPortCrear,
    IGetByUsuarioUsuarioInputPort inputPortGetByUsuario,
    IGetByUsuarioUsuarioOutputPort outputPortGetByUsuario,
    IDeleteByIdUsuarioInputPort inputPortDelete,
    IDeleteByIdUsuarioOutputPort outputPortDelete,
    IUpdateUsuarioInputPort inputPortUpdate,
    IUpdateUsuarioOutputPort outputPortUpdate)
{

    [HttpGet("GetByUsuario/{usuario}/{password}")]
    public async Task<ActionResult<ResponseUsuarioDTO>> ObtenerByUsuario(String usuario, String password)
    {
        await inputPortGetByUsuario.Handle(usuario, password);
        ResponseUsuarioDTO responseUsuarioDTO = (outputPortGetByUsuario as IPresenter<ResponseUsuarioDTO>).Content;
        if (responseUsuarioDTO == null)
            return new NotFoundObjectResult(new { response = "Credenciales inválidas" });
        return new OkObjectResult(responseUsuarioDTO);
    }

    [HttpPost]
    public async Task<IActionResult> CrearUsuario(UsuarioDTO usuarioDTO)
    {
        await inputPortCrear.Handle(usuarioDTO);
        var response = (outputPortCrear as IPresenter<string>).Content;
        return new OkObjectResult(new { response });
    }
    [HttpPut("{IdUsuario}")]
    public async Task<IActionResult> UpdateUsuario(int IdUsuario, UsuarioDTO usuarioDTO)
    {
        await inputPortUpdate.Handle(IdUsuario, usuarioDTO);
        var response = (outputPortUpdate as IPresenter<string>).Content;
        return new OkObjectResult(new { response });
    }

    [HttpDelete("{IdUsuario}")]
    public async Task<IActionResult> DeleteUsuario(int IdUsuario)
    {
        await inputPortDelete.Handle(IdUsuario);
        var response = (outputPortDelete as IPresenter<string>).Content;
        if (response == null)
            return new NotFoundObjectResult(new { response = $"El usuario con ID [{IdUsuario}] no encontrado." });
        return new OkObjectResult(new { response });
    }

}

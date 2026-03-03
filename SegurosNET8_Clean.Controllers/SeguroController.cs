using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Presenters;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class SeguroController(
    ICrearSeguroInputPort inputPortCrear,
    ICrearSeguroOutputPort outputPortCrear,
    IGetAllSeguroInputPort InputPortGetAll,
    IGetAllSeguroOutputPort OutputPortGetAll,
    IGetByCodigoSeguroInputPort InputPortGetBy,
    IGetByCodigoSeguroOutputPort OutputPortGetBy,
    IGetByIdSeguroInputPort InputPortGetById,
    IGetByIdSeguroOutputPort OutputPortGetById,
    IDeleteByCodigoSeguroInputPort InputPortDelete,
    IDeleteByCodigoSeguroOutputPort OutputPortDelete,
    IUpdateSeguroInputPort InputPortUpdate,
    IUpdateSeguroOutputPort OutputPortUpdate)
{

    [HttpGet]
    public async Task<IEnumerable<ResponseSeguroDTO>> ObtenerTodosSeguros()
    {
        await InputPortGetAll.Handle();
        return (OutputPortGetAll as IPresenter<IEnumerable<ResponseSeguroDTO>>).Content;
    }
    [HttpGet("{codigoSeguro}")]
    public async Task<IEnumerable<ResponseSeguroDTO>> ObtenerByCodigoSeguro(string codigoSeguro)
    {
        await InputPortGetBy.Handle(codigoSeguro);
        return (OutputPortGetBy as IPresenter<IEnumerable<ResponseSeguroDTO>>).Content;
    }
    [HttpGet("GetById/{IdSeguro}")]
    public async Task<ActionResult<ResponseSeguroDTO>> ObtenerByIdSeguro(int IdSeguro)
    {
        await InputPortGetById.Handle(IdSeguro);
        ResponseSeguroDTO responseSeguroDTO = (OutputPortGetById as IPresenter<ResponseSeguroDTO>).Content;
        if (responseSeguroDTO == null)
            return new NotFoundObjectResult(new { response = $"El seguro con ID [{IdSeguro}] no encontrado." });

        return new OkObjectResult(responseSeguroDTO);
    }

    [HttpPost]
    public async Task<IActionResult> CrearSeguro(CrearSeguroDTO seguroDTO)
    {
        await inputPortCrear.Handle(seguroDTO);
        var response = (outputPortCrear as IPresenter<string>).Content;
        return new OkObjectResult(new { response });
    }
    [HttpPut("{IdSeguro}")]
    public async Task<IActionResult> UpdateSeguro(int IdSeguro, CrearSeguroDTO seguroDTO)
    {
        await InputPortUpdate.Handle(IdSeguro, seguroDTO);
        var response = (OutputPortUpdate as IPresenter<string>).Content;
        return new OkObjectResult(new { response });
    }

    [HttpDelete("{IdSeguro}")]
    public async Task<IActionResult> DeleteSeguro(int IdSeguro)
    {
        await InputPortDelete.Handle(IdSeguro);
        var response = (OutputPortDelete as IPresenter<string>).Content;
        if (response == null)
            return new NotFoundObjectResult(new { response = $"El seguro con ID [{IdSeguro}] no encontrado." });
        return new OkObjectResult(new { response });
    }
}

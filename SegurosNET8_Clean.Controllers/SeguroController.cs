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
    public async Task<ResponseSeguroDTO> ObtenerByIdSeguro(int IdSeguro)
    {
        await InputPortGetById.Handle(IdSeguro);
        return (OutputPortGetById as IPresenter<ResponseSeguroDTO>).Content;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CrearSeguro(CrearSeguroDTO seguroDTO)
    {
        await inputPortCrear.Handle(seguroDTO);
        return (outputPortCrear as IPresenter<string>).Content;
    }
    [HttpPut("{IdSeguro}")]
    public async Task<string> UpdateSeguro(int IdSeguro, [FromBody] CrearSeguroDTO seguroDTO)
    {
        await InputPortUpdate.Handle(IdSeguro, seguroDTO);
        return (OutputPortUpdate as IPresenter<string>).Content;
    }

    [HttpDelete("{IdSeguro}")]
    public async Task<IActionResult> DeleteSeguro(int IdSeguro)
    {
        await InputPortDelete.Handle(IdSeguro);
        var mensaje = (OutputPortDelete as IPresenter<string>).Content;       
        return new OkObjectResult(new { mensaje });
    }
}

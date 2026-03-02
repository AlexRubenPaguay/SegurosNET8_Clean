using Microsoft.AspNetCore.Mvc;
using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Presenters;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class ClienteController(
    ICrearClienteInputPort inputPortCrear,
    ICrearClienteOutputPort outputPortCrear,
    IGetAllClienteInputPort InputPortGetAll,
    IGetAllClienteOutputPort OutputPortGetAll,
    IGetByCedulaClienteInputPort InputPortGetBy,
    IGetByCedulaClienteOutputPort OutputPortGetBy,
    IGetByIdClienteInputPort InputPortGetById,
    IGetByIdClienteOutputPort OutputPortGetById,
    IDeleteByCedulaClienteInputPort InputPortDelete,
    IDeleteByCedulaClienteOutputPort OutputPortDelete,
    IUpdateClienteInputPort InputPortUpdate,
    IUpdateClienteOutputPort OutputPortUpdate)
{

    [HttpGet]
    public async Task<IEnumerable<ResponseClienteDTO>> ObtenerTodosClientes()
    {
        await InputPortGetAll.Handle();
        return (OutputPortGetAll as IPresenter<IEnumerable<ResponseClienteDTO>>).Content;
    }
    [HttpGet("GetByCedula/{cedula}")]
    public async Task<ResponseClienteDTO> ObtenerByCedulaCliente(string cedula)
    {
        await InputPortGetBy.Handle(cedula);
        return (OutputPortGetBy as IPresenter<ResponseClienteDTO>).Content;
    }
    [HttpGet("{IdCliente:int}")]
    public async Task<ResponseClienteDTO> ObtenerByIdCliente(int IdCliente)
    {
        await InputPortGetById.Handle(IdCliente);
        return (OutputPortGetById as IPresenter<ResponseClienteDTO>).Content;
    }

    [HttpPost]
    public async Task<IActionResult> CrearCliente(CrearClienteDTO clienteDTO)
    {
        await inputPortCrear.Handle(clienteDTO);
        var response = (outputPortCrear as IPresenter<string>).Content;
        return new OkObjectResult(new { response });
    }

    [HttpPut("{IdCliente}")]
    public async Task<IActionResult> UpdateCliente(int IdCliente, CrearClienteDTO clienteDTO)
    {
        await InputPortUpdate.Handle(IdCliente, clienteDTO);
        var response = (OutputPortUpdate as IPresenter<string>).Content;
        return new OkObjectResult(new { response });
    }

    [HttpDelete("{cedula}")]
    public async Task<IActionResult> DeleteCliente(string cedula)
    {
        await InputPortDelete.Handle(cedula);
        var mensaje = (OutputPortDelete as IPresenter<string>).Content;
        return new OkObjectResult(new { mensaje });
    }
}

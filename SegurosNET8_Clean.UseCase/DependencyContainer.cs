using Microsoft.Extensions.DependencyInjection;
using SegurosNET8_Clean.UseCase.Cliente;
using SegurosNET8_Clean.UseCase.ClienteInteractor;
using SegurosNET8_Clean.UseCase.RequestClienteInteractor;
using SegurosNET8_Clean.UseCase.RequestSeguro;
using SegurosNET8_Clean.UseCase.Seguro;
using SegurosNET8_Clean.UseCase.SeguroInteractor;
using SegurosNET8_Clean.UseCase.UsuarioInteractor;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using SegurosNET8_Clean.UseCasePorts.UsuarioPorts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCase;

public static class DependencyContainer
{
    public static IServiceCollection AddUseCasesServices(
        this IServiceCollection services
        )
    {
        //Servicios de Cliente
        services.AddTransient<ICrearClienteInputPort, CrearClienteInteractor>();
        services.AddTransient<IDeleteByCedulaClienteInputPort, EliminarClientesByCedulaInteractor>();
        services.AddTransient<IUpdateClienteInputPort, ActualizarClienteInteractor>();
        services.AddTransient<IGetAllClienteInputPort, ObtenerClientesInteractor>();
        services.AddTransient<IGetByCedulaClienteInputPort, ObtenerClientesByCedulaInteractor>();
        services.AddTransient<IGetByIdClienteInputPort, ObtenerClientesByIdInteractor>();
        //Servicios de Seguro
        services.AddTransient<ICrearSeguroInputPort, CrearSeguroInteractor>();
        services.AddTransient<IDeleteByCodigoSeguroInputPort, EliminarSeguroByCodigoInteractor>();
        services.AddTransient<IUpdateSeguroInputPort, ActualizarSeguroInteractor>();
        services.AddTransient<IGetAllSeguroInputPort, ObtenerSegurosInteractor>();
        services.AddTransient<IGetByCodigoSeguroInputPort, ObtenerSeguroByCodigoInteractor>();
        services.AddTransient<IGetByIdSeguroInputPort, ObtenerSeguroByIdInteractor>();
        //Servicios de Usuario
        services.AddTransient<ICrearUsuarioInputPort, CrearUsuarioInteractor>();
        services.AddTransient<IDeleteByIdUsuarioInputPort, EliminarUsuarioByIdInteractorcs>();
        services.AddTransient<IUpdateUsuarioInputPort, ActualizarUsuarioInteractor>();
        services.AddTransient<IGetByUsuarioUsuarioInputPort, ObtenerUsuarioByUsuarioInteractor>();
        return services;
    }
}

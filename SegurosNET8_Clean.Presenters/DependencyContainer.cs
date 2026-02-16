using Microsoft.Extensions.DependencyInjection;
using SegurosNET8_Clean.DTOs;
using SegurosNET8_Clean.Presenters.Cliente;
using SegurosNET8_Clean.Presenters.Seguro;
using SegurosNET8_Clean.UseCasePorts.ClientePorts;
using SegurosNET8_Clean.UseCasePorts.SeguroPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Presenters;

public static class DependencyContainer
{
    public static IServiceCollection AddPresenters(this IServiceCollection services) 
    {
        //Servicios de Cliente
        services.AddScoped<ICrearClienteOutputPort, CrearClientePresenter>();
        services.AddScoped<IDeleteByCedulaClienteOutputPort, DeleteClientePresenter>();
        services.AddScoped<IGetAllClienteOutputPort, ObtenerTodosClientePresenter>();
        services.AddScoped<IGetByCedulaClienteOutputPort, ObtenerByCedulaClientePresenter>();
        services.AddScoped<IGetByIdClienteOutputPort, ObtenerByIdClientePresenter>();
        services.AddScoped<IUpdateClienteOutputPort, ActualizarClientePresenter>();
        //Servicios de Seguro
        services.AddScoped<ICrearSeguroOutputPort, CrearSeguroPresenter>();
        services.AddScoped<IDeleteByCodigoSeguroOutputPort, DeleteSeguroPresenter>();
        services.AddScoped<IGetAllSeguroOutputPort, ObtenerTodosSegurosPresenter>();
        services.AddScoped<IGetByCodigoSeguroOutputPort, ObtenerByCodigoSeguroPresenter>();
        services.AddScoped<IGetByIdSeguroOutputPort, ObtenerByIdSeguroPresenter>();
        services.AddScoped<IUpdateSeguroOutputPort, ActualizarSeguroPresenter>();
        return services;
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SegurosNET8_Clean.Presenters;
using SegurosNET8_Clean.RepositoryEFCore;
using SegurosNET8_Clean.UseCase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.IoC;

public  static class DependencyContainer
{
    public static IServiceCollection AddSegurosDependencies(
        this IServiceCollection services,IConfiguration configuration)
        
    {
        services.AddRepositories(configuration);
        services.AddUseCasesServices();
        services.AddPresenters();
        return services;
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.RepositoryEFCore.DataContext;
using SegurosNET8_Clean.RepositoryEFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.RepositoryEFCore;

public static class DependencyContainer
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services, IConfiguration configuration
        )
    {
        services.AddDbContext<AseguradoraContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("connSQLServer")));
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<ISeguroRepository, SeguroRepository>();
        return services;
    }
}

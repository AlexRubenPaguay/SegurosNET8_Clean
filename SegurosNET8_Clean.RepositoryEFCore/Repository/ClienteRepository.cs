using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.Entities.POCOs;
using SegurosNET8_Clean.RepositoryEFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.RepositoryEFCore.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly AseguradoraContext _context;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ClienteRepository> _logger;
    public ClienteRepository(AseguradoraContext context, ILogger<ClienteRepository> logger, IConfiguration configuration)
    {
        _context = context ?? throw new ArgumentNullException("No se pudo conectar a la BD.");
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task<Cliente> Get(string cedula)
    {
        var parameter = new SqlParameter("@Cedula", cedula);
        var result = await _context.Clientes
            .FromSqlRaw("EXEC sp_obtener_clientes_ByCedula @Cedula", parameter)
            .AsNoTracking()
            .ToListAsync();  
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<Cliente>> GetAll()
    {
        try
        {
            var response = await _context.Clientes.FromSqlInterpolated($"EXEC sp_obtener_clientes").ToListAsync();
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al ejecuatr sp: " + ex.Message);
        }
    }

    public async Task save(Cliente cliente)
    {
        try
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al guardar el cliente: " + ex.Message);
        }
    }

    public async Task update(int idCliente, Cliente cliente)
    {
        string connectionString = _configuration.GetConnectionString("connSQLServer");

        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string sql = @"
                UPDATE Clientes 
                SET Cedula = @Cedula, 
                    Nombre = @Nombre, 
                    Telefono = @Telefono, 
                    Edad = @Edad 
                WHERE IdCliente = @IdCliente";

                using (var command = new SqlCommand(sql, connection))
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@IdCliente", idCliente);
                    command.Parameters.AddWithValue("@Cedula", cliente.Cedula ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Edad", cliente.Edad);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected == 0)
                    {
                        throw new KeyNotFoundException($"El cliente con Id {idCliente} no existe en la BD.");
                    }
                }
            }

            _logger.LogInformation($"Cliente {idCliente} actualizado con ADO.NET puro");
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, $"Error SQL al actualizar cliente {idCliente}");
            throw new Exception($"Error en la base de datos: {ex.Message}");
        }
    }
    public async Task Delete(string cedula)
    {
        try
        {
            Cliente Existecliente = _context.Clientes.First(x => x.Cedula == cedula);
            if (Existecliente == null)
            {
                throw new Exception($"Cliente con cédula {cedula} no encontrado");
            }
            _context.Clientes.Remove(Existecliente);
            _context.SaveChanges();
        }

        catch (Exception)
        {
            throw;
        }
    }
    public async Task<Cliente> GetById(int idCliente)
    {
        var parameter = new SqlParameter("@IdCliente", idCliente);
        var result = await _context.Clientes
            .FromSqlRaw("EXEC sp_obtener_cliente_ById @IdCliente", parameter)
            .AsNoTracking()
            .ToListAsync(); 

        return result.FirstOrDefault();
    }
}

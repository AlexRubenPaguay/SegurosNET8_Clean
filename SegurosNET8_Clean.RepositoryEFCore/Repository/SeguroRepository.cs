using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.Entities.POCOs;
using SegurosNET8_Clean.RepositoryEFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.RepositoryEFCore.Repository;

public class SeguroRepository(AseguradoraContext _context, ILogger<SeguroRepository> _logger, IConfiguration _configuration) : ISeguroRepository
{
    public async Task<Seguro> GetById(int IdSeguro)
    {        
        var parameter = new SqlParameter("@IdSeguro", IdSeguro);
        var response = await _context.Seguros
            .FromSqlRaw("EXEC sp_obtener_seguro_ById @IdSeguro", parameter)
            .AsNoTracking()
            .ToListAsync();  
        return response.FirstOrDefault();
    }
    public async Task<IEnumerable<Seguro>> Get(string codigoSeguro)
    {        
        var parameter = new SqlParameter("@Codigo", codigoSeguro);
        var response = await _context.Seguros
            .FromSqlRaw("EXEC sp_obtener_seguro_ByCodigo @Codigo", parameter)
            .AsNoTracking()
            .ToListAsync();
        return response;
    }

    public async Task<IEnumerable<Seguro>> GetAll()
    {
        try
        {
            var response = await _context.Seguros.FromSqlInterpolated($"EXEC sp_obtener_seguros").ToListAsync();
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al ejecuatr sp: " + ex.Message);
        }
    }

    public async Task Save(Seguro seguro)
    {
        try
        {            
            if (seguro == null)
                throw new Exception("El seguro no puede ser nulo");

            if (seguro.SumaAsegurada <= 0)
                throw new Exception("La suma asegurada debe ser mayor a 0");

            if (seguro.Prima <= 0)
                throw new Exception("La prima debe ser mayor a 0");

            _context.Seguros.Add(seguro);
            var filasAfectadas = await _context.SaveChangesAsync();            
            _logger.LogInformation($"Seguro guardado exitosamente. ID: {seguro.IdSeguro}");
        }
        catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx)
        {            
             throw; 
        }
    }

    public async Task Update(int idSeguro, Seguro seguro)
    {
        string connectionString = _configuration.GetConnectionString("connSQLServer");
        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string sql = @"
                    UPDATE Seguros 
                    SET Nombre = @Nombre, 
                        Codigo = @Codigo, 
                        SumaAsegurada = @SumaAsegurada, 
                        Prima = @Prima, 
                        IdCliente = @IdCliente
                    WHERE IdSeguro = @IdSeguro";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdSeguro", idSeguro);
                    command.Parameters.AddWithValue("@Nombre", seguro.Nombre);
                    command.Parameters.AddWithValue("@Codigo", seguro.Codigo);
                    command.Parameters.AddWithValue("@SumaAsegurada", seguro.SumaAsegurada);
                    command.Parameters.AddWithValue("@Prima", seguro.Prima);
                    command.Parameters.AddWithValue("@IdCliente", seguro.IdCliente);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected == 0)
                    {
                        throw new KeyNotFoundException($"El seguro con Id [{idSeguro}] no existe en la BD.");
                    }
                    _logger.LogInformation($"Seguro [{idSeguro}] actualizado correctamente");
                }
            }
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, $"Error SQL al actualizar seguro {idSeguro}");
            throw new Exception($"Error en la base de datos: {ex.Message}");
        }
    }
    public async Task Delete(int IdSeguro)
    {
        try
        {
            Seguro seguroDB = _context.Seguros.First(x => x.IdSeguro == IdSeguro);
            if (seguroDB == null)
                throw new Exception($"El ID de seguro [{IdSeguro}] no existe en la BD.");

            _context.Seguros.Remove(seguroDB);
            _context.SaveChanges();
        }
        catch (SqlException ex)
        {            
            throw new Exception($"Error al eliminar  el seguro: {ex.Message}");
        }
        catch (Exception)
        {
            throw;
        }
    }
}

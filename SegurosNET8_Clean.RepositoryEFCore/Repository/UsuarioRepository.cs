using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SegurosNET8_Clean.Entities.Interfaces;
using SegurosNET8_Clean.Entities.POCOs;
using SegurosNET8_Clean.RepositoryEFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.RepositoryEFCore.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AseguradoraContext _context;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ClienteRepository> _logger;
    public UsuarioRepository(AseguradoraContext context, ILogger<ClienteRepository> logger, IConfiguration configuration)
    {
        _context = context ?? throw new ArgumentNullException("No se pudo conectar a la BD.");
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Usuario> GetByUsuario(string usuario, string password)
    {
        try
        {
            var parameterUsuario = new SqlParameter("@Usuario", usuario);
            var parameterPass = new SqlParameter("@Pass", password);
            var result = await _context.Usuarios
                .FromSqlRaw("EXEC sp_obtener_usuario_ByUsuario @Usuario, @Pass", parameterUsuario, parameterPass)
                .AsNoTracking()
                .ToListAsync();
            return result.FirstOrDefault();
        }
        catch (Exception)
        {
            throw new Exception($"Usuario [{usuario}] no encontrado."); ;
        }

    }

    public async Task save(Usuario usuario)
    {
        try
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al guardar el usuario: " + ex.Message);
        }
    }

    public async Task Update(int IdUsuario, Usuario usuario)
    {
        string connectionString = _configuration.GetConnectionString("connSQLServer");

        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string sql = @"
                UPDATE Usuarios 
                SET Password = @Pass, 
                    Correo = @Correo                    
                WHERE IdUsuario = @IdUsuario";

                using (var command = new SqlCommand(sql, connection))
                {
                    // Agregar parámetros
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    command.Parameters.AddWithValue("@Pass", usuario.Password ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Correo", usuario.Correo ?? (object)DBNull.Value);

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected == 0)
                    {
                        throw new KeyNotFoundException($"El usuario con Id {IdUsuario} no existe en la BD.");
                    }
                }
            }
            _logger.LogInformation($"Usuario {IdUsuario} actualizado con ADO.NET puro");
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, $"Error SQL al actualizar usuario {IdUsuario}");
            throw new Exception($"Error en la base de datos: {ex.Message}");
        }
    }

    public async Task<bool> Delete(int IdUsuario)
    {
        try
        {
            Usuario usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);
            if (usuarioExistente == null)
            {
                return false;
            }
            _context.Usuarios.Remove(usuarioExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        catch (Exception)
        {
            throw;
        }
    }
}

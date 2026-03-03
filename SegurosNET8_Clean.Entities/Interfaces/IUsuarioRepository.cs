using SegurosNET8_Clean.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Entities.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario> GetByUsuario(string usuario, String password);
    Task save(Usuario usuario);
    Task<bool> Delete(int IdUsuario);
    Task Update(int IdUsuario, Usuario usuario);
}

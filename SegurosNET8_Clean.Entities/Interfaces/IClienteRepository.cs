using SegurosNET8_Clean.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Entities.Interfaces;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> GetAll();
    Task<Cliente> Get(string cedula);
    Task<Cliente> GetById(int id);
    Task Delete(string cedula);
    Task save(Cliente cliente);
    Task update(int IdCliente,Cliente cliente);

}

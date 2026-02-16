using SegurosNET8_Clean.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.Entities.Interfaces;

public interface ISeguroRepository
{
    Task<IEnumerable<Seguro>> GetAll();
    Task<IEnumerable<Seguro>> Get(string codigoSeguro);
    Task Delete(int IdSeguro);
    Task Save(Seguro seguro);
    Task Update(int IdSeguro,Seguro seguro);
    Task<Seguro> GetById(int idSeguro);
}

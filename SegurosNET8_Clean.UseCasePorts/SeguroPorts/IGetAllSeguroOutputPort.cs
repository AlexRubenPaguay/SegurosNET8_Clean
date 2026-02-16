using SegurosNET8_Clean.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCasePorts.SeguroPorts
{
    public interface IGetAllSeguroOutputPort
    {
        Task Handle(IEnumerable<ResponseSeguroDTO> segurosDTO);
    }
}

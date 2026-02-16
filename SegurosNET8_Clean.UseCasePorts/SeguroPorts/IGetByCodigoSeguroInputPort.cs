using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.UseCasePorts.SeguroPorts;

public interface IGetByCodigoSeguroInputPort
{
    Task Handle(string nombreSeguro);
}

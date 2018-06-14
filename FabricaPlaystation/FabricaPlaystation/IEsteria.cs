using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    interface IEsteria
    {

        Task<int> VerificarAsync(int num);
        void RecebeConsole(Console console);
        Console DespachaConsole()
    }
}

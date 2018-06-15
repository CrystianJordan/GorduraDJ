using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class EsteiraManutenção: Esteira
    {
        public override int VerificarAsync(Console console)
        {
            if (console.GeraNumero() > 30)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class EsteiraVersão:Esteira
    {
        public override int VerificarAsync(Console console)
        {
            if (console.GeraNumero() <=30)
            {
                return 1;
            }
            else if (console.GeraNumero()>=31 && console.GeraNumero()<=50)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class Console
    {
        int prop;

        void GeraNumero()
        {
 Random rnd = new Random();
        int month = rnd.Next(1, 13);
            this.prop = month;
        }
       
    }
}

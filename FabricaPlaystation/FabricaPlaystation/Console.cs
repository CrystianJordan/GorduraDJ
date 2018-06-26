using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class Console
    {
        public bool Embalado { get; set; } = false;
        //Retorna numero aleatroio
       public int GeraNumero()
        {
           
 Random rnd = new Random();
        int month = rnd.Next(1, 100);
            return month;
        }
       
    }
}

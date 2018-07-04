using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class EsteiraPS3:Esteira
    {

     
        public async Task RecebeConsole(Console console)
        {
            int verif = 0;
            if (Status == true)
            {
                if (Disponivel == true)
                {
                    Disponivel = false;

                    verif = VerificarAsync(console);
                    //delegate da classe
                    embala(verif);
                    Disponivel = true;
                }
            }
         

        }
        public virtual int VerificarAsync(Console console)
        {
            int i = console.GeraNumero();
            if (i < 40)
            {
                return 1;
            }
            else if(i>=40 && i<=60)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        public Ps3 embala;

    }
}

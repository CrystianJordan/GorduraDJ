using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class EsteiraVersao:Esteira
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
                    Versao(verif);
                    Disponivel = true;
                }
            }
         
        
        }
        public override int VerificarAsync(Console console)
        {
            if (console.GeraNumero() <=30)
            {
                return 1;
            }
           
               
           
            else
            {
                return 2;
            }
        }
        public Versao Versao;
    }
}

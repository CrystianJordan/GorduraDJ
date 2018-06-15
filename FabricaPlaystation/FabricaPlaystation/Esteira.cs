using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class Esteira: IEsteria

      
    {
        
     Console Console { get; set; }
   Boolean Disponivel { get; set; } = true;
    Boolean Status { get; set; } = false;
        public async Task<int> RecebeConsole(Console console)
        {
            int verif = 0;
            if (Status == true)
            {
                if (Disponivel == true)
                {
                    Disponivel = false;
                   
                    verif = VerificarAsync(console);
                    
                  Disponivel = true;
                }
            }
            // irá esperar a função verificarAsync executar para depois preencher a variável
            return verif;
        }
      public virtual int VerificarAsync(Console console)
        {
            if (console.GeraNumero() > 20)
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

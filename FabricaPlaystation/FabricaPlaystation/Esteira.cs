using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class Esteira: IEsteria

      
    {
        
   public  Console Console { get; set; }
  public Boolean Disponivel { get; set; } = true;
  public  Boolean Status { get; set; } = false;
        public async Task RecebeConsole(Console console)
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

        public void Liga()
        {
            this.Status = true;
        }
        public void Desliga()
        {
            this.Status = false;
        }
   

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    //classe generica
    class Esteira: IEsteria

      
    {
        
   public  Console Console { get; set; }
  public Boolean Disponivel { get; set; } = true;
  public  Boolean Status { get; set; } = false;
        //função assicrona que recebe o console. Algumas classes possuem retorno de int para a tela
        public async Task RecebeConsole(Console console)
        {
            int verif = 0;
            //se a esteira esta ligada
            if (Status == true)
            {
                //se a esteria não possui console
                if (Disponivel == true)
                {
                    Disponivel = false;
                   //ativa o verifAsync para receber um numero e mandar para o delegate
                    verif = VerificarAsync(console);
                    
                  Disponivel = true;
                }
            }
        
    
        }
      public virtual int VerificarAsync(Console console)
        {
            //ativa o gera numero do console que retorna um dos numeros propostos para usar na verificação
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

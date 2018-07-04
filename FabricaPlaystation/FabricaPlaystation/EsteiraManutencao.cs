using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class EsteiraManutencao: Esteira
    {
        public async Task<int> RecebeConsole(Console console)
        {
            int verif = 0;
            if (Status == true)
            {
                if (Disponivel == true)
                {
                    Disponivel = false;

                    verif = VerificarAsync(console);
                    //delegate da classe
                    salvo(verif);
                  
                    Disponivel = true;
                }
            }
            //retorna o resultado do verifAsync para a tela
            return verif;
        }
        public override int VerificarAsync(Console console)
        {
            int i = console.GeraNumero();
            if (i < 30)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public Salvou salvo;
    }
}

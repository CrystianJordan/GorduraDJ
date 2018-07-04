using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class EsteiraProducao : Esteira
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
                    produziu(verif);
                    Disponivel = true;
                }
            }
            //retorna o resultado do verifAsync para a tela
            return verif;
        }
        public Produziu produziu;
    }
}

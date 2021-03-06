﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class EsteiraDespache: Esteira
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
                    Despache(verif);
                    Disponivel = true;
                }
            }
      //retorna o resultado do verifAsync para a tela
            return verif;
        }
        public virtual int VerificarAsync(Console console)
        {
            if (console.GeraNumero() > 10)
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
        public CodigoBarra Despache;

    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class EsteiraModelo:Esteira
    {
        public async Task<int> RecebeConsole(Console console)
        {
            int verif = 0;
            if (Status == true)
            {
                if (Disponivel == true)
                {
                   

                    verif = VerificarAsync(console);
                    Modelo(verif);
                    Disponivel = true;
                }
            }
            // irá esperar a função verificarAsync executar para depois preencher a variável
            return verif;  
        }
        public override int VerificarAsync(Console console)
        {
            if (console.GeraNumero() > 50)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public Modelo Modelo;
    }
}

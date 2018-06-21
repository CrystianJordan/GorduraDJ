using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricaPlaystation
{
    class Main
    {
        EsteiraModelo esteriaModelo = new EsteiraModelo();
        EsteiraVersao esteriaVersao = new EsteiraVersao();
        EsteiraDespache esteiraDespache = new EsteiraDespache();
        EsteiraManutencao esteiraManutencao = new EsteiraManutencao();
        EsteiraProducao esteiraProducao = new EsteiraProducao();
        EsteiraPs4 esteiraPs4 = new EsteiraPs4();
        EsteiraPS3 esteiraPs3 = new EsteiraPS3();

        public async Task ProducaoAsync()
        {
            while (true)
            {
 await Task.Delay(200);
            LinhaProd();
            }
            
        }

        public void LinhaProd()
        {

        }

        private static void verificaModelo()
        {

        }
        private static void verificaVersao()
        {

        }
        private static void verifDespache()
        {

        }

        private static void verifManutencao()
        {

        }

        private static void verifProducao()
        {

        }

        private static void verifPs3()
        {

        }

        private static void verifPs4()
        {

        }
       
    }
}

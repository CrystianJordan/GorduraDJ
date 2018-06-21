using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FabricaPlaystation
{
    public partial class Form1 : Form
    {
        EsteiraModelo esteriaModelo = new EsteiraModelo();

        EsteiraDespache esteiraDespache = new EsteiraDespache();
        EsteiraManutencao esteiraManutencao = new EsteiraManutencao();
        EsteiraProducao esteiraProducao = new EsteiraProducao();
        EsteiraPs4 esteiraPs4 = new EsteiraPs4();
        EsteiraPS3 esteiraPs3 = new EsteiraPS3();

        int valProducao = 0;
        int valSalvo = 0;
        int valLixo = 0;
        int valPs4 = 0;
        int valPs3 = 0;
        int valPs3Pro = 0;
        int valPs3Slim = 0;
        int valPs3Normal = 0;
        int valPs4Pro = 0;
        int valPs4Slim = 0;
        int valPs4Normal = 0;
        int valDespache = 0;
        public Form1()
        {
            InitializeComponent();
            esteriaModelo.Modelo += verificaModelo;
            esteiraDespache.Despache += verifDespache;
            esteiraManutencao.salvo += verifManutencao;
            esteiraProducao.produziu += verifProducao;
            esteiraPs3.embala += verificaVersaoPs3;
            esteiraPs4.embala += verificaVersaoPs4;
            ProducaoAsync();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void BVersaoPsQ_Click(object sender, EventArgs e)
        {
            if (BVersaoPsQ.BackColor == Color.Red)
            {
                BVersaoPsQ.BackColor = Color.Green;
            }
            else
            {
                BVersaoPsQ.BackColor = Color.Red;
            }
            if (esteiraPs4.Status == false)
            {
                esteiraPs4.Liga();
            }
            else
            {
                esteiraPs4.Desliga();
            }

        }
        public async Task ProducaoAsync()
        {
            while (true)
            {
                await Task.Delay(200);
                LinhaProd();
            }

        }

        public async Task LinhaProd()
        {
            Console console = new Console();
            int verifProd=await esteiraProducao.RecebeConsole(console);
            if (verifProd==2)
            {
 await esteiraManutencao.RecebeConsole(console);
            }
           
            int verife = await esteriaModelo.RecebeConsole(console);
            if (verife == 1)
            {
                await esteiraPs3.RecebeConsole(console);
            }
            else
            {
                await esteiraPs4.RecebeConsole(console);

            }


        }

        private void verificaModelo(int token)
        {

            if (token == 1)
            {
                valPs3++;
                labelPs3.Text = valPs3.ToString();

            }
            else
            {
                valPs4++;
                labelPs4.Text = valPs4.ToString();

            }

        }
        private void verificaVersaoPs3(int token)
        {
            if (token == 1)
            {
                valPs3Normal++;
                labelPs3Normal.Text = valPs3Normal.ToString();

            }
            else if (token == 2)
            {
                valPs3Pro++;
                labelPs3Pro.Text = valPs3Pro.ToString();

            }
            else
            {
                valPs3Slim++;
                labelPs3Slim.Text = valPs3Slim.ToString();

            }
        }
        private void verificaVersaoPs4(int token)
        {
            if (token == 1)
            {
                valPs4Normal++;
                labelPs4Normal.Text = valPs4Normal.ToString();

            }
            else if (token == 2)
            {
                valPs4Pro++;
                labelPs4Pro.Text = valPs4Pro.ToString();

            }
            else
            {
                valPs4Slim++;
                labelPs4Slim.Text = valPs4Slim.ToString();

            }
        }
        private void verifDespache(int token)
        {
            if (token == 1)
            {
                valDespache++;
                labelDespache.Text = valDespache.ToString();

            }
            else
            {
                valLixo++;
                labelDescarte.Text = valLixo.ToString();
            }
        }

        private void verifManutencao(int token)
        {
            if (token == 1)
            {
                labelSalvo.Text = valSalvo.ToString();
                valSalvo++;

            }
            else
            {
                valLixo++;
                labelDescarte.Text = valLixo.ToString();

            }
        }

        private void verifProducao(int token)
        {

            valProducao++;
            labelProduzidos.Text = valProducao.ToString();



        }



        private void BMPS4_Click(object sender, EventArgs e)
        {

        }

        private void BLiga_Click(object sender, EventArgs e)
        {

            esteiraProducao.Liga();
            esteiraManutencao.Liga();
            esteriaModelo.Liga();
            esteiraPs4.Liga();
            esteiraPs3.Liga();
            esteiraDespache.Liga();

        }
    }
}

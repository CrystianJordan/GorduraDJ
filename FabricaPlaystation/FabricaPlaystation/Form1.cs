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
        //cria as esterias
        EsteiraModelo esteriaModelo = new EsteiraModelo();
        EsteiraDespache esteiraDespache = new EsteiraDespache();
        EsteiraManutencao esteiraManutencao = new EsteiraManutencao();
        EsteiraProducao esteiraProducao = new EsteiraProducao();
        EsteiraPs4 esteiraPs4 = new EsteiraPs4();
        EsteiraPS3 esteiraPs3 = new EsteiraPS3();

        //variaveis de verificação
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
            //declarando os delegates das esterias nas funções da tabela
            esteriaModelo.Modelo += verificaModelo;
            esteiraDespache.Despache += verifDespache;
            esteiraManutencao.salvo += verifManutencao;
            esteiraProducao.produziu += verifProducao;
            esteiraPs3.embala += verificaVersaoPs3;
            esteiraPs4.embala += verificaVersaoPs4;
           //seta a emergencia como vermelha
            btnLuzEmergencia.BackColor = Color.Red;
            ProducaoAsync();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void BVersaoPsQ_Click(object sender, EventArgs e)
        {
            //se o botão estiver verde vira vermelho, senão, vira verde
            if (BVersaoPsQ.BackColor == Color.Red)
            {
                BVersaoPsQ.BackColor = Color.Green;
            }
            else
            {
                BVersaoPsQ.BackColor = Color.Red;
            }
            //se a esteira do ps3 estiver ligada, o botão a  desliga, senão, o botão a liga
            if (esteiraPs4.Status == true)
            {
 esteiraPs4.Desliga();
            }
            else
            {
                esteiraPs4.Liga();
                
            }
            //se ambas as esterias ps3 e ps4 estiverem paradas, para toda a produção
            if (esteiraPs3.Status==false && esteiraPs4.Status==false)
            {
                desligaTudo();
            }
           

           

        }
        public async Task ProducaoAsync()
        {
            while (true)
            {
                //fica chamando a função assicrona linhaProd
                await Task.Delay(200);
                LinhaProd();
            }

        }

        public async Task LinhaProd()
        {
            int ligado = 0;
            int salvo = 0;
            //cria um console
            Console console = new Console();
            //recebe o resultado da verificação da esteira de produção, enquanto o delegate roda
            int verifProd = await esteiraProducao.RecebeConsole(console);
            //se o int for 2, manda o console para a esteira de manutenção, senão, segue para a de modelo
            if (verifProd == 2)
            {
                //na manutenção, se o int for 1, o console é recuperado, senão é descartado
                salvo = await esteiraManutencao.RecebeConsole(console);

            }
            if (verifProd == 1 || salvo == 1)
            {
                //verifica qual o modelo da esteira
                int verife = await esteriaModelo.RecebeConsole(console);
                if (verife == 1)
                {
                    await esteiraPs3.RecebeConsole(console);
                    if (esteiraPs3.Status==true)
                    {
                        ligado = 1;
                    }
                }
                else
                {
                    await esteiraPs4.RecebeConsole(console);
                    if (esteiraPs4.Status == true)
                    {
                        ligado = 2;
                    }
                }
                if (ligado==1||ligado==2)
                {
                    //ativa o delegate da esteira de despache
await esteiraDespache.RecebeConsole(console);
                }
                
            }


        }

        //recebe o token do verificaAsync da esteria correspondente, se for 1, atualiza o label ps3,se for 2, atualiza a label do ps4
        private void verificaModelo(int token)
        {

            if (token == 1 && esteiraPs3.Status==true)
            {
                valPs3++;
                labelPs3.Text = valPs3.ToString();

            }
            else if(token==2 && esteiraPs4.Status==true)
            {
                valPs4++;
                labelPs4.Text = valPs4.ToString();

            }

        }
        //se o token for 1,atualiza o label ps3Normal, se for 2, o LabelPs3Pró, se 3, o labelPs3Slim
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
        //se o token for 1,atualiza o label ps4Normal, se for 2, o LabelPs4Pró, se 3, o labelPs4Slim
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
        //se token for 1, atualiza a label despache, se for 2, atualiza a label descarte
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
        //se token for 1, atualiza a label recuparado, senão, atualiza a label descarte 
        private void verifManutencao(int token)
        {
            if (token == 1)
            {
                valSalvo++;
                labelRecuperadoMan.Text = valSalvo.ToString();


            }
            else
            {
                valLixo++;
                labelDescarte.Text = valLixo.ToString();

            }
        }
        //se token for 1, atualiza a label perfeito, se não, atualiza a ladel descarte
        private void verifProducao(int token)
        {
            if (token == 1)
            {
                valProducao++;
                labelProduzidos.Text = valProducao.ToString();
            }
            else
            {
                valLixo++;
                labelDescarte.Text = valLixo.ToString();
            }




        }



        private void BMPS4_Click(object sender, EventArgs e)
        {

        }

        private void BLiga_Click(object sender, EventArgs e)
        {
            btnLuzEmergencia.Visible = false;
            esteiraProducao.Liga();
            esteiraManutencao.Liga();
            esteriaModelo.Liga();
            esteiraPs4.Liga();
            esteiraPs3.Liga();
            esteiraDespache.Liga();
            bEsteiraProd.BackColor = Color.Green;
            bEsteiraManutencao.BackColor = Color.Green;
            BEsteiraModelo.BackColor = Color.Green;
           
            BVersaoPsT.BackColor = Color.Green;
            BVersaoPsQ.BackColor = Color.Green;
            BDespache.BackColor = Color.Green;
         

        }

        private void labelDespache_Click(object sender, EventArgs e)
        {

        }

        private void BDesliga_Click(object sender, EventArgs e)
        {
            desligaTudo();
        
        }

        private void BEmergencia_Click(object sender, EventArgs e)
        {
            desligaTudo();
            
                btnLuzEmergencia.Visible = true;
                
            
           
        }

        private void BDespache_Click(object sender, EventArgs e)
        {

        }

        private void BVersaoPsT_Click(object sender, EventArgs e)
        {
            //se o botão estiver verde vira vermelho, senão, vira verde
            if (BVersaoPsT.BackColor == Color.Red)
            {
                BVersaoPsT.BackColor = Color.Green;
            }
            else
            {
                BVersaoPsT.BackColor = Color.Red;
            }
            //se a esteira do ps3 estiver ligada, o botão a  desliga, senão, o botão a liga
            if (esteiraPs3.Status == true)
            {
                esteiraPs3.Desliga();
            }
            else
            {
                esteiraPs3.Liga();

            }
            //se ambas as esterias ps3 e ps4 estiverem paradas, para toda a produção
            if (esteiraPs3.Status == false && esteiraPs4.Status == false)
            {
                desligaTudo();
            }

        }
        public void desligaTudo()
        {
            //ativa todas as funções desliga das esterias
            esteiraProducao.Desliga();
            esteiraManutencao.Desliga();
            esteriaModelo.Desliga();
            esteiraPs4.Desliga();
            esteiraPs3.Desliga();
            esteiraDespache.Desliga();
            bEsteiraProd.BackColor = Color.Red;
            bEsteiraManutencao.BackColor = Color.Red;
            BEsteiraModelo.BackColor = Color.Red;

            BVersaoPsT.BackColor = Color.Red;
            BVersaoPsQ.BackColor = Color.Red;
            BDespache.BackColor = Color.Red;
        }

        private void bEsteiraProd_Click(object sender, EventArgs e)
        {

        }
    }
}

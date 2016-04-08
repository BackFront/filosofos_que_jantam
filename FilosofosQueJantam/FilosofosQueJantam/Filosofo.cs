using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilosofosQueJantam
{
    class Filosofo
    {
        /*
		 * 0 = meditando
		 * 1 = como fome
		 * 2 = comendo
		 */
        private string nomeFilosofo;

        private int estado = 0;
        private string currentEstado;

        private string[] maos;
        
        private FilosofoUC myUserControll;

        private Token[] tokens = new Token[2];
        private Fork[] forks = new Fork[2];
        private Filosofo[] filosofos = new Filosofo[2];

        public Filosofo(string nomeFilosofo)
        {
            this.nomeFilosofo = nomeFilosofo;
            this.myUserControll = new FilosofoUC();
            this.myUserControll.filosofoNome = nomeFilosofo;
            switch (this.estado)
            {
                case 0:
                    this.currentEstado = "Meditando";
                    break;
                case 1:
                    this.currentEstado = "Com fome";
                    break;
                case 2:
                    this.currentEstado = "Comendo";
                    break;
            }

            this.myUserControll.filosofoEstado = this.currentEstado;
            this.myUserControll.filosofoMaoDir = this.maos[Lado.Dir];
            this.myUserControll.filosofoMaoDir = this.maos[Lado.Esq];
        }

        public FilosofoUC Usercontroll
        {
            get
            {
                return this.myUserControll;
            }
            set
            {
                this.myUserControll = value;
            }
        }


        public void setFilosofoDir(Filosofo filosofo)
        {
            this.filosofos[Lado.Dir] = filosofo;
        }

        public void setFilosofoEsq(Filosofo filosofo)
        {
            this.filosofos[Lado.Esq] = filosofo;
        }

        private void setObjMaos()
        {
            //Ve se tem token
            if(this.tokens[Lado.Dir] != null)
            {
                this.maos[Lado.Dir] = "Token";
            } else { this.maos[Lado.Dir] = "Garfo"; }

            //Ve se tem garfo
            if (this.forks[Lado.Dir] != null)
            {
                this.maos[Lado.Dir] = "Garfo";
            }
            else { this.maos[Lado.Dir] = "Token"; }
        }

        //===================================================
        // AÇÕES

        public void comer()
        {
            this.pedeGarfoDireito();
            this.pedeGarfoEsquerdo();
            MessageBox.Show("Estou Comendo");
        }

        public void pararComer()
        {
        }

        //===================================================

        private void pedeGarfoDireito()
        {
            if (this.tokens[Lado.Dir] != null)
            {
                this.pedirGarfo(filosofos[Lado.Dir], Lado.Dir);
            }
        }

        private void pedeGarfoEsquerdo()
        {
            if (this.tokens[Lado.Esq] != null)
            {
                this.pedirGarfo(filosofos[Lado.Esq], Lado.Esq);
            }
        }

        private void pedirGarfo(Filosofo filosofo, int lado)
        {
            MessageBox.Show("Dá o garfo fafavo");
            this.enviaToken(filosofo, lado);
            this.forks[lado] = new Fork();
        }

        //=====================================================
        private void enviaToken(Filosofo ladoFilosofo, int lado)
        {
            ladoFilosofo.recebeToken(lado);
            this.tokens[lado] = null;
        }

        private void recebeToken(int lado)
        {
            this.tokens[lado] = new Token();
            this.forks[lado] = null;
        }
    }
}

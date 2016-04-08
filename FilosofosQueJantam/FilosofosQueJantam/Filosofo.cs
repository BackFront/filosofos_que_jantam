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

        private string[] hands;

        private FilosofoUC myUserControll;

        private Token[] tokens = new Token[2];
        private Fork[] forks = new Fork[2];
        private Filosofo[] filosofos = new Filosofo[2];
        //End atributes

        //CONTRUCTOR
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
            this.myUserControll.filosofoMaoDir = this.hands[Lado.Dir];
            this.myUserControll.filosofoMaoDir = this.hands[Lado.Esq];
        }

        //===================================================
        // METODOS DOS FILOSOFOS

        //Retorna o Usercontroll deste usuário
        public FilosofoUC Usercontroll
        {
            get
            {
                return this.myUserControll;
            }
        }

        //Faz o Filosofo pegar um objeto com uma das mãos
        public void pegar(object objeto, int mao)
        {
            if(objeto.GetType() == typeof(Token))
            {
                this.tokens[mao] = (Token) objeto;
            } else if (objeto.GetType() == typeof(Fork))
            {
                this.forks[mao] = (Fork)objeto;
            }
        }

        public void setFilosofoLado(Filosofo filosofo, int lado)
        {
            this.filosofos[lado] = filosofo;
        }

        private void setObjMaos()
        {
            //Ve se tem token
            if (this.tokens[Lado.Dir] != null)
            {
                this.hands[Lado.Dir] = "Token";
            }
            else { this.hands[Lado.Dir] = "Garfo"; }

            //Ve se tem garfo
            if (this.forks[Lado.Dir] != null)
            {
                this.hands[Lado.Dir] = "Garfo";
            }
            else { this.hands[Lado.Dir] = "Token"; }
        }

        //===================================================
        // METODOS DE AÇÕES
        public void comer()
        {
            this.pedirGarfo(this.filosofos[Lado.Dir], Lado.Dir);
            this.pedirGarfo(this.filosofos[Lado.Esq], Lado.Esq);
            MessageBox.Show("Estou Comendo");
        }

        public void pararComer()
        {
        }

        //===================================================
        // METODOS GARFO
        private void pedirGarfo(Filosofo filosofo, int lado)
        {
            if (this.tokens[lado] != null)
            {
                MessageBox.Show("Dá o garfo fafavo");
                this.enviaToken(filosofo, lado);
                this.forks[lado] = new Fork();
                this.tokens[lado] = null;
            }
            else { MessageBox.Show(this.nomeFilosofo + ": Você não tem token ou já está com o garfo"); }
        }

        //=====================================================
        // METODOS TOKEN
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

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
		 * 1 = com fome
		 * 2 = comendo
		 */
        public string nomeFilosofo;

        private int estado = 0;
        private string currentEstado;

        private string[] hands = new string[2];

        private FilosofoUC myUserControll;

        private Token[] tokens = new Token[2];
        private Fork[] forks = new Fork[2];
        private Filosofo[] filosofos = new Filosofo[2];
        //End atributes

        //CONTRUCTOR
        public Filosofo(string nomeFilosofo, object maoDir, object maoEsq)
        {
            //Pega os objetos
            this.pegar(maoDir, Lado.Dir);
            this.pegar(maoEsq, Lado.Esq);
            setObjMaos();

            this.nomeFilosofo = nomeFilosofo;
            this.myUserControll = new FilosofoUC();

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


            this.myUserControll.filosofoNome = nomeFilosofo;
            this.myUserControll.filosofoEstado = this.currentEstado;
            this.myUserControll.BotaoClicado += comer;

            this.myUserControll.filosofoMaoDir = this.hands[Lado.Dir];
            this.myUserControll.filosofoMaoEsq = this.hands[Lado.Esq];
        }

        public void build()
        {
            this.myUserControll.filosofoDaDir = this.filosofos[Lado.Dir].nomeFilosofo;
            this.myUserControll.filosofoDaEsq = this.filosofos[Lado.Esq].nomeFilosofo;
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
        private void pegar(object objeto, int mao)
        {
            if (objeto.GetType() == typeof(Token))
            {
                this.tokens[mao] = (Token)objeto;
            }
            if (objeto.GetType() == typeof(Fork))
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
            if (this.tokens[Lado.Dir] != null && this.tokens[Lado.Dir].GetType() == typeof(Token))
            {
                this.hands[Lado.Dir] = "Token";
            }

            if (this.tokens[Lado.Esq] != null && this.tokens[Lado.Esq].GetType() == typeof(Token))
            {
                this.hands[Lado.Esq] = "Token";
            }

            //Ve se tem garfo
            if (this.forks[Lado.Dir] != null && this.forks[Lado.Dir].GetType() == typeof(Fork))
            {
                this.hands[Lado.Dir] = "Garfo";
            }

            if (this.forks[Lado.Esq] != null && this.forks[Lado.Esq].GetType() == typeof(Fork))
            {
                this.hands[Lado.Esq] = "Garfo";
            }
        }

        //===================================================
        // METODOS DE AÇÕES
        public void comer(object sender, EventArgs e)
        {
            FilosofoUC myUserControll = (FilosofoUC)sender;

            //Verifica se 'this' esta com o garfo
            if (!this.estouComGarfo(Lado.Dir))
            {
                //Verifica se visinho esta comendo
                if (!this.estaComendo(Lado.Dir))
                    this.pedirGarfo(this.filosofos[Lado.Dir], Lado.Dir);
            }

            //Verifica se 'this' esta com o garfo
            if (!this.estouComGarfo(Lado.Esq))
            {
                //Verifica se visinho esta comendo
                if (!this.estaComendo(Lado.Esq))
                    this.pedirGarfo(this.filosofos[Lado.Esq], Lado.Esq);
            }

            if(this.estouComOsDoisGarfo())
            {
                this.mudarEstadoComendo();
            } else
            {
                this.mudarEstadoComFome();
            }
        }

		public void pararComer(object sender, EventArgs e)
        {
            FilosofoUC myUserControll = (FilosofoUC)sender;
            this.mudarEstadoMeditando();

			//Se o cara da direita estiver com fome, envie o garfo
			if (this.estaComFome(Lado.Dir)) {
				this.enviaFork(filosofos[Lado.Dir], Lado.Dir);
			}

			//Se o cara da esquerda estiver com fome, envie o garfo
			if (this.estaComFome(Lado.Esq)) this.enviaFork(filosofos[Lado.Esq], Lado.Esq);
		}

        //===================================================
        // METODOS DE MUDANÇA DE ESTADO
        private void mudarEstadoMeditando()
        {
            this.estado = 0; //Meditando
            MessageBox.Show(this.nomeFilosofo + " está meditando!");
            this.myUserControll.filosofoEstado = "meditando";
            this.myUserControll.BotaoClicado += comer;
            this.myUserControll.BotaoClicado -= pararComer;
        }

        private void mudarEstadoComFome()
        {
            this.estado = 1; //Com Fome
            MessageBox.Show(this.nomeFilosofo + " está com fome!");
            this.myUserControll.filosofoEstado = "Com fome";
            this.myUserControll.BotaoClicado -= comer;
            this.myUserControll.BotaoClicado -= pararComer;
		}

        private void mudarEstadoComendo()
        {
            this.estado = 2; //Comendo
            MessageBox.Show(this.nomeFilosofo + " está comendo!");
            this.myUserControll.filosofoEstado = "Comendo";
            this.myUserControll.BotaoClicado -= comer;
            this.myUserControll.BotaoClicado += pararComer;
        }

        private void garfoSujo()
        { }

        private int inverteLado(int lado)
        {
            if (lado == 1) return 0;
            if (lado == 0) return 1;
            return lado;
        }
        //===================================================
        // METODOS DE VERIFICAÇÃO
        private bool estouComGarfo(int lado)
        {
            if (this.forks[lado] != null) return true;
            return false;
        }

        private bool estouComOsDoisGarfo()
        {
            if (this.forks[0] != null && this.forks[1] != null) return true;
            return false;
        }

		/**
		 * Verifica se o filosofo do lado (Dir/Esq) esta comendo
		 */
        private bool estaComendo(int lado)
        {
            if (this.filosofos[lado].estado == 2) return true;
            return false;
        }

		/**
		 * Verifica se o filosofo do lado (Dir/Esq) esta com fome
		 */
		private bool estaComFome(int lado)
		{
			if (this.filosofos[lado].estado == 1) return true;
			return false;
		}

		//===================================================
		// METODOS GARFO
		private void pedirGarfo(Filosofo filosofo, int lado)
        {
            if (this.tokens[lado] != null)
            {
                MessageBox.Show(this.filosofos[lado].nomeFilosofo + ", dá o garfo fafavo");

                int ladoInverso = this.inverteLado(lado);
                if (filosofo.forks[ladoInverso] != null)
                {
                    this.enviaToken(filosofo, lado);
                    this.forks[lado] = new Fork();
                    this.tokens[lado] = null;
                } else {
                    MessageBox.Show(this.filosofos[lado].nomeFilosofo + ", não tem garfo");
                }
            }
        }

		//=====================================================
		// METODOS TOKEN: Envia o token para o filosofo (Dir/Esq), assim que pegar o garfo dele.
		private void enviaToken(Filosofo ladoFilosofo, int lado)
        {
            //Eu
            this.tokens[lado] = null;

			if (Lado.Dir == lado)
			{
				this.myUserControll.filosofoMaoDir = "Garfo";
				ladoFilosofo.myUserControll.filosofoMaoEsq = "Token";

				ladoFilosofo.tokens[this.inverteLado(lado)] = new Token();
				ladoFilosofo.forks[this.inverteLado(lado)] = null;
			}

			if (Lado.Esq == lado)
			{
				this.myUserControll.filosofoMaoEsq = "Garfo";
				ladoFilosofo.myUserControll.filosofoMaoDir = "Token";

				ladoFilosofo.tokens[this.inverteLado(lado)] = new Token();
				ladoFilosofo.forks[this.inverteLado(lado)] = null;
			}
        }

		//=====================================================
		// METODOS FORK: Envia o garfo para o filosofo que esta com fome, assim que parar de comer.
		private void enviaFork(Filosofo ladoFilosofo, int lado)
		{
			//Eu
			this.forks[lado] = null;

			if (Lado.Dir == lado)
			{
				this.myUserControll.filosofoMaoDir = "Token";
				ladoFilosofo.myUserControll.filosofoMaoEsq = "Garfo";

				ladoFilosofo.forks[this.inverteLado(lado)] = new Fork();
				ladoFilosofo.tokens[this.inverteLado(lado)] = null;
			}

			if (Lado.Esq == lado)
			{
				this.myUserControll.filosofoMaoEsq = "Token";
				ladoFilosofo.myUserControll.filosofoMaoDir = "Garfo";

				ladoFilosofo.forks[this.inverteLado(lado)] = new Fork();
				ladoFilosofo.tokens[this.inverteLado(lado)] = null;
			}
		}

	}
}

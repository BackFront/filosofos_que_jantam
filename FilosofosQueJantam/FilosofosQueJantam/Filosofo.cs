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
		private int estado = 0;


		private int[] mao = new int[2];
		private Token[] tokens = new Token[2];
		private Fork[] forks = new Fork[2];
		private Filosofo[] filosofos = new Filosofo[2];



		public void comer()
		{
			this.pedeGarfoDireito();
			this.pedeGarfoEsquerdo();
			MessageBox.Show("Estou Comendo");
		}

		private void pedeGarfoDireito()
		{
			if (this.mao[maoDir] == this.token)
			{
				this.pedirGarfos(filosofoDir);
			}
		}

		private void pedeGarfoEsquerdo()
		{
			if (this.mao[maoEsq] == this.token)
			{
				this.pedirGarfos(filosofoEsq);
			}
		}

		private void pedirGarfos(Filosofo ladoFilosofo)
		{
			MessageBox.Show("Dá o garfo");
			this.enviaToken(filosofoDir);
		}

		//=====================================================
		private void enviaToken(Filosofo ladoFilosofo)
		{
			//Envia o token para o filosofoX | X = lado
		}

		private void recebeToken(int lado)
		{
		}
	}
}

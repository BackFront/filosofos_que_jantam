﻿using System;
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

		private Token[] tokens = new Token[2];
		private Fork[] forks = new Fork[2];
		private Filosofo[] filosofos = new Filosofo[2];

		public Filosofo(string nomeFilosofo, Panel painel)
		{
			this.nomeFilosofo = nomeFilosofo;
			FilosofoUC objFilosofo = new FilosofoUC();
			objFilosofo.filosofoNome = nomeFilosofo;

			painel.Controls.Add(objFilosofo);
		}

		public void setFilosofoDir(Filosofo filosofo)
		{
			this.filosofos[Lado.Dir] = filosofo;
		}

		public void setFilosofoEsq(Filosofo filosofo)
		{
			this.filosofos[Lado.Esq] = filosofo;
		}

		//===================================================

		public void comer()
		{
			this.pedeGarfoDireito();
			this.pedeGarfoEsquerdo();
			MessageBox.Show("Estou Comendo");
		}

		public void pararComer()
		{
		}

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

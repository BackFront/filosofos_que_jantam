using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilosofosQueJantam
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			Filosofo filosofo1 = new Filosofo("Rafael", this.Painel);
			Filosofo filosofo2 = new Filosofo("Andre", this.Painel);
			Filosofo filosofo3 = new Filosofo("Gabriel",this.Painel);

			filosofo1.setFilosofoDir(filosofo3);
			filosofo1.setFilosofoEsq(filosofo2);

			filosofo2.setFilosofoDir(filosofo1);
			filosofo2.setFilosofoEsq(filosofo3);

			filosofo3.setFilosofoDir(filosofo2);
			filosofo3.setFilosofoEsq(filosofo1);
		}

	}
}

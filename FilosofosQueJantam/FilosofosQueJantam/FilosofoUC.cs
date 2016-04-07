using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilosofosQueJantam
{
	public partial class FilosofoUC : UserControl
	{
		public FilosofoUC()
		{
			InitializeComponent();
		}

		public string filosofoNome
		{
			get
			{
				return nomeFilosofo.Text;
			}
			set
			{
				nomeFilosofo.Text = value;
			}
		}
	}
}

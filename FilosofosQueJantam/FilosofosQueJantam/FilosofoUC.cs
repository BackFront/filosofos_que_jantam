﻿using System;
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
        public event EventHandler BotaoClicado;

        public int[] filosofoMao = new int[2];

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

        public string filosofoEstado
        {
            get
            {
                return estadoFilosofo.Text;
            }
            set
            {
                estadoFilosofo.Text = value;
            }
        }

        public string filosofoMaoDir
        {
            get
            {
                return estadoMaoDir.Text;
            }
            set
            {
                estadoMaoDir.Text = value;
            }
        }

        public string filosofoMaoEsq
        {
            get
            {
                return estadoMaoEsq.Text;
            }
            set
            {
                estadoMaoEsq.Text = value;
            }
        }

        public string filosofoDaDir
        {
            set
            {
                filosofoDir.Text = "<-[ " + value + " ]";
            }
        }

        public string filosofoDaEsq
        {
            set
            {
                filosofoEsq.Text = "[ " + value + " ]->";
            }
        }

        public string btnAcao
        {
            set
            {
                acaoFilosofo.Text = value;
            }
        }

        private void acaoFilosofo_Click(object sender, EventArgs e)
        {
            if (BotaoClicado != null)
                BotaoClicado(this, e);
        }
    }
}

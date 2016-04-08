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
            Filosofo filosofo1 = new Filosofo("Rafael", new Fork(), new Fork());
            Filosofo filosofo2 = new Filosofo("Andre", new Token(), new Token());
            Filosofo filosofo3 = new Filosofo("Gabriel", new Fork(), new Token());
            


            //Filosofo 01
            filosofo1.setFilosofoLado(filosofo3, Lado.Dir);
            filosofo1.setFilosofoLado(filosofo2, Lado.Esq);


            //Filosofo 02
            filosofo2.setFilosofoLado(filosofo1, Lado.Dir);
            filosofo2.setFilosofoLado(filosofo3, Lado.Esq);

            //Filosofo 03
            filosofo3.setFilosofoLado(filosofo2, Lado.Dir);
            filosofo3.setFilosofoLado(filosofo1, Lado.Esq);

            //Inclui os filosofos no painel
            this.flowLayoutPanel1.Controls.Add(filosofo1.Usercontroll);
            this.flowLayoutPanel1.Controls.Add(filosofo2.Usercontroll);
            this.flowLayoutPanel1.Controls.Add(filosofo3.Usercontroll);
            

            filosofo1.build();
            filosofo2.build();
            filosofo3.build();
        }

    }
}

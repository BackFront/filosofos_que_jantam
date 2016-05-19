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
            Filosofo filosofo1 = new Filosofo("Rafael", new Token(), new Fork());
            Filosofo filosofo2 = new Filosofo("Andre", new Token(), new Fork());
            Filosofo filosofo3 = new Filosofo("Gabriel", new Token(), new Fork());
            Filosofo filosofo4 = new Filosofo("Pedro", new Token(), new Fork());



            //Filosofo 01 - Rafael
            filosofo1.setFilosofoLado(filosofo4, Lado.Esq);
			filosofo1.setFilosofoLado(filosofo3, Lado.Dir);

            //Filosofo 04 - Pedro
            filosofo4.setFilosofoLado(filosofo2, Lado.Esq);
            filosofo4.setFilosofoLado(filosofo1, Lado.Dir);

            //Filosofo 02 - Andre
            filosofo2.setFilosofoLado(filosofo3, Lado.Esq);
			filosofo2.setFilosofoLado(filosofo4, Lado.Dir);

            

            //Filosofo 03 - Gabriel
            filosofo3.setFilosofoLado(filosofo1, Lado.Esq);
			filosofo3.setFilosofoLado(filosofo2, Lado.Dir);


            //Inclui os filosofos no painel

            this.flowLayoutPanel1.Controls.Add(filosofo1.Usercontroll);
            this.flowLayoutPanel1.Controls.Add(filosofo4.Usercontroll);
            this.flowLayoutPanel1.Controls.Add(filosofo2.Usercontroll);
            this.flowLayoutPanel1.Controls.Add(filosofo3.Usercontroll);
            

            filosofo1.build(); //Rafael
            filosofo4.build(); //Pedro
            filosofo2.build(); //Andre
            filosofo3.build(); //Gabriel
            
        }

    }
}

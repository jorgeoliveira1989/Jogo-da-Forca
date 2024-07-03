using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Jogo_da_Forca___V.FINAL
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 formulario1 = new Form1();
            this.Hide();
            formulario1.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string[] linhas = File.ReadAllText(@"highscores_amador.txt").Split('\n');

            foreach (string linha in linhas.OrderBy(x => x).Take(10))
            {   
                lbl_highscore.Text = lbl_highscore.Text + linha;
            }
          
        }

        
    }
   
}

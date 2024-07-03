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

namespace Jogo_da_Forca___V.FINAL
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string[] linhas = File.ReadAllText(@"highscores_profissional.txt").Split('\n');

            foreach (string linha in linhas.OrderBy(x => x).Take(10))
            {
                lbl_highscore.Text = lbl_highscore.Text + linha;
            }
        }
    }
}

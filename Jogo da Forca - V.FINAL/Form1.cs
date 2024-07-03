using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Jogo_da_Forca___V.FINAL
{
    public partial class Form1 : Form
    {
        public SoundPlayer intro;
        public Form1()
        {
            InitializeComponent();
            intro = new SoundPlayer("intro.wav");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 formulario2 = new Form2();

            intro.Stop();
            this.Hide();
            formulario2.ShowDialog();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            string escolhe = MessageBox.Show("DESEJA SAIR DO JOGO?", "JOGO DA FORCA", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();

            if (escolhe == "Yes")
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            intro.PlayLooping();
        }

        private void btn_highscore_Click(object sender, EventArgs e)
        {
            Form3 formulario3 = new Form3();

            intro.Stop();
            this.Hide();
            formulario3.ShowDialog();
        }
    }
}

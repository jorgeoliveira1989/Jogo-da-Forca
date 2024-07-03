﻿using System;
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string[] linhas = File.ReadAllText(@"highscores_intermedio.txt").Split('\n');

            foreach (string linha in linhas.OrderBy(x => x).Take(10))
            {
                lbl_highscore.Text = lbl_highscore.Text + linha;
            }
        }
    }
}

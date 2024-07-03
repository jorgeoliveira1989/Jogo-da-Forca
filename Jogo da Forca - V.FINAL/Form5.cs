using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Jogo_da_Forca___V.FINAL
{
    public partial class Form5 : Form
    {
        public string[] palavras;
        public string[] dicas;
        public char[] palavraEscondida;

        string palavra, dica, letrasTentadas;
        char letra;
        int palavraEscolhida, quantidade = 0, tentativasErradas = 0, letrasemfalta = 0, tempo = 0;
        bool letraencontada = false, tentativa = false;


        public SoundPlayer jogo;
        public SoundPlayer relogio;
        public SoundPlayer vitoria;
        public SoundPlayer derrota;
        public Form5()
        {
            InitializeComponent();
            palavrasGuardadas();
            MessageBox.Show("NESTE NÍVEL PROFISSIONAL TEM DE ADIVINHAR A PALAVRA E NÃO PODE ERRAR NENHUMA VEZ", "INFORMAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);




            jogo = new SoundPlayer("Jogo.wav");
            relogio = new SoundPlayer("relogio.wav");
            derrota = new SoundPlayer("derrota.wav");
            vitoria = new SoundPlayer("vitoria.wav");

            palavraEscondida = new char[10];
        }

        private void btn_guardaDados_Click(object sender, EventArgs e)
        {
            if (txt_nomejogador.Text == "")
            {
                MessageBox.Show("INDIQUE UM NOME PARA O JOGADOR", "INDICAR NOME", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FileInfo highscoreAmador = new FileInfo(@"highscores_profissional.txt");
                StreamWriter escrever = highscoreAmador.AppendText();

                if (tempo < 10)
                {
                    escrever.WriteLine($"000{tempo} Segundos | {txt_nomejogador.Text}");
                    escrever.Close();
                }
                else if (tempo < 100)
                {
                    escrever.WriteLine($"00{tempo} Segundos | {txt_nomejogador.Text}");
                    escrever.Close();
                }
                else if (tempo < 1000)
                {
                    escrever.WriteLine($"0{tempo} Segundos | {txt_nomejogador.Text}");
                    escrever.Close();
                }
                MessageBox.Show("DADOS GUARDADOS", "", MessageBoxButtons.OK);
                gpb_guardarDados.Enabled = false;
                btn_comecaJogo.Enabled = true;
                pnl_jogo.Enabled = false;
                txt_nomejogador.Text = "";


                //tempo = 0;
            }
        }

        private void btn_verifica_Click(object sender, EventArgs e)
        {
            if (txt_letra.Text == "")
            {
                MessageBox.Show("INDICA UMA LETRA", "INDICAR LETRA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //verifica se a letra já foi encontrada
                letra = txt_letra.Text[0];

                for (int i = 0; i != quantidade; i++)
                {
                    if (letra == palavraEscondida[i])
                    {
                        tentativa = true;
                    }
                }

                //verifica se a Letra já foi tentada
                letrasTentadas = lbl_letrasErradas.Text;
                int quantLetras = letrasTentadas.Length;

                for (int i = 0; i != quantLetras; i++)
                {
                    if (letra == letrasTentadas[i])
                    {
                        tentativa = true;
                    }
                }

                if (tentativa == true)
                {
                    MessageBox.Show("Já jogou essa letra anteriormente.\nTente outra...", "INFORMAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                //procura a letra escondida
                {
                    for (int i = 0; i != quantidade; i++)
                    {
                        if (letra == palavra[i])
                        {
                            palavraEscondida[i] = letra;
                            letraencontada = true;
                            letrasemfalta = letrasemfalta - 1;
                        }
                    }
                }
                //reinicia a palavra exibida no form
                txt_palavra.Text = "";
                for (int i = 0; i != quantidade; i++)
                {
                    txt_palavra.Text = txt_palavra.Text + palavraEscondida[i];
                }

                //Ao ganhar o jogo

                if (letrasemfalta == 0)
                {

                    timer1.Enabled = false;
                    relogio.Stop();
                    vitoria.Play();
                    string ganhou = MessageBox.Show("GANHOU A PARTIDA" + "\n" + "PARABÉNS!!! " + "\n" + "TEMPO: " + tempo + " Segs", "VITÓRIA", MessageBoxButtons.OK, MessageBoxIcon.Information).ToString();

                    //tempo = 0;
                    txt_palavra.Text = "";
                    txt_dica.Text = "";
                    txt_letra.Text = "";
                    lbl_letrasErradas.Text = "";
                    lbl_letrasEMfalta.Text = "";
                    lbl_tentativasErradas.Text = "";
                    pnl_jogo.Enabled = false;
                    btn_verifica.Enabled = false;
                    ptb_cabeca.Visible = true;
                    ptb_bracoEsquerdo.Visible = true;
                    ptb_bracoDireito.Visible = true;
                    ptb_corpo.Visible = true;
                    ptb_pernaEsquerda.Visible = true;
                    ptb_pernaDireita.Visible = true;
                    btn_verifica.Enabled = false;
                    gpb_guardarDados.Enabled = true;
                    btn_comecaJogo.Enabled = false;
                    timer.Text = "";
                    dARKMODEToolStripMenuItem.Enabled = false;


                }

                //Atualiza as letras tentadas

                if ((letraencontada == false) & (tentativa == false))
                {
                    tentativasErradas = tentativasErradas + 1;
                    lbl_letrasErradas.Text = lbl_letrasErradas.Text + " " + letra;
                }

                //atualiza a visualização do boneco na forca
                if (tentativasErradas == 1)
                {
                    ptb_cabeca.Visible = true;
                    txt_palavra.Text = palavra.ToString();
                    timer1.Enabled = false;
                    relogio.Stop();
                    derrota.Play();
                    MessageBox.Show("PERDEU O JOGO.\nTENTE NOVAMENTE!!!", "DERROTA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tempo = 0;
                    txt_palavra.Text = "";
                    txt_dica.Text = "";
                    txt_letra.Text = "";
                    lbl_letrasErradas.Text = "";
                    lbl_letrasEMfalta.Text = "";
                    lbl_tentativasErradas.Text = "";
                    pnl_jogo.Enabled = false;
                    btn_verifica.Enabled = false;
                    ptb_cabeca.Visible = true;
                    ptb_bracoEsquerdo.Visible = true;
                    ptb_bracoDireito.Visible = true;
                    ptb_corpo.Visible = true;
                    ptb_pernaEsquerda.Visible = true;
                    ptb_pernaDireita.Visible = true;
                    btn_verifica.Enabled = false;
                    btn_comecaJogo.Enabled = true;
                    timer.Text = "";
                    dARKMODEToolStripMenuItem.Enabled = false;

                }


                //recomeça as tentativas de comparação

                tentativa = false;
                letraencontada = false;

                txt_letra.Text = "";
                txt_letra.Focus();

                lbl_letrasEMfalta.Text = letrasemfalta.ToString();
                lbl_tentativasErradas.Text = tentativasErradas.ToString();
            }
        }

        private void btn_comecaJogo_Click(object sender, EventArgs e)
        {
            sortearPalavra();
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string escolhe = MessageBox.Show("DESEJA SAIR DO JOGO?", "JOGO DA FORCA", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();

            if (escolhe == "Yes")
            {
                Application.Exit();
            }
        }

        private void sortearPalavra()
        {
            Random sortear = new Random();
            palavraEscolhida = sortear.Next(0, 9);
            palavra = palavras[palavraEscolhida];
            quantidade = palavra.Length;
            letrasemfalta = quantidade;
            dica = dicas[palavraEscolhida];
            txt_palavra.Text = "";

            for (int i = 0; i != quantidade; i++)
            {
                palavraEscondida[i] = '*';
                txt_palavra.Text = txt_palavra.Text + palavraEscondida[i];
            }

            txt_dica.Text = dica.ToString();

            tentativasErradas = 0;
            tempo = 0;
            pnl_jogo.Enabled = true;
            txt_dica.Enabled = false;
            txt_palavra.Enabled = false;
            txt_letra.Focus();
            lbl_letrasErradas.Text = "";
            lbl_letrasEMfalta.Text = letrasemfalta.ToString();
            lbl_tentativasErradas.Text = tentativasErradas.ToString();
            ptb_cabeca.Visible = false;
            ptb_bracoEsquerdo.Visible = true;
            ptb_bracoDireito.Visible = true;
            ptb_corpo.Visible = true;
            ptb_pernaEsquerda.Visible = true;
            ptb_pernaDireita.Visible = true;
            btn_verifica.Enabled = true;
            btn_comecaJogo.Enabled = false;
            timer1.Enabled = true;
            relogio.PlayLooping();
            rELÓGIOToolStripMenuItem.Checked = true;
            dARKMODEToolStripMenuItem.Enabled = true;


        }

        private void palavrasGuardadas()
        {
            palavras = new string[10];
            dicas = new string[10];

            palavras[0] = "batata";
            dicas[0] = "alimento";

            palavras[1] = "carro";
            dicas[1] = "transporte";

            palavras[2] = "nota";
            dicas[2] = "dinheiro";

            palavras[3] = "europa";
            dicas[3] = "mapa";

            palavras[4] = "jogador";
            dicas[4] = "futebol";

            palavras[5] = "um";
            dicas[5] = "número";

            palavras[6] = "marte";
            dicas[6] = "planeta";

            palavras[7] = "smartphone";
            dicas[7] = "eletrónico";

            palavras[8] = "boavista";
            dicas[8] = "Clube de futebol";

            palavras[9] = "dourado";
            dicas[9] = "cor";

        }

        private void dARKMODEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dARKMODEToolStripMenuItem.Checked == true)
            {
                menuStrip1.BackColor = SystemColors.Window;
                menuStrip1.ForeColor = Color.Black;
                pnl_jogo.BackColor = SystemColors.Window;
                listView1.BackColor = SystemColors.Window;
                label1.BackColor = SystemColors.Window;
                label1.ForeColor = Color.Black;
                txt_dica.BackColor = SystemColors.Window;
                txt_dica.ForeColor = Color.Black;
                listView2.BackColor = SystemColors.Window;
                label2.BackColor = SystemColors.Window;
                label2.ForeColor = Color.Black;
                txt_palavra.BackColor = SystemColors.Window;
                txt_palavra.ForeColor = Color.Black;
                listView3.BackColor = SystemColors.Window;
                label3.BackColor = SystemColors.Window;
                label3.ForeColor = Color.Black;
                panel2.BackColor = SystemColors.Window;
                txt_letra.BackColor = SystemColors.Window;
                txt_letra.ForeColor = Color.Black;
                listView4.BackColor = SystemColors.Window;
                label4.BackColor = SystemColors.Window;
                label4.ForeColor = Color.Black;
                lbl_letrasErradas.BackColor = SystemColors.Window;
                lbl_letrasErradas.ForeColor = Color.Red;
                listView5.BackColor = SystemColors.Window;
                label5.BackColor = SystemColors.Window;
                label5.ForeColor = Color.Black;
                lbl_letrasEMfalta.BackColor = SystemColors.Window;
                lbl_letrasEMfalta.ForeColor = Color.Black;
                label6.BackColor = SystemColors.Window;
                label6.ForeColor = Color.Black;
                lbl_tentativasErradas.BackColor = SystemColors.Window;
                lbl_tentativasErradas.ForeColor = Color.Black;
                btn_verifica.BackColor = SystemColors.Window;
                btn_verifica.ForeColor = Color.Black;
                btn_comecaJogo.BackColor = SystemColors.Window;
                btn_comecaJogo.ForeColor = Color.Black;

                dARKMODEToolStripMenuItem.Checked = false;
            }

            else if (dARKMODEToolStripMenuItem.Checked == false)
            {
                menuStrip1.BackColor = Color.Black;
                menuStrip1.ForeColor = Color.White;
                pnl_jogo.BackColor = Color.Black;
                listView1.BackColor = Color.Black;
                label1.BackColor = Color.Black;
                label1.ForeColor = Color.White;
                txt_dica.BackColor = Color.Black;
                txt_dica.ForeColor = Color.White;
                listView2.BackColor = Color.Black;
                label2.BackColor = Color.Black;
                label2.ForeColor = Color.White;
                txt_palavra.BackColor = Color.Black;
                txt_palavra.ForeColor = Color.White;
                listView3.BackColor = Color.Black;
                label3.BackColor = Color.Black;
                label3.ForeColor = Color.White;
                panel2.BackColor = Color.Black;
                txt_letra.BackColor = Color.Black;
                txt_letra.ForeColor = Color.White;
                listView4.BackColor = Color.Black;
                label4.BackColor = Color.Black;
                label4.ForeColor = Color.White;
                lbl_letrasErradas.BackColor = Color.Black;
                lbl_letrasErradas.ForeColor = Color.Red;
                listView5.BackColor = Color.Black;
                label5.BackColor = Color.Black;
                label5.ForeColor = Color.White;
                lbl_letrasEMfalta.BackColor = Color.Black;
                lbl_letrasEMfalta.ForeColor = Color.White;
                label6.BackColor = Color.Black;
                label6.ForeColor = Color.White;
                lbl_tentativasErradas.BackColor = Color.Black;
                lbl_tentativasErradas.ForeColor = Color.White;
                btn_verifica.BackColor = Color.DarkGray;
                btn_verifica.ForeColor = Color.White;
                btn_comecaJogo.BackColor = Color.DarkGray;
                btn_comecaJogo.ForeColor = Color.White;

                dARKMODEToolStripMenuItem.Checked = true;
            }
        }

        private void sOBREJOGODAFORCAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 ajuda = new Form9();
            ajuda.ShowDialog();
        }

        private void pROFISSIONALToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form8 highscore_profissional = new Form8();
            highscore_profissional.ShowDialog();
        }

        private void iNTERMÉDIOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form7 highscore_intermedio = new Form7();
            highscore_intermedio.ShowDialog();
        }

        private void aMADORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 highscore_amador = new Form6();
            highscore_amador.ShowDialog();
        }

        private void iNTERMÉDIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 formulario4 = new Form4();

            jogo.Stop();
            relogio.Stop();
            this.Hide();
            formulario4.ShowDialog();
        }

        private void nIVÉLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 formulario2 = new Form2();

            jogo.Stop();
            relogio.Stop();
            this.Hide();
            formulario2.ShowDialog();
        }

        private void sOMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (sOMToolStripMenuItem1.Checked == false)
            {
                jogo.PlayLooping();
                sOMToolStripMenuItem1.Checked = true;
                rELÓGIOToolStripMenuItem.Checked = false;
            }
            else if (sOMToolStripMenuItem1.Checked == true)
            {
                jogo.Stop();
                sOMToolStripMenuItem1.Checked = false;
            }
        }

        private void rELÓGIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rELÓGIOToolStripMenuItem.Checked == false)
            {
                relogio.PlayLooping();
                rELÓGIOToolStripMenuItem.Checked = true;
                sOMToolStripMenuItem1.Checked = false;
            }

            else if (rELÓGIOToolStripMenuItem.Checked == true)
            {
                relogio.Stop();
                rELÓGIOToolStripMenuItem.Checked = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tempo = tempo + 1;
            timer.Text = tempo.ToString();
        }

        private void pALMEIRASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pALMEIRASToolStripMenuItem.Checked == false)
            {

                Image background = new Bitmap(@"palmeiras.jpg");
                this.BackgroundImage = background;

                dEFAULTToolStripMenuItem.Checked = false;
                vERDEToolStripMenuItem.Checked = false;
                aSASToolStripMenuItem.Checked = false;
                cAVEIRAToolStripMenuItem.Checked = false;
                lEDToolStripMenuItem.Checked = false;
                mULTICORToolStripMenuItem.Checked = false;
                pALMEIRASToolStripMenuItem.Checked = true;
            }
        }

        private void mULTICORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mULTICORToolStripMenuItem.Checked == false)
            {
                Image background = new Bitmap(@"multicor.jpg");
                this.BackgroundImage = background;

                dEFAULTToolStripMenuItem.Checked = false;
                vERDEToolStripMenuItem.Checked = false;
                aSASToolStripMenuItem.Checked = false;
                cAVEIRAToolStripMenuItem.Checked = false;
                lEDToolStripMenuItem.Checked = false;
                mULTICORToolStripMenuItem.Checked = true;
                pALMEIRASToolStripMenuItem.Checked = false;
            }
        }

        private void lEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lEDToolStripMenuItem.Checked == false)
            {
                Image background = new Bitmap(@"led.jpg");
                this.BackgroundImage = background;

                dEFAULTToolStripMenuItem.Checked = false;
                vERDEToolStripMenuItem.Checked = false;
                aSASToolStripMenuItem.Checked = false;
                cAVEIRAToolStripMenuItem.Checked = false;
                lEDToolStripMenuItem.Checked = true;
                mULTICORToolStripMenuItem.Checked = false;
                pALMEIRASToolStripMenuItem.Checked = false;
            }
        }

        private void cAVEIRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cAVEIRAToolStripMenuItem.Checked == false)
            {
                Image background = new Bitmap(@"caveira.jpg");
                this.BackgroundImage = background;

                dEFAULTToolStripMenuItem.Checked = false;
                vERDEToolStripMenuItem.Checked = false;
                aSASToolStripMenuItem.Checked = false;
                cAVEIRAToolStripMenuItem.Checked = true;
                lEDToolStripMenuItem.Checked = false;
                mULTICORToolStripMenuItem.Checked = false;
                pALMEIRASToolStripMenuItem.Checked = false;
            }
        }

        private void aSASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aSASToolStripMenuItem.Checked == false)
            {
                Image background = new Bitmap(@"asas.jpg");
                this.BackgroundImage = background;

                aSASToolStripMenuItem.Checked = true;
                dEFAULTToolStripMenuItem.Checked = false;
                vERDEToolStripMenuItem.Checked = false;
                cAVEIRAToolStripMenuItem.Checked = false;
                lEDToolStripMenuItem.Checked = false;
                mULTICORToolStripMenuItem.Checked = false;
                pALMEIRASToolStripMenuItem.Checked = false;
            }
        }

        private void vERDEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vERDEToolStripMenuItem.Checked == false)
            {
                Image background = new Bitmap(@"verde.jpg");
                this.BackgroundImage = background;

                vERDEToolStripMenuItem.Checked = true;
                dEFAULTToolStripMenuItem.Checked = false;
                aSASToolStripMenuItem.Checked = false;
                cAVEIRAToolStripMenuItem.Checked = false;
                lEDToolStripMenuItem.Checked = false;
                mULTICORToolStripMenuItem.Checked = false;
                pALMEIRASToolStripMenuItem.Checked = false;
            }
        }

        private void dEFAULTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dEFAULTToolStripMenuItem.Checked == false)
            {
                Image background = new Bitmap(@"azul.jpg");
                this.BackgroundImage = background;
                dEFAULTToolStripMenuItem.Checked = true;
                vERDEToolStripMenuItem.Checked = false;
                aSASToolStripMenuItem.Checked = false;
                cAVEIRAToolStripMenuItem.Checked = false;
                lEDToolStripMenuItem.Checked = false;
                mULTICORToolStripMenuItem.Checked = false;
                pALMEIRASToolStripMenuItem.Checked = false;
            }
        }

        private void nOVOJOGOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortearPalavra();
        }

        private void txt_letra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || (char.IsPunctuation(e.KeyChar) || (char.IsSymbol(e.KeyChar) || (char.IsWhiteSpace(e.KeyChar)))))
            {
                e.Handled = true;
            }
        }
    }
}

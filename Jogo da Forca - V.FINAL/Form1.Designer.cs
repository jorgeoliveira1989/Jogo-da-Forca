namespace Jogo_da_Forca___V.FINAL
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_jogar = new System.Windows.Forms.Button();
            this.btn_sair = new System.Windows.Forms.Button();
            this.btn_highscore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_jogar
            // 
            this.btn_jogar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_jogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_jogar.Location = new System.Drawing.Point(138, 264);
            this.btn_jogar.Name = "btn_jogar";
            this.btn_jogar.Size = new System.Drawing.Size(158, 43);
            this.btn_jogar.TabIndex = 3;
            this.btn_jogar.Text = "JOGAR";
            this.btn_jogar.UseVisualStyleBackColor = false;
            this.btn_jogar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_sair
            // 
            this.btn_sair.BackColor = System.Drawing.Color.White;
            this.btn_sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sair.Location = new System.Drawing.Point(138, 346);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(158, 43);
            this.btn_sair.TabIndex = 4;
            this.btn_sair.Text = "SAIR";
            this.btn_sair.UseVisualStyleBackColor = false;
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // btn_highscore
            // 
            this.btn_highscore.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_highscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_highscore.Location = new System.Drawing.Point(138, 305);
            this.btn_highscore.Name = "btn_highscore";
            this.btn_highscore.Size = new System.Drawing.Size(158, 43);
            this.btn_highscore.TabIndex = 5;
            this.btn_highscore.Text = "HIGHSCORE";
            this.btn_highscore.UseVisualStyleBackColor = false;
            this.btn_highscore.Click += new System.EventHandler(this.btn_highscore_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(299, 392);
            this.Controls.Add(this.btn_highscore);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_jogar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JOGO DA FORCA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_jogar;
        private System.Windows.Forms.Button btn_sair;
        private System.Windows.Forms.Button btn_highscore;
    }
}


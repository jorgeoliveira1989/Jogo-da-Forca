namespace Jogo_da_Forca___V.FINAL
{
    partial class Form9
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form9));
            this.label1 = new System.Windows.Forms.Label();
            this.rtb_texto = new System.Windows.Forms.RichTextBox();
            this.btn_fechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "SOBRE O JOGO";
            // 
            // rtb_texto
            // 
            this.rtb_texto.BackColor = System.Drawing.Color.White;
            this.rtb_texto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_texto.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_texto.Location = new System.Drawing.Point(12, 53);
            this.rtb_texto.Name = "rtb_texto";
            this.rtb_texto.ReadOnly = true;
            this.rtb_texto.Size = new System.Drawing.Size(382, 385);
            this.rtb_texto.TabIndex = 1;
            this.rtb_texto.Text = resources.GetString("rtb_texto.Text");
            // 
            // btn_fechar
            // 
            this.btn_fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fechar.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_fechar.Location = new System.Drawing.Point(307, 8);
            this.btn_fechar.Name = "btn_fechar";
            this.btn_fechar.Size = new System.Drawing.Size(87, 39);
            this.btn_fechar.TabIndex = 2;
            this.btn_fechar.Text = "FECHAR";
            this.btn_fechar.UseVisualStyleBackColor = true;
            this.btn_fechar.Click += new System.EventHandler(this.btn_fechar_Click);
            // 
            // Form9
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(406, 450);
            this.Controls.Add(this.btn_fechar);
            this.Controls.Add(this.rtb_texto);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form9";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form9";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtb_texto;
        private System.Windows.Forms.Button btn_fechar;
    }
}
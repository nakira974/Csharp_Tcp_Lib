namespace JeuDuPendu
{
    partial class GameForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bReset = new System.Windows.Forms.Button();
            this.lCrypedWord = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 256);
            this.panel1.TabIndex = 0;
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(92, 319);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(90, 35);
            this.bReset.TabIndex = 1;
            this.bReset.Text = "Nouvelle partie";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            this.bReset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bReset_KeyPress);
            // 
            // lCrypedWord
            // 
            this.lCrypedWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCrypedWord.Location = new System.Drawing.Point(12, 277);
            this.lCrypedWord.Name = "lCrypedWord";
            this.lCrypedWord.Size = new System.Drawing.Size(255, 39);
            this.lCrypedWord.TabIndex = 2;
            this.lCrypedWord.Text = "--";
            this.lCrypedWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 363);
            this.Controls.Add(this.lCrypedWord);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.panel1);
            this.Name = "GameForm";
            this.Text = "Jeux du pendu";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GameForm_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Label lCrypedWord;
    }
}


namespace Bingo
{
    partial class GamePage
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.bingoGridPanel = new System.Windows.Forms.Panel();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.BingoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bingoGridPanel
            // 
            this.bingoGridPanel.BackColor = System.Drawing.Color.PaleGreen;
            this.bingoGridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bingoGridPanel.Location = new System.Drawing.Point(296, 327);
            this.bingoGridPanel.Name = "bingoGridPanel";
            this.bingoGridPanel.Size = new System.Drawing.Size(324, 238);
            this.bingoGridPanel.TabIndex = 0;
            // 
            // GamePanel
            // 
            this.GamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GamePanel.Location = new System.Drawing.Point(52, 27);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(805, 294);
            this.GamePanel.TabIndex = 1;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(288, 598);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(332, 65);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // BingoButton
            // 
            this.BingoButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.BingoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BingoButton.ForeColor = System.Drawing.Color.Red;
            this.BingoButton.Location = new System.Drawing.Point(571, 598);
            this.BingoButton.Name = "BingoButton";
            this.BingoButton.Size = new System.Drawing.Size(311, 79);
            this.BingoButton.TabIndex = 0;
            this.BingoButton.Text = "BINGO";
            this.BingoButton.UseVisualStyleBackColor = false;
            this.BingoButton.Click += new System.EventHandler(this.BingoButton_Click_1);
            // 
            // GamePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(903, 693);
            this.Controls.Add(this.BingoButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.bingoGridPanel);
            this.Name = "GamePage";
            this.Text = "Bingo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GamePage_FormClosing);
            this.Load += new System.EventHandler(this.GamePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bingoGridPanel;
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button BingoButton;
    }
}


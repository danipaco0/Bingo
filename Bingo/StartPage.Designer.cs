namespace Bingo
{
    partial class StartPage
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
            this.textBoxIPAdress = new System.Windows.Forms.TextBox();
            this.textBoxPortNumber = new System.Windows.Forms.TextBox();
            this.buttonStartClient = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.usernameList = new System.Windows.Forms.ListBox();
            this.labelConnectedPlayers = new System.Windows.Forms.Label();
            this.server_ready = new System.Windows.Forms.Label();
            this.serverStart = new System.Windows.Forms.Button();
            this.players_ready = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxIPAdress
            // 
            this.textBoxIPAdress.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIPAdress.Location = new System.Drawing.Point(320, 109);
            this.textBoxIPAdress.Name = "textBoxIPAdress";
            this.textBoxIPAdress.Size = new System.Drawing.Size(118, 30);
            this.textBoxIPAdress.TabIndex = 0;
            this.textBoxIPAdress.Text = "127.0.0.1";
            // 
            // textBoxPortNumber
            // 
            this.textBoxPortNumber.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPortNumber.Location = new System.Drawing.Point(444, 109);
            this.textBoxPortNumber.Name = "textBoxPortNumber";
            this.textBoxPortNumber.Size = new System.Drawing.Size(83, 30);
            this.textBoxPortNumber.TabIndex = 1;
            this.textBoxPortNumber.Text = "9999";
            // 
            // buttonStartClient
            // 
            this.buttonStartClient.Location = new System.Drawing.Point(40, 187);
            this.buttonStartClient.Name = "buttonStartClient";
            this.buttonStartClient.Size = new System.Drawing.Size(207, 65);
            this.buttonStartClient.TabIndex = 3;
            this.buttonStartClient.Text = "Start Client";
            this.buttonStartClient.UseVisualStyleBackColor = true;
            this.buttonStartClient.Click += new System.EventHandler(this.buttonStartClient_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(40, 20);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(208, 22);
            this.nameBox.TabIndex = 5;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // usernameList
            // 
            this.usernameList.FormattingEnabled = true;
            this.usernameList.ItemHeight = 16;
            this.usernameList.Location = new System.Drawing.Point(40, 92);
            this.usernameList.Name = "usernameList";
            this.usernameList.Size = new System.Drawing.Size(205, 84);
            this.usernameList.TabIndex = 6;
            // 
            // labelConnectedPlayers
            // 
            this.labelConnectedPlayers.AutoSize = true;
            this.labelConnectedPlayers.Location = new System.Drawing.Point(37, 63);
            this.labelConnectedPlayers.Name = "labelConnectedPlayers";
            this.labelConnectedPlayers.Size = new System.Drawing.Size(136, 16);
            this.labelConnectedPlayers.TabIndex = 7;
            this.labelConnectedPlayers.Text = "Joueurs connectés : 0";
            // 
            // server_ready
            // 
            this.server_ready.AutoSize = true;
            this.server_ready.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server_ready.ForeColor = System.Drawing.Color.Red;
            this.server_ready.Location = new System.Drawing.Point(334, 9);
            this.server_ready.Name = "server_ready";
            this.server_ready.Size = new System.Drawing.Size(193, 37);
            this.server_ready.TabIndex = 8;
            this.server_ready.Text = "Server down";
            // 
            // serverStart
            // 
            this.serverStart.Location = new System.Drawing.Point(320, 187);
            this.serverStart.Name = "serverStart";
            this.serverStart.Size = new System.Drawing.Size(207, 65);
            this.serverStart.TabIndex = 9;
            this.serverStart.Text = "Start Server";
            this.serverStart.UseVisualStyleBackColor = true;
            this.serverStart.Click += new System.EventHandler(this.serverStart_Click);
            // 
            // players_ready
            // 
            this.players_ready.AutoSize = true;
            this.players_ready.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.players_ready.Location = new System.Drawing.Point(337, 63);
            this.players_ready.Name = "players_ready";
            this.players_ready.Size = new System.Drawing.Size(126, 20);
            this.players_ready.TabIndex = 10;
            this.players_ready.Text = "Players ready : ";
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 264);
            this.Controls.Add(this.players_ready);
            this.Controls.Add(this.serverStart);
            this.Controls.Add(this.server_ready);
            this.Controls.Add(this.labelConnectedPlayers);
            this.Controls.Add(this.usernameList);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.buttonStartClient);
            this.Controls.Add(this.textBoxPortNumber);
            this.Controls.Add(this.textBoxIPAdress);
            this.Name = "StartPage";
            this.Text = "StartPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIPAdress;
        private System.Windows.Forms.TextBox textBoxPortNumber;
        private System.Windows.Forms.Button buttonStartClient;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.ListBox usernameList;
        private System.Windows.Forms.Label labelConnectedPlayers;
        private System.Windows.Forms.Label server_ready;
        private System.Windows.Forms.Button serverStart;
        private System.Windows.Forms.Label players_ready;
    }
}
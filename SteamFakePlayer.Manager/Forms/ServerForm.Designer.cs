namespace SteamFakePlayer.Manager
{
    partial class ServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.gbPlayers = new System.Windows.Forms.GroupBox();
            this.tbAccounts = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLoadedCaption = new System.Windows.Forms.Label();
            this.lblLoaded = new System.Windows.Forms.Label();
            this.lblActiveBots = new System.Windows.Forms.Label();
            this.lblActiveBotsCaption = new System.Windows.Forms.Label();
            this.gbAdministration = new System.Windows.Forms.GroupBox();
            this.cbShowAccounts = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.gbPlayers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPlayers
            // 
            this.gbPlayers.Controls.Add(this.button4);
            this.gbPlayers.Controls.Add(this.cbShowAccounts);
            this.gbPlayers.Controls.Add(this.tbAccounts);
            this.gbPlayers.Location = new System.Drawing.Point(14, 13);
            this.gbPlayers.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbPlayers.Name = "gbPlayers";
            this.gbPlayers.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbPlayers.Size = new System.Drawing.Size(288, 356);
            this.gbPlayers.TabIndex = 3;
            this.gbPlayers.TabStop = false;
            this.gbPlayers.Text = "Список аккаунтов (login:pass)";
            // 
            // tbAccounts
            // 
            this.tbAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAccounts.Location = new System.Drawing.Point(10, 51);
            this.tbAccounts.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbAccounts.Multiline = true;
            this.tbAccounts.Name = "tbAccounts";
            this.tbAccounts.PasswordChar = '*';
            this.tbAccounts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAccounts.Size = new System.Drawing.Size(265, 265);
            this.tbAccounts.TabIndex = 1;
            this.tbAccounts.Text = "fhytj";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblActiveBots);
            this.groupBox1.Controls.Add(this.lblActiveBotsCaption);
            this.groupBox1.Controls.Add(this.lblLoaded);
            this.groupBox1.Controls.Add(this.lblLoadedCaption);
            this.groupBox1.Location = new System.Drawing.Point(310, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 178);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Показатели";
            // 
            // lblLoadedCaption
            // 
            this.lblLoadedCaption.AutoSize = true;
            this.lblLoadedCaption.Location = new System.Drawing.Point(6, 32);
            this.lblLoadedCaption.Name = "lblLoadedCaption";
            this.lblLoadedCaption.Size = new System.Drawing.Size(195, 18);
            this.lblLoadedCaption.TabIndex = 0;
            this.lblLoadedCaption.Text = "Загружено аккаунтов:";
            // 
            // lblLoaded
            // 
            this.lblLoaded.AutoSize = true;
            this.lblLoaded.Location = new System.Drawing.Point(195, 32);
            this.lblLoaded.Name = "lblLoaded";
            this.lblLoaded.Size = new System.Drawing.Size(18, 18);
            this.lblLoaded.TabIndex = 1;
            this.lblLoaded.Text = "0";
            // 
            // lblActiveBots
            // 
            this.lblActiveBots.AutoSize = true;
            this.lblActiveBots.Location = new System.Drawing.Point(164, 60);
            this.lblActiveBots.Name = "lblActiveBots";
            this.lblActiveBots.Size = new System.Drawing.Size(18, 18);
            this.lblActiveBots.TabIndex = 3;
            this.lblActiveBots.Text = "0";
            // 
            // lblActiveBotsCaption
            // 
            this.lblActiveBotsCaption.AutoSize = true;
            this.lblActiveBotsCaption.Location = new System.Drawing.Point(6, 60);
            this.lblActiveBotsCaption.Name = "lblActiveBotsCaption";
            this.lblActiveBotsCaption.Size = new System.Drawing.Size(164, 18);
            this.lblActiveBotsCaption.TabIndex = 2;
            this.lblActiveBotsCaption.Text = "Ботов на сервере:";
            // 
            // gbAdministration
            // 
            this.gbAdministration.Location = new System.Drawing.Point(310, 197);
            this.gbAdministration.Name = "gbAdministration";
            this.gbAdministration.Size = new System.Drawing.Size(348, 172);
            this.gbAdministration.TabIndex = 5;
            this.gbAdministration.TabStop = false;
            this.gbAdministration.Text = "Управление";
            // 
            // cbShowAccounts
            // 
            this.cbShowAccounts.AutoSize = true;
            this.cbShowAccounts.Location = new System.Drawing.Point(10, 22);
            this.cbShowAccounts.Name = "cbShowAccounts";
            this.cbShowAccounts.Size = new System.Drawing.Size(103, 22);
            this.cbShowAccounts.TabIndex = 2;
            this.cbShowAccounts.Text = "Показать";
            this.cbShowAccounts.UseVisualStyleBackColor = true;
            this.cbShowAccounts.CheckedChanged += new System.EventHandler(this.cbShowAccounts_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(10, 323);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(265, 26);
            this.button4.TabIndex = 3;
            this.button4.Text = "Загрузить файл";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 382);
            this.Controls.Add(this.gbAdministration);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbPlayers);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ServerForm";
            this.gbPlayers.ResumeLayout(false);
            this.gbPlayers.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPlayers;
        private System.Windows.Forms.CheckBox cbShowAccounts;
        private System.Windows.Forms.TextBox tbAccounts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblActiveBots;
        private System.Windows.Forms.Label lblActiveBotsCaption;
        private System.Windows.Forms.Label lblLoaded;
        private System.Windows.Forms.Label lblLoadedCaption;
        private System.Windows.Forms.GroupBox gbAdministration;
        private System.Windows.Forms.Button button4;
    }
}
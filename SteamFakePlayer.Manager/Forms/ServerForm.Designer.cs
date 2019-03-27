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
            this.btnLoadAccountsFile = new System.Windows.Forms.Button();
            this.cbShowAccounts = new System.Windows.Forms.CheckBox();
            this.tbAccounts = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblActiveBots = new System.Windows.Forms.Label();
            this.lblActiveBotsCaption = new System.Windows.Forms.Label();
            this.lblLoaded = new System.Windows.Forms.Label();
            this.lblLoadedCaption = new System.Windows.Forms.Label();
            this.gbAdministration = new System.Windows.Forms.GroupBox();
            this.tlpControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnCheckServerAvailable = new System.Windows.Forms.Button();
            this.btnConnectBots = new System.Windows.Forms.Button();
            this.btnDisconnectBots = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOptions = new System.Windows.Forms.Button();
            this.gbPlayers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbAdministration.SuspendLayout();
            this.tlpControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPlayers
            // 
            this.gbPlayers.Controls.Add(this.btnLoadAccountsFile);
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
            // btnLoadAccountsFile
            // 
            this.btnLoadAccountsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadAccountsFile.Location = new System.Drawing.Point(10, 322);
            this.btnLoadAccountsFile.Name = "btnLoadAccountsFile";
            this.btnLoadAccountsFile.Size = new System.Drawing.Size(265, 27);
            this.btnLoadAccountsFile.TabIndex = 3;
            this.btnLoadAccountsFile.Text = "Загрузить файл";
            this.btnLoadAccountsFile.UseVisualStyleBackColor = true;
            this.btnLoadAccountsFile.Click += new System.EventHandler(this.btnLoadAccountsFile_Click);
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
            this.groupBox1.Size = new System.Drawing.Size(349, 178);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Показатели";
            // 
            // lblActiveBots
            // 
            this.lblActiveBots.AutoSize = true;
            this.lblActiveBots.ForeColor = System.Drawing.Color.Green;
            this.lblActiveBots.Location = new System.Drawing.Point(164, 60);
            this.lblActiveBots.Name = "lblActiveBots";
            this.lblActiveBots.Size = new System.Drawing.Size(18, 18);
            this.lblActiveBots.TabIndex = 3;
            this.lblActiveBots.Text = "0";
            // 
            // lblActiveBotsCaption
            // 
            this.lblActiveBotsCaption.AutoSize = true;
            this.lblActiveBotsCaption.ForeColor = System.Drawing.Color.Green;
            this.lblActiveBotsCaption.Location = new System.Drawing.Point(6, 60);
            this.lblActiveBotsCaption.Name = "lblActiveBotsCaption";
            this.lblActiveBotsCaption.Size = new System.Drawing.Size(164, 18);
            this.lblActiveBotsCaption.TabIndex = 2;
            this.lblActiveBotsCaption.Text = "Ботов на сервере:";
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
            // lblLoadedCaption
            // 
            this.lblLoadedCaption.AutoSize = true;
            this.lblLoadedCaption.Location = new System.Drawing.Point(6, 32);
            this.lblLoadedCaption.Name = "lblLoadedCaption";
            this.lblLoadedCaption.Size = new System.Drawing.Size(195, 18);
            this.lblLoadedCaption.TabIndex = 0;
            this.lblLoadedCaption.Text = "Загружено аккаунтов:";
            // 
            // gbAdministration
            // 
            this.gbAdministration.Controls.Add(this.tlpControls);
            this.gbAdministration.Location = new System.Drawing.Point(310, 197);
            this.gbAdministration.Name = "gbAdministration";
            this.gbAdministration.Size = new System.Drawing.Size(348, 172);
            this.gbAdministration.TabIndex = 5;
            this.gbAdministration.TabStop = false;
            this.gbAdministration.Text = "Управление";
            // 
            // tlpControls
            // 
            this.tlpControls.ColumnCount = 1;
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpControls.Controls.Add(this.btnOptions, 0, 2);
            this.tlpControls.Controls.Add(this.btnCheckServerAvailable, 0, 0);
            this.tlpControls.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tlpControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControls.Location = new System.Drawing.Point(3, 23);
            this.tlpControls.Name = "tlpControls";
            this.tlpControls.RowCount = 3;
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.74757F));
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.25243F));
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpControls.Size = new System.Drawing.Size(342, 146);
            this.tlpControls.TabIndex = 0;
            // 
            // btnCheckServerAvailable
            // 
            this.btnCheckServerAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheckServerAvailable.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCheckServerAvailable.Location = new System.Drawing.Point(3, 3);
            this.btnCheckServerAvailable.Name = "btnCheckServerAvailable";
            this.btnCheckServerAvailable.Size = new System.Drawing.Size(336, 37);
            this.btnCheckServerAvailable.TabIndex = 0;
            this.btnCheckServerAvailable.Text = "Проверить доступность сервера";
            this.btnCheckServerAvailable.UseVisualStyleBackColor = true;
            this.btnCheckServerAvailable.Click += new System.EventHandler(this.btnCheckServerAvailable_Click);
            // 
            // btnConnectBots
            // 
            this.btnConnectBots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectBots.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConnectBots.ForeColor = System.Drawing.Color.Green;
            this.btnConnectBots.Location = new System.Drawing.Point(3, 3);
            this.btnConnectBots.Name = "btnConnectBots";
            this.btnConnectBots.Size = new System.Drawing.Size(165, 54);
            this.btnConnectBots.TabIndex = 1;
            this.btnConnectBots.Text = "Запустить стадо";
            this.btnConnectBots.UseVisualStyleBackColor = true;
            this.btnConnectBots.Click += new System.EventHandler(this.btnConnectBots_Click);
            // 
            // btnDisconnectBots
            // 
            this.btnDisconnectBots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDisconnectBots.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDisconnectBots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDisconnectBots.Location = new System.Drawing.Point(174, 3);
            this.btnDisconnectBots.Name = "btnDisconnectBots";
            this.btnDisconnectBots.Size = new System.Drawing.Size(165, 54);
            this.btnDisconnectBots.TabIndex = 2;
            this.btnDisconnectBots.Text = "Идём баиньки";
            this.btnDisconnectBots.UseVisualStyleBackColor = true;
            this.btnDisconnectBots.Click += new System.EventHandler(this.btnDisconnectBots_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnDisconnectBots, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnConnectBots, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(342, 60);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnOptions
            // 
            this.btnOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOptions.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOptions.Location = new System.Drawing.Point(3, 106);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(336, 37);
            this.btnOptions.TabIndex = 4;
            this.btnOptions.Text = "Настройки";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 382);
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
            this.gbAdministration.ResumeLayout(false);
            this.tlpControls.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnLoadAccountsFile;
        private System.Windows.Forms.Button btnCheckServerAvailable;
        private System.Windows.Forms.TableLayoutPanel tlpControls;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnDisconnectBots;
        private System.Windows.Forms.Button btnConnectBots;
    }
}
namespace SteamFakePlayer.Manager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblInfo = new System.Windows.Forms.Label();
            this.gbServerList = new System.Windows.Forms.GroupBox();
            this.btnDeleteServer = new System.Windows.Forms.Button();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.lbServers = new System.Windows.Forms.ListBox();
            this.btnOpenServer = new System.Windows.Forms.Button();
            this.gbLicence = new System.Windows.Forms.GroupBox();
            this.lblLicenceUsername = new System.Windows.Forms.Label();
            this.lblLicenceUsernameCaption = new System.Windows.Forms.Label();
            this.lblLicenceStatus = new System.Windows.Forms.Label();
            this.lblLicenceStatusCaption = new System.Windows.Forms.Label();
            this.btnCopyKey = new System.Windows.Forms.Button();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.llRustyCode = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSettingsJoinerPath = new System.Windows.Forms.ToolStripMenuItem();
            this.gbServerList.SuspendLayout();
            this.gbLicence.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Location = new System.Drawing.Point(18, 24);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(375, 41);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Программа: SteamFakePlayer\r\nРазработчик: bazuka5801";
            // 
            // gbServerList
            // 
            this.gbServerList.Controls.Add(this.btnDeleteServer);
            this.gbServerList.Controls.Add(this.btnAddServer);
            this.gbServerList.Controls.Add(this.lbServers);
            this.gbServerList.Controls.Add(this.btnOpenServer);
            this.gbServerList.Location = new System.Drawing.Point(12, 229);
            this.gbServerList.Name = "gbServerList";
            this.gbServerList.Size = new System.Drawing.Size(382, 213);
            this.gbServerList.TabIndex = 3;
            this.gbServerList.TabStop = false;
            this.gbServerList.Text = "Список серверов";
            // 
            // btnDeleteServer
            // 
            this.btnDeleteServer.Location = new System.Drawing.Point(274, 180);
            this.btnDeleteServer.Name = "btnDeleteServer";
            this.btnDeleteServer.Size = new System.Drawing.Size(102, 26);
            this.btnDeleteServer.TabIndex = 3;
            this.btnDeleteServer.Text = "Удалить";
            this.btnDeleteServer.UseVisualStyleBackColor = true;
            this.btnDeleteServer.Click += new System.EventHandler(this.btnDeleteServer_Click);
            // 
            // btnAddServer
            // 
            this.btnAddServer.Location = new System.Drawing.Point(166, 180);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(102, 26);
            this.btnAddServer.TabIndex = 2;
            this.btnAddServer.Text = "Добавить";
            this.btnAddServer.UseVisualStyleBackColor = true;
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // lbServers
            // 
            this.lbServers.FormattingEnabled = true;
            this.lbServers.ItemHeight = 18;
            this.lbServers.Location = new System.Drawing.Point(9, 26);
            this.lbServers.Name = "lbServers";
            this.lbServers.Size = new System.Drawing.Size(367, 148);
            this.lbServers.TabIndex = 1;
            // 
            // btnOpenServer
            // 
            this.btnOpenServer.Location = new System.Drawing.Point(9, 180);
            this.btnOpenServer.Name = "btnOpenServer";
            this.btnOpenServer.Size = new System.Drawing.Size(102, 26);
            this.btnOpenServer.TabIndex = 0;
            this.btnOpenServer.Text = "Открыть";
            this.btnOpenServer.UseVisualStyleBackColor = true;
            this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
            // 
            // gbLicence
            // 
            this.gbLicence.Controls.Add(this.lblLicenceUsername);
            this.gbLicence.Controls.Add(this.lblLicenceUsernameCaption);
            this.gbLicence.Controls.Add(this.lblLicenceStatus);
            this.gbLicence.Controls.Add(this.lblLicenceStatusCaption);
            this.gbLicence.Controls.Add(this.btnCopyKey);
            this.gbLicence.Controls.Add(this.tbKey);
            this.gbLicence.Controls.Add(this.lblKey);
            this.gbLicence.Location = new System.Drawing.Point(12, 116);
            this.gbLicence.Name = "gbLicence";
            this.gbLicence.Size = new System.Drawing.Size(382, 107);
            this.gbLicence.TabIndex = 4;
            this.gbLicence.TabStop = false;
            this.gbLicence.Text = "Лицензия";
            // 
            // lblLicenceUsername
            // 
            this.lblLicenceUsername.AutoSize = true;
            this.lblLicenceUsername.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblLicenceUsername.Location = new System.Drawing.Point(78, 76);
            this.lblLicenceUsername.Name = "lblLicenceUsername";
            this.lblLicenceUsername.Size = new System.Drawing.Size(19, 14);
            this.lblLicenceUsername.TabIndex = 6;
            this.lblLicenceUsername.Text = "...";
            // 
            // lblLicenceUsernameCaption
            // 
            this.lblLicenceUsernameCaption.AutoSize = true;
            this.lblLicenceUsernameCaption.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblLicenceUsernameCaption.Location = new System.Drawing.Point(6, 76);
            this.lblLicenceUsernameCaption.Name = "lblLicenceUsernameCaption";
            this.lblLicenceUsernameCaption.Size = new System.Drawing.Size(76, 14);
            this.lblLicenceUsernameCaption.TabIndex = 5;
            this.lblLicenceUsernameCaption.Text = "Username:";
            // 
            // lblLicenceStatus
            // 
            this.lblLicenceStatus.AutoSize = true;
            this.lblLicenceStatus.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblLicenceStatus.Location = new System.Drawing.Point(55, 52);
            this.lblLicenceStatus.Name = "lblLicenceStatus";
            this.lblLicenceStatus.Size = new System.Drawing.Size(19, 14);
            this.lblLicenceStatus.TabIndex = 4;
            this.lblLicenceStatus.Text = "...";
            // 
            // lblLicenceStatusCaption
            // 
            this.lblLicenceStatusCaption.AutoSize = true;
            this.lblLicenceStatusCaption.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblLicenceStatusCaption.Location = new System.Drawing.Point(6, 52);
            this.lblLicenceStatusCaption.Name = "lblLicenceStatusCaption";
            this.lblLicenceStatusCaption.Size = new System.Drawing.Size(53, 14);
            this.lblLicenceStatusCaption.TabIndex = 3;
            this.lblLicenceStatusCaption.Text = "Status:";
            // 
            // btnCopyKey
            // 
            this.btnCopyKey.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCopyKey.Location = new System.Drawing.Point(325, 23);
            this.btnCopyKey.Name = "btnCopyKey";
            this.btnCopyKey.Size = new System.Drawing.Size(51, 23);
            this.btnCopyKey.TabIndex = 2;
            this.btnCopyKey.Text = "Copy";
            this.btnCopyKey.UseVisualStyleBackColor = true;
            // 
            // tbKey
            // 
            this.tbKey.Font = new System.Drawing.Font("Verdana", 9F);
            this.tbKey.Location = new System.Drawing.Point(42, 24);
            this.tbKey.Name = "tbKey";
            this.tbKey.ReadOnly = true;
            this.tbKey.Size = new System.Drawing.Size(277, 22);
            this.tbKey.TabIndex = 1;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblKey.Location = new System.Drawing.Point(6, 28);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(30, 14);
            this.lblKey.TabIndex = 0;
            this.lblKey.Text = "Key";
            // 
            // llRustyCode
            // 
            this.llRustyCode.AutoSize = true;
            this.llRustyCode.Location = new System.Drawing.Point(18, 83);
            this.llRustyCode.Name = "llRustyCode";
            this.llRustyCode.Size = new System.Drawing.Size(151, 18);
            this.llRustyCode.TabIndex = 5;
            this.llRustyCode.TabStop = true;
            this.llRustyCode.Text = "vk.com/rustycode";
            this.llRustyCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRustyCode_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Оплата и приватные плагины на Rust";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripFile,
            this.menuStripSettings});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(407, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuStripFile
            // 
            this.menuStripFile.Name = "menuStripFile";
            this.menuStripFile.Size = new System.Drawing.Size(48, 20);
            this.menuStripFile.Text = "Файл";
            // 
            // menuStripSettings
            // 
            this.menuStripSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripSettingsJoinerPath});
            this.menuStripSettings.Name = "menuStripSettings";
            this.menuStripSettings.Size = new System.Drawing.Size(79, 20);
            this.menuStripSettings.Text = "Настройки";
            // 
            // menuStripSettingsJoinerPath
            // 
            this.menuStripSettingsJoinerPath.Name = "menuStripSettingsJoinerPath";
            this.menuStripSettingsJoinerPath.Size = new System.Drawing.Size(192, 22);
            this.menuStripSettingsJoinerPath.Text = "Указать путь до Joiner";
            this.menuStripSettingsJoinerPath.Click += new System.EventHandler(this.menuStripSettingsJoinerPath_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 454);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llRustyCode);
            this.Controls.Add(this.gbLicence);
            this.Controls.Add(this.gbServerList);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SteamFakePlayer by bazuka5801";
            this.gbServerList.ResumeLayout(false);
            this.gbLicence.ResumeLayout(false);
            this.gbLicence.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.GroupBox gbServerList;
        private System.Windows.Forms.GroupBox gbLicence;
        private System.Windows.Forms.Label lblLicenceStatus;
        private System.Windows.Forms.Label lblLicenceStatusCaption;
        private System.Windows.Forms.Button btnCopyKey;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button btnOpenServer;
        private System.Windows.Forms.LinkLabel llRustyCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteServer;
        private System.Windows.Forms.Button btnAddServer;
        private System.Windows.Forms.ListBox lbServers;
        private System.Windows.Forms.Label lblLicenceUsername;
        private System.Windows.Forms.Label lblLicenceUsernameCaption;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuStripFile;
        private System.Windows.Forms.ToolStripMenuItem menuStripSettings;
        private System.Windows.Forms.ToolStripMenuItem menuStripSettingsJoinerPath;
    }
}


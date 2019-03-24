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
            this.gbLicence = new System.Windows.Forms.GroupBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.btnCopyKey = new System.Windows.Forms.Button();
            this.lblLicenceStatusCaption = new System.Windows.Forms.Label();
            this.lblLicenceStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.llRustyCode = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbServers = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblLicenceUsernameCaption = new System.Windows.Forms.Label();
            this.lblLicenceUsername = new System.Windows.Forms.Label();
            this.gbServerList.SuspendLayout();
            this.gbLicence.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Location = new System.Drawing.Point(18, 12);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(375, 41);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Программа: SteamFakePlayer\r\nРазработчик: bazuka5801";
            // 
            // gbServerList
            // 
            this.gbServerList.Controls.Add(this.button3);
            this.gbServerList.Controls.Add(this.button2);
            this.gbServerList.Controls.Add(this.lbServers);
            this.gbServerList.Controls.Add(this.button1);
            this.gbServerList.Location = new System.Drawing.Point(12, 229);
            this.gbServerList.Name = "gbServerList";
            this.gbServerList.Size = new System.Drawing.Size(382, 213);
            this.gbServerList.TabIndex = 3;
            this.gbServerList.TabStop = false;
            this.gbServerList.Text = "Список серверов";
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
            // tbKey
            // 
            this.tbKey.Font = new System.Drawing.Font("Verdana", 9F);
            this.tbKey.Location = new System.Drawing.Point(42, 24);
            this.tbKey.Name = "tbKey";
            this.tbKey.ReadOnly = true;
            this.tbKey.Size = new System.Drawing.Size(277, 22);
            this.tbKey.TabIndex = 1;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Открыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // llRustyCode
            // 
            this.llRustyCode.AutoSize = true;
            this.llRustyCode.Location = new System.Drawing.Point(18, 80);
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
            this.label1.Location = new System.Drawing.Point(18, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Оплата и приватные плагины на Rust";
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(166, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(274, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 26);
            this.button3.TabIndex = 3;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
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
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "SteamFakePlayer by bazuka5801";
            this.gbServerList.ResumeLayout(false);
            this.gbLicence.ResumeLayout(false);
            this.gbLicence.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel llRustyCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lbServers;
        private System.Windows.Forms.Label lblLicenceUsername;
        private System.Windows.Forms.Label lblLicenceUsernameCaption;
    }
}


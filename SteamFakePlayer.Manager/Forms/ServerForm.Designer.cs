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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblActiveBots = new System.Windows.Forms.Label();
            this.lblActiveBotsCaption = new System.Windows.Forms.Label();
            this.btnOptions = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblActiveBots);
            this.groupBox1.Controls.Add(this.lblActiveBotsCaption);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 259);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Показатели";
            // 
            // lblActiveBots
            // 
            this.lblActiveBots.AutoSize = true;
            this.lblActiveBots.ForeColor = System.Drawing.Color.Green;
            this.lblActiveBots.Location = new System.Drawing.Point(164, 23);
            this.lblActiveBots.Name = "lblActiveBots";
            this.lblActiveBots.Size = new System.Drawing.Size(18, 18);
            this.lblActiveBots.TabIndex = 3;
            this.lblActiveBots.Text = "0";
            // 
            // lblActiveBotsCaption
            // 
            this.lblActiveBotsCaption.AutoSize = true;
            this.lblActiveBotsCaption.ForeColor = System.Drawing.Color.Green;
            this.lblActiveBotsCaption.Location = new System.Drawing.Point(6, 23);
            this.lblActiveBotsCaption.Name = "lblActiveBotsCaption";
            this.lblActiveBotsCaption.Size = new System.Drawing.Size(164, 18);
            this.lblActiveBotsCaption.TabIndex = 2;
            this.lblActiveBotsCaption.Text = "Ботов на сервере:";
            // 
            // btnOptions
            // 
            this.btnOptions.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOptions.Location = new System.Drawing.Point(12, 278);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(349, 36);
            this.btnOptions.TabIndex = 4;
            this.btnOptions.Text = "Настройки";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(367, 13);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(292, 301);
            this.tbLog.TabIndex = 6;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 330);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ServerForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblActiveBots;
        private System.Windows.Forms.Label lblActiveBotsCaption;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.TextBox tbLog;
    }
}
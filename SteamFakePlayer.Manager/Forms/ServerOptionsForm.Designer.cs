namespace SteamFakePlayer.Manager
{
    partial class ServerOptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerOptionsForm));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPort = new System.Windows.Forms.TableLayoutPanel();
            this.lblPort = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tlpIP = new System.Windows.Forms.TableLayoutPanel();
            this.lblIP = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.tlpPort.SuspendLayout();
            this.tlpIP.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpPort, 0, 1);
            this.tlpMain.Controls.Add(this.tlpIP, 0, 0);
            this.tlpMain.Controls.Add(this.tlpButtons, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(347, 128);
            this.tlpMain.TabIndex = 2;
            // 
            // tlpPort
            // 
            this.tlpPort.ColumnCount = 2;
            this.tlpPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.93162F));
            this.tlpPort.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.06837F));
            this.tlpPort.Controls.Add(this.lblPort, 0, 0);
            this.tlpPort.Controls.Add(this.tbPort, 1, 0);
            this.tlpPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPort.Location = new System.Drawing.Point(3, 43);
            this.tlpPort.Name = "tlpPort";
            this.tlpPort.RowCount = 1;
            this.tlpPort.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPort.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpPort.Size = new System.Drawing.Size(341, 34);
            this.tlpPort.TabIndex = 2;
            // 
            // lblPort
            // 
            this.lblPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPort.Location = new System.Drawing.Point(3, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(75, 34);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "PORT";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPort
            // 
            this.tbPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPort.Location = new System.Drawing.Point(84, 3);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(254, 27);
            this.tbPort.TabIndex = 1;
            // 
            // tlpIP
            // 
            this.tlpIP.ColumnCount = 2;
            this.tlpIP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.93162F));
            this.tlpIP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.06837F));
            this.tlpIP.Controls.Add(this.lblIP, 0, 0);
            this.tlpIP.Controls.Add(this.tbIP, 1, 0);
            this.tlpIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpIP.Location = new System.Drawing.Point(3, 3);
            this.tlpIP.Name = "tlpIP";
            this.tlpIP.RowCount = 1;
            this.tlpIP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpIP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpIP.Size = new System.Drawing.Size(341, 34);
            this.tlpIP.TabIndex = 1;
            // 
            // lblIP
            // 
            this.lblIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIP.Location = new System.Drawing.Point(3, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(75, 34);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbIP
            // 
            this.tbIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbIP.Location = new System.Drawing.Point(84, 3);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(254, 27);
            this.tbIP.TabIndex = 1;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 2;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Controls.Add(this.btnCancel, 1, 0);
            this.tlpButtons.Controls.Add(this.btnSave, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(0, 80);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpButtons.Size = new System.Drawing.Size(347, 48);
            this.tlpButtons.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(176, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(168, 42);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(167, 42);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ServerOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 128);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки сервера";
            this.tlpMain.ResumeLayout(false);
            this.tlpPort.ResumeLayout(false);
            this.tlpPort.PerformLayout();
            this.tlpIP.ResumeLayout(false);
            this.tlpIP.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TableLayoutPanel tlpIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}
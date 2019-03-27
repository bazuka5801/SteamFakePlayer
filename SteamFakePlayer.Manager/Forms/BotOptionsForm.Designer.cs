namespace SteamFakePlayer.Manager
{
    partial class BotOptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BotOptionsForm));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpExit = new System.Windows.Forms.TableLayoutPanel();
            this.tbExitMin = new System.Windows.Forms.TextBox();
            this.lblExit = new System.Windows.Forms.Label();
            this.tbExitMax = new System.Windows.Forms.TextBox();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpEnter = new System.Windows.Forms.TableLayoutPanel();
            this.tbEnterMin = new System.Windows.Forms.TextBox();
            this.lblEnter = new System.Windows.Forms.Label();
            this.tbEnterMax = new System.Windows.Forms.TextBox();
            this.lblHelp = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.tlpExit.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tlpEnter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpExit, 0, 2);
            this.tlpMain.Controls.Add(this.tlpButtons, 0, 3);
            this.tlpMain.Controls.Add(this.tlpEnter, 0, 1);
            this.tlpMain.Controls.Add(this.lblHelp, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(513, 173);
            this.tlpMain.TabIndex = 3;
            // 
            // tlpExit
            // 
            this.tlpExit.ColumnCount = 3;
            this.tlpExit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpExit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpExit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpExit.Controls.Add(this.tbExitMin, 0, 0);
            this.tlpExit.Controls.Add(this.lblExit, 0, 0);
            this.tlpExit.Controls.Add(this.tbExitMax, 1, 0);
            this.tlpExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpExit.Location = new System.Drawing.Point(0, 94);
            this.tlpExit.Margin = new System.Windows.Forms.Padding(0);
            this.tlpExit.Name = "tlpExit";
            this.tlpExit.RowCount = 1;
            this.tlpExit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpExit.Size = new System.Drawing.Size(513, 34);
            this.tlpExit.TabIndex = 5;
            // 
            // tbExitMin
            // 
            this.tbExitMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbExitMin.Location = new System.Drawing.Point(83, 3);
            this.tbExitMin.Name = "tbExitMin";
            this.tbExitMin.Size = new System.Drawing.Size(210, 27);
            this.tbExitMin.TabIndex = 2;
            // 
            // lblExit
            // 
            this.lblExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExit.Location = new System.Drawing.Point(3, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(74, 34);
            this.lblExit.TabIndex = 0;
            this.lblExit.Text = "ВЫХОД";
            this.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbExitMax
            // 
            this.tbExitMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbExitMax.Location = new System.Drawing.Point(299, 3);
            this.tbExitMax.Name = "tbExitMax";
            this.tbExitMax.Size = new System.Drawing.Size(211, 27);
            this.tbExitMax.TabIndex = 1;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 2;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Controls.Add(this.btnCancel, 1, 0);
            this.tlpButtons.Controls.Add(this.btnSave, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(0, 128);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpButtons.Size = new System.Drawing.Size(513, 45);
            this.tlpButtons.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(259, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(251, 39);
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
            this.btnSave.Size = new System.Drawing.Size(250, 39);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tlpEnter
            // 
            this.tlpEnter.ColumnCount = 3;
            this.tlpEnter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpEnter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEnter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEnter.Controls.Add(this.tbEnterMin, 0, 0);
            this.tlpEnter.Controls.Add(this.lblEnter, 0, 0);
            this.tlpEnter.Controls.Add(this.tbEnterMax, 1, 0);
            this.tlpEnter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEnter.Location = new System.Drawing.Point(0, 60);
            this.tlpEnter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEnter.Name = "tlpEnter";
            this.tlpEnter.RowCount = 1;
            this.tlpEnter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEnter.Size = new System.Drawing.Size(513, 34);
            this.tlpEnter.TabIndex = 1;
            // 
            // tbEnterMin
            // 
            this.tbEnterMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEnterMin.Location = new System.Drawing.Point(83, 3);
            this.tbEnterMin.Name = "tbEnterMin";
            this.tbEnterMin.Size = new System.Drawing.Size(210, 27);
            this.tbEnterMin.TabIndex = 2;
            // 
            // lblEnter
            // 
            this.lblEnter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnter.Location = new System.Drawing.Point(3, 0);
            this.lblEnter.Name = "lblEnter";
            this.lblEnter.Size = new System.Drawing.Size(74, 34);
            this.lblEnter.TabIndex = 0;
            this.lblEnter.Text = "ВХОД";
            this.lblEnter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbEntetMax
            // 
            this.tbEnterMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEnterMax.Location = new System.Drawing.Point(299, 3);
            this.tbEnterMax.Name = "tbEntetMax";
            this.tbEnterMax.Size = new System.Drawing.Size(211, 27);
            this.tbEnterMax.TabIndex = 1;
            // 
            // lblHelp
            // 
            this.lblHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHelp.Location = new System.Drawing.Point(3, 0);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(507, 60);
            this.lblHelp.TabIndex = 4;
            this.lblHelp.Text = "Все значения устанавливаются в секундах\r\nЕсли 2 поля, то это минимум и максимум.";
            this.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BotOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 173);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BotOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки бота";
            this.tlpMain.ResumeLayout(false);
            this.tlpExit.ResumeLayout(false);
            this.tlpExit.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.tlpEnter.ResumeLayout(false);
            this.tlpEnter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpExit;
        private System.Windows.Forms.TextBox tbExitMin;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.TextBox tbExitMax;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpEnter;
        private System.Windows.Forms.TextBox tbEnterMin;
        private System.Windows.Forms.Label lblEnter;
        private System.Windows.Forms.TextBox tbEnterMax;
        private System.Windows.Forms.Label lblHelp;
    }
}
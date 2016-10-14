namespace craftersmine.LiteScript.Ide.PluginManager
{
    partial class Install
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
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.tip = new System.Windows.Forms.Label();
            this.plugin_name = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.license = new System.Windows.Forms.Panel();
            this.acceptAgreement = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.license.SuspendLayout();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok.Location = new System.Drawing.Point(310, 371);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(128, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "{ok}";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancel
            // 
            this.cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel.Location = new System.Drawing.Point(194, 371);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(110, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "{cancel}";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // tip
            // 
            this.tip.Location = new System.Drawing.Point(12, 9);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(426, 35);
            this.tip.TabIndex = 2;
            this.tip.Text = "{tip}";
            // 
            // plugin_name
            // 
            this.plugin_name.AutoSize = true;
            this.plugin_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plugin_name.Location = new System.Drawing.Point(12, 44);
            this.plugin_name.Name = "plugin_name";
            this.plugin_name.Size = new System.Drawing.Size(88, 13);
            this.plugin_name.TabIndex = 3;
            this.plugin_name.Text = "{plugin_name}";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(12, 273);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(43, 13);
            this.status.TabIndex = 4;
            this.status.Text = "{status}";
            this.status.Visible = false;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 289);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(426, 23);
            this.progress.TabIndex = 5;
            this.progress.Visible = false;
            // 
            // license
            // 
            this.license.Controls.Add(this.acceptAgreement);
            this.license.Controls.Add(this.richTextBox1);
            this.license.Location = new System.Drawing.Point(12, 60);
            this.license.Name = "license";
            this.license.Size = new System.Drawing.Size(426, 305);
            this.license.TabIndex = 6;
            this.license.Visible = false;
            // 
            // acceptAgreement
            // 
            this.acceptAgreement.AutoSize = true;
            this.acceptAgreement.Location = new System.Drawing.Point(3, 285);
            this.acceptAgreement.Name = "acceptAgreement";
            this.acceptAgreement.Size = new System.Drawing.Size(155, 17);
            this.acceptAgreement.TabIndex = 1;
            this.acceptAgreement.Text = "{acceptLicenseAgreement}";
            this.acceptAgreement.UseVisualStyleBackColor = true;
            this.acceptAgreement.CheckedChanged += new System.EventHandler(this.acceptAgreement_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(420, 277);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Install
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 406);
            this.Controls.Add(this.license);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.status);
            this.Controls.Add(this.plugin_name);
            this.Controls.Add(this.tip);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Install";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Install_FormClosing);
            this.license.ResumeLayout(false);
            this.license.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label tip;
        private System.Windows.Forms.Label plugin_name;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Panel license;
        private System.Windows.Forms.CheckBox acceptAgreement;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}


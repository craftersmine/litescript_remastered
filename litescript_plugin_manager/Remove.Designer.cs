namespace craftersmine.LiteScript.Ide.PluginManager
{
    partial class Remove
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Remove));
            this.progress = new System.Windows.Forms.ProgressBar();
            this.status = new System.Windows.Forms.Label();
            this.plugin_name = new System.Windows.Forms.Label();
            this.tip = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 289);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(426, 23);
            this.progress.TabIndex = 11;
            this.progress.Visible = false;
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(12, 273);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(426, 13);
            this.status.TabIndex = 10;
            this.status.Text = "{status}";
            this.status.Visible = false;
            // 
            // plugin_name
            // 
            this.plugin_name.AutoSize = true;
            this.plugin_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plugin_name.Location = new System.Drawing.Point(12, 44);
            this.plugin_name.Name = "plugin_name";
            this.plugin_name.Size = new System.Drawing.Size(88, 13);
            this.plugin_name.TabIndex = 9;
            this.plugin_name.Text = "{plugin_name}";
            // 
            // tip
            // 
            this.tip.Location = new System.Drawing.Point(12, 9);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(426, 35);
            this.tip.TabIndex = 8;
            this.tip.Text = "{tip}";
            // 
            // cancel
            // 
            this.cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel.Location = new System.Drawing.Point(194, 371);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(110, 23);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "{cancel}";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ok
            // 
            this.ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok.Location = new System.Drawing.Point(310, 371);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(128, 23);
            this.ok.TabIndex = 6;
            this.ok.Text = "{ok}";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // Remove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 406);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.status);
            this.Controls.Add(this.plugin_name);
            this.Controls.Add(this.tip);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Remove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LiteScript Plugin Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Remove_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label plugin_name;
        private System.Windows.Forms.Label tip;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
    }
}


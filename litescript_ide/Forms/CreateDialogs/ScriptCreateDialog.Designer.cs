namespace craftersmine.LiteScript.Ide.Forms.CreateDialogs
{
    partial class ScriptCreateDialog
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
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.projnameBox = new System.Windows.Forms.TextBox();
            this.projnameTip = new System.Windows.Forms.Label();
            this.browse = new System.Windows.Forms.Button();
            this.directoryPath = new System.Windows.Forms.TextBox();
            this.dirTip = new System.Windows.Forms.Label();
            this.tip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(311, 209);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 17;
            this.cancel.Text = "{cancel}";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(392, 209);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(170, 23);
            this.ok.TabIndex = 16;
            this.ok.Text = "{create}";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // projnameBox
            // 
            this.projnameBox.Location = new System.Drawing.Point(99, 79);
            this.projnameBox.Name = "projnameBox";
            this.projnameBox.Size = new System.Drawing.Size(463, 20);
            this.projnameBox.TabIndex = 14;
            this.projnameBox.Text = "{unnamed}";
            // 
            // projnameTip
            // 
            this.projnameTip.AutoSize = true;
            this.projnameTip.Location = new System.Drawing.Point(12, 82);
            this.projnameTip.Name = "projnameTip";
            this.projnameTip.Size = new System.Drawing.Size(68, 13);
            this.projnameTip.TabIndex = 13;
            this.projnameTip.Text = "{scriptName}";
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(487, 42);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 12;
            this.browse.Text = "{browse}";
            this.browse.UseVisualStyleBackColor = true;
            // 
            // directoryPath
            // 
            this.directoryPath.Location = new System.Drawing.Point(99, 44);
            this.directoryPath.Name = "directoryPath";
            this.directoryPath.Size = new System.Drawing.Size(380, 20);
            this.directoryPath.TabIndex = 11;
            // 
            // dirTip
            // 
            this.dirTip.AutoSize = true;
            this.dirTip.Location = new System.Drawing.Point(12, 47);
            this.dirTip.Name = "dirTip";
            this.dirTip.Size = new System.Drawing.Size(55, 13);
            this.dirTip.TabIndex = 10;
            this.dirTip.Text = "{directory}";
            // 
            // tip
            // 
            this.tip.AutoSize = true;
            this.tip.Location = new System.Drawing.Point(12, 9);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(94, 13);
            this.tip.TabIndex = 9;
            this.tip.Text = "{scriptCreationTip}";
            // 
            // ScriptCreateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 241);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.projnameBox);
            this.Controls.Add(this.projnameTip);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.directoryPath);
            this.Controls.Add(this.dirTip);
            this.Controls.Add(this.tip);
            this.Name = "ScriptCreateDialog";
            this.Text = "ScriptCreateDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.TextBox projnameBox;
        private System.Windows.Forms.Label projnameTip;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox directoryPath;
        private System.Windows.Forms.Label dirTip;
        private System.Windows.Forms.Label tip;
    }
}
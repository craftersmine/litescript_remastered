namespace craftersmine.LiteScript.Ide.Forms.CreateDialogs
{
    partial class ProjectCreateDialog
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
            this.tip = new System.Windows.Forms.Label();
            this.dirTip = new System.Windows.Forms.Label();
            this.directoryPath = new System.Windows.Forms.TextBox();
            this.browse = new System.Windows.Forms.Button();
            this.projnameBox = new System.Windows.Forms.TextBox();
            this.projnameTip = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tip
            // 
            this.tip.Location = new System.Drawing.Point(12, 9);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(550, 40);
            this.tip.TabIndex = 0;
            this.tip.Text = "{projCreationTip}";
            // 
            // dirTip
            // 
            this.dirTip.AutoSize = true;
            this.dirTip.Location = new System.Drawing.Point(12, 57);
            this.dirTip.Name = "dirTip";
            this.dirTip.Size = new System.Drawing.Size(55, 13);
            this.dirTip.TabIndex = 1;
            this.dirTip.Text = "{directory}";
            // 
            // directoryPath
            // 
            this.directoryPath.Location = new System.Drawing.Point(99, 54);
            this.directoryPath.Name = "directoryPath";
            this.directoryPath.Size = new System.Drawing.Size(342, 20);
            this.directoryPath.TabIndex = 2;
            // 
            // browse
            // 
            this.browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browse.Location = new System.Drawing.Point(447, 52);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(115, 23);
            this.browse.TabIndex = 3;
            this.browse.Text = "{browse}";
            this.browse.UseVisualStyleBackColor = true;
            // 
            // projnameBox
            // 
            this.projnameBox.Location = new System.Drawing.Point(99, 89);
            this.projnameBox.Name = "projnameBox";
            this.projnameBox.Size = new System.Drawing.Size(463, 20);
            this.projnameBox.TabIndex = 5;
            this.projnameBox.Text = "{unnamed}";
            // 
            // projnameTip
            // 
            this.projnameTip.AutoSize = true;
            this.projnameTip.Location = new System.Drawing.Point(12, 92);
            this.projnameTip.Name = "projnameTip";
            this.projnameTip.Size = new System.Drawing.Size(75, 13);
            this.projnameTip.TabIndex = 4;
            this.projnameTip.Text = "{projectName}";
            // 
            // ok
            // 
            this.ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok.Location = new System.Drawing.Point(392, 209);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(170, 23);
            this.ok.TabIndex = 7;
            this.ok.Text = "{create}";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel.Location = new System.Drawing.Point(278, 209);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(108, 23);
            this.cancel.TabIndex = 8;
            this.cancel.Text = "{cancel}";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ProjectCreateDialog
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(574, 244);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.projnameBox);
            this.Controls.Add(this.projnameTip);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.directoryPath);
            this.Controls.Add(this.dirTip);
            this.Controls.Add(this.tip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectCreateDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProjectCreateDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tip;
        private System.Windows.Forms.Label dirTip;
        private System.Windows.Forms.TextBox directoryPath;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox projnameBox;
        private System.Windows.Forms.Label projnameTip;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}
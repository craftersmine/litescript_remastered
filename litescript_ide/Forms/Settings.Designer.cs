namespace craftersmine.LiteScript.Ide.Forms
{
    partial class Settings
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
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.langtip = new System.Windows.Forms.Label();
            this.langs = new System.Windows.Forms.ComboBox();
            this.iconsettip = new System.Windows.Forms.Label();
            this.iconsets = new System.Windows.Forms.ComboBox();
            this.downloadmore = new System.Windows.Forms.LinkLabel();
            this.projectsDirtip = new System.Windows.Forms.Label();
            this.directory = new System.Windows.Forms.TextBox();
            this.browse = new System.Windows.Forms.Button();
            this.restarttip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok.Location = new System.Drawing.Point(385, 338);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(168, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "{ok}";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel.Location = new System.Drawing.Point(271, 338);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(108, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "{cancel}";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // langtip
            // 
            this.langtip.AutoSize = true;
            this.langtip.Location = new System.Drawing.Point(12, 26);
            this.langtip.Name = "langtip";
            this.langtip.Size = new System.Drawing.Size(59, 13);
            this.langtip.TabIndex = 2;
            this.langtip.Text = "{language}";
            // 
            // langs
            // 
            this.langs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.langs.FormattingEnabled = true;
            this.langs.Location = new System.Drawing.Point(175, 23);
            this.langs.Name = "langs";
            this.langs.Size = new System.Drawing.Size(220, 21);
            this.langs.TabIndex = 3;
            // 
            // iconsettip
            // 
            this.iconsettip.AutoSize = true;
            this.iconsettip.Location = new System.Drawing.Point(12, 59);
            this.iconsettip.Name = "iconsettip";
            this.iconsettip.Size = new System.Drawing.Size(49, 13);
            this.iconsettip.TabIndex = 4;
            this.iconsettip.Text = "{iconset}";
            // 
            // iconsets
            // 
            this.iconsets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iconsets.FormattingEnabled = true;
            this.iconsets.Location = new System.Drawing.Point(175, 56);
            this.iconsets.Name = "iconsets";
            this.iconsets.Size = new System.Drawing.Size(220, 21);
            this.iconsets.TabIndex = 5;
            // 
            // downloadmore
            // 
            this.downloadmore.ActiveLinkColor = System.Drawing.Color.CornflowerBlue;
            this.downloadmore.LinkColor = System.Drawing.Color.RoyalBlue;
            this.downloadmore.Location = new System.Drawing.Point(401, 40);
            this.downloadmore.Name = "downloadmore";
            this.downloadmore.Size = new System.Drawing.Size(150, 23);
            this.downloadmore.TabIndex = 6;
            this.downloadmore.TabStop = true;
            this.downloadmore.Text = "{downloadmore}";
            this.downloadmore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.downloadmore.VisitedLinkColor = System.Drawing.Color.RoyalBlue;
            this.downloadmore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.downloadmore_LinkClicked);
            // 
            // projectsDirtip
            // 
            this.projectsDirtip.AutoSize = true;
            this.projectsDirtip.Location = new System.Drawing.Point(12, 94);
            this.projectsDirtip.Name = "projectsDirtip";
            this.projectsDirtip.Size = new System.Drawing.Size(65, 13);
            this.projectsDirtip.TabIndex = 7;
            this.projectsDirtip.Text = "{projectsDir}";
            // 
            // directory
            // 
            this.directory.Location = new System.Drawing.Point(175, 91);
            this.directory.Name = "directory";
            this.directory.Size = new System.Drawing.Size(261, 20);
            this.directory.TabIndex = 8;
            // 
            // browse
            // 
            this.browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browse.Location = new System.Drawing.Point(442, 89);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(111, 23);
            this.browse.TabIndex = 9;
            this.browse.Text = "{browse}";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // restarttip
            // 
            this.restarttip.AutoSize = true;
            this.restarttip.Location = new System.Drawing.Point(12, 319);
            this.restarttip.Name = "restarttip";
            this.restarttip.Size = new System.Drawing.Size(55, 13);
            this.restarttip.TabIndex = 10;
            this.restarttip.Text = "{restarttip}";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 373);
            this.Controls.Add(this.restarttip);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.directory);
            this.Controls.Add(this.projectsDirtip);
            this.Controls.Add(this.downloadmore);
            this.Controls.Add(this.iconsets);
            this.Controls.Add(this.iconsettip);
            this.Controls.Add(this.langs);
            this.Controls.Add(this.langtip);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label langtip;
        private System.Windows.Forms.ComboBox langs;
        private System.Windows.Forms.Label iconsettip;
        private System.Windows.Forms.ComboBox iconsets;
        private System.Windows.Forms.LinkLabel downloadmore;
        private System.Windows.Forms.Label projectsDirtip;
        private System.Windows.Forms.TextBox directory;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Label restarttip;
    }
}
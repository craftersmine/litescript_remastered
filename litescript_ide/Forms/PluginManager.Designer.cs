namespace craftersmine.LiteScript.Ide.Forms
{
    partial class PluginManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginManager));
            this.tip = new System.Windows.Forms.Label();
            this.list = new System.Windows.Forms.ListView();
            this.icn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ver = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.selplgtip = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.descval = new System.Windows.Forms.Label();
            this.desctip = new System.Windows.Forms.Label();
            this.siteval = new System.Windows.Forms.LinkLabel();
            this.sitetip = new System.Windows.Forms.Label();
            this.versionval = new System.Windows.Forms.Label();
            this.versiontip = new System.Windows.Forms.Label();
            this.authorval = new System.Windows.Forms.Label();
            this.authortip = new System.Windows.Forms.Label();
            this.nameval = new System.Windows.Forms.Label();
            this.nametip = new System.Windows.Forms.Label();
            this.checkupdates = new System.Windows.Forms.Button();
            this.deleteplg = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tip
            // 
            this.tip.AutoSize = true;
            this.tip.Location = new System.Drawing.Point(12, 9);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(26, 13);
            this.tip.TabIndex = 0;
            this.tip.Text = "{tip}";
            // 
            // list
            // 
            this.list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.icn,
            this.name,
            this.ver});
            this.list.FullRowSelect = true;
            this.list.Location = new System.Drawing.Point(12, 35);
            this.list.MultiSelect = false;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(305, 452);
            this.list.SmallImageList = this.imageList1;
            this.list.TabIndex = 1;
            this.list.UseCompatibleStateImageBehavior = false;
            this.list.View = System.Windows.Forms.View.Details;
            this.list.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.list_ItemSelectionChanged);
            // 
            // icn
            // 
            this.icn.Text = "";
            this.icn.Width = 24;
            // 
            // name
            // 
            this.name.Text = "{name}";
            this.name.Width = 219;
            // 
            // ver
            // 
            this.ver.Text = "{version}";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "notloaded");
            this.imageList1.Images.SetKeyName(1, "loaded");
            // 
            // selplgtip
            // 
            this.selplgtip.Location = new System.Drawing.Point(323, 225);
            this.selplgtip.Name = "selplgtip";
            this.selplgtip.Size = new System.Drawing.Size(437, 61);
            this.selplgtip.TabIndex = 2;
            this.selplgtip.Text = "{selectplugintip}";
            this.selplgtip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.descval);
            this.panel1.Controls.Add(this.desctip);
            this.panel1.Controls.Add(this.siteval);
            this.panel1.Controls.Add(this.sitetip);
            this.panel1.Controls.Add(this.versionval);
            this.panel1.Controls.Add(this.versiontip);
            this.panel1.Controls.Add(this.authorval);
            this.panel1.Controls.Add(this.authortip);
            this.panel1.Controls.Add(this.nameval);
            this.panel1.Controls.Add(this.nametip);
            this.panel1.Controls.Add(this.checkupdates);
            this.panel1.Controls.Add(this.deleteplg);
            this.panel1.Location = new System.Drawing.Point(323, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 452);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // descval
            // 
            this.descval.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.descval.Location = new System.Drawing.Point(122, 126);
            this.descval.Name = "descval";
            this.descval.Size = new System.Drawing.Size(313, 297);
            this.descval.TabIndex = 11;
            // 
            // desctip
            // 
            this.desctip.AutoSize = true;
            this.desctip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.desctip.Location = new System.Drawing.Point(15, 126);
            this.desctip.Name = "desctip";
            this.desctip.Size = new System.Drawing.Size(81, 17);
            this.desctip.TabIndex = 10;
            this.desctip.Text = "{description}";
            // 
            // siteval
            // 
            this.siteval.ActiveLinkColor = System.Drawing.Color.LightSkyBlue;
            this.siteval.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.siteval.LinkColor = System.Drawing.Color.RoyalBlue;
            this.siteval.Location = new System.Drawing.Point(122, 99);
            this.siteval.Name = "siteval";
            this.siteval.Size = new System.Drawing.Size(313, 17);
            this.siteval.TabIndex = 9;
            this.siteval.VisitedLinkColor = System.Drawing.Color.RoyalBlue;
            this.siteval.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.siteval_LinkClicked);
            // 
            // sitetip
            // 
            this.sitetip.AutoSize = true;
            this.sitetip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sitetip.Location = new System.Drawing.Point(15, 99);
            this.sitetip.Name = "sitetip";
            this.sitetip.Size = new System.Drawing.Size(36, 17);
            this.sitetip.TabIndex = 8;
            this.sitetip.Text = "{site}";
            // 
            // versionval
            // 
            this.versionval.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.versionval.Location = new System.Drawing.Point(122, 70);
            this.versionval.Name = "versionval";
            this.versionval.Size = new System.Drawing.Size(313, 17);
            this.versionval.TabIndex = 7;
            // 
            // versiontip
            // 
            this.versiontip.AutoSize = true;
            this.versiontip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.versiontip.Location = new System.Drawing.Point(15, 70);
            this.versiontip.Name = "versiontip";
            this.versiontip.Size = new System.Drawing.Size(58, 17);
            this.versiontip.TabIndex = 6;
            this.versiontip.Text = "{version}";
            // 
            // authorval
            // 
            this.authorval.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.authorval.Location = new System.Drawing.Point(122, 42);
            this.authorval.Name = "authorval";
            this.authorval.Size = new System.Drawing.Size(313, 17);
            this.authorval.TabIndex = 5;
            // 
            // authortip
            // 
            this.authortip.AutoSize = true;
            this.authortip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authortip.Location = new System.Drawing.Point(15, 42);
            this.authortip.Name = "authortip";
            this.authortip.Size = new System.Drawing.Size(54, 17);
            this.authortip.TabIndex = 4;
            this.authortip.Text = "{author}";
            // 
            // nameval
            // 
            this.nameval.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.nameval.Location = new System.Drawing.Point(122, 13);
            this.nameval.Name = "nameval";
            this.nameval.Size = new System.Drawing.Size(313, 17);
            this.nameval.TabIndex = 3;
            // 
            // nametip
            // 
            this.nametip.AutoSize = true;
            this.nametip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nametip.Location = new System.Drawing.Point(15, 13);
            this.nametip.Name = "nametip";
            this.nametip.Size = new System.Drawing.Size(48, 17);
            this.nametip.TabIndex = 2;
            this.nametip.Text = "{name}";
            // 
            // checkupdates
            // 
            this.checkupdates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkupdates.Location = new System.Drawing.Point(171, 426);
            this.checkupdates.Name = "checkupdates";
            this.checkupdates.Size = new System.Drawing.Size(264, 23);
            this.checkupdates.TabIndex = 1;
            this.checkupdates.Text = "{checkupdates}";
            this.checkupdates.UseVisualStyleBackColor = true;
            // 
            // deleteplg
            // 
            this.deleteplg.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteplg.Location = new System.Drawing.Point(3, 426);
            this.deleteplg.Name = "deleteplg";
            this.deleteplg.Size = new System.Drawing.Size(162, 23);
            this.deleteplg.TabIndex = 0;
            this.deleteplg.Text = "{delete}";
            this.deleteplg.UseVisualStyleBackColor = true;
            this.deleteplg.Click += new System.EventHandler(this.deleteplg_Click);
            // 
            // PluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 498);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.selplgtip);
            this.Controls.Add(this.list);
            this.Controls.Add(this.tip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PluginManager";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tip;
        private System.Windows.Forms.ListView list;
        private System.Windows.Forms.ColumnHeader icn;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader ver;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label selplgtip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label descval;
        private System.Windows.Forms.Label desctip;
        private System.Windows.Forms.LinkLabel siteval;
        private System.Windows.Forms.Label sitetip;
        private System.Windows.Forms.Label versionval;
        private System.Windows.Forms.Label versiontip;
        private System.Windows.Forms.Label authorval;
        private System.Windows.Forms.Label authortip;
        private System.Windows.Forms.Label nameval;
        private System.Windows.Forms.Label nametip;
        private System.Windows.Forms.Button checkupdates;
        private System.Windows.Forms.Button deleteplg;
    }
}
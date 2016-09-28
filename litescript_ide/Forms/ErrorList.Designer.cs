namespace craftersmine.LiteScript.Ide.Forms
{
    partial class ErrorList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorList));
            this.tip = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.icn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tip
            // 
            this.tip.AutoSize = true;
            this.tip.Location = new System.Drawing.Point(12, 9);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(116, 13);
            this.tip.TabIndex = 0;
            this.tip.Text = "{errors_and_warns_tip}";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(624, 262);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(214, 23);
            this.ok.TabIndex = 1;
            this.ok.Text = "{ok}";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.icn,
            this.errid,
            this.description});
            this.listView1.Location = new System.Drawing.Point(12, 30);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(826, 226);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // icn
            // 
            this.icn.Text = "";
            this.icn.Width = 25;
            // 
            // errid
            // 
            this.errid.Text = "{id}";
            // 
            // description
            // 
            this.description.Text = "{description}";
            this.description.Width = 737;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "error");
            this.imageList1.Images.SetKeyName(1, "warning");
            // 
            // ErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 297);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.tip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ErrorList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ErrorList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tip;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader icn;
        private System.Windows.Forms.ColumnHeader errid;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.ImageList imageList1;
    }
}
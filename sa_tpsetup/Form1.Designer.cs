namespace sa_tpsetup
{
    partial class Form1
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
            this.label_sapath = new System.Windows.Forms.Label();
            this.data_sapath = new System.Windows.Forms.TextBox();
            this.bt_palbg = new System.Windows.Forms.Button();
            this.label_palbg = new System.Windows.Forms.Label();
            this.label_palfon = new System.Windows.Forms.Label();
            this.bt_palfon = new System.Windows.Forms.Button();
            this.bt_scan = new System.Windows.Forms.Button();
            this.label_progdat = new System.Windows.Forms.Label();
            this.bt_browse = new System.Windows.Forms.Button();
            this.cdialog = new System.Windows.Forms.ColorDialog();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label_sapath
            // 
            this.label_sapath.AutoSize = true;
            this.label_sapath.Location = new System.Drawing.Point(12, 9);
            this.label_sapath.Name = "label_sapath";
            this.label_sapath.Size = new System.Drawing.Size(0, 13);
            this.label_sapath.TabIndex = 0;
            // 
            // data_sapath
            // 
            this.data_sapath.Location = new System.Drawing.Point(12, 25);
            this.data_sapath.Name = "data_sapath";
            this.data_sapath.ReadOnly = true;
            this.data_sapath.Size = new System.Drawing.Size(300, 20);
            this.data_sapath.TabIndex = 1;
            // 
            // bt_palbg
            // 
            this.bt_palbg.Location = new System.Drawing.Point(178, 124);
            this.bt_palbg.Name = "bt_palbg";
            this.bt_palbg.Size = new System.Drawing.Size(82, 24);
            this.bt_palbg.TabIndex = 3;
            this.bt_palbg.UseVisualStyleBackColor = true;
            this.bt_palbg.Click += new System.EventHandler(this.bt_palbg_Click);
            // 
            // label_palbg
            // 
            this.label_palbg.AutoSize = true;
            this.label_palbg.Location = new System.Drawing.Point(12, 130);
            this.label_palbg.Name = "label_palbg";
            this.label_palbg.Size = new System.Drawing.Size(0, 13);
            this.label_palbg.TabIndex = 4;
            // 
            // label_palfon
            // 
            this.label_palfon.AutoSize = true;
            this.label_palfon.Location = new System.Drawing.Point(12, 167);
            this.label_palfon.Name = "label_palfon";
            this.label_palfon.Size = new System.Drawing.Size(0, 13);
            this.label_palfon.TabIndex = 4;
            // 
            // bt_palfon
            // 
            this.bt_palfon.Location = new System.Drawing.Point(178, 161);
            this.bt_palfon.Name = "bt_palfon";
            this.bt_palfon.Size = new System.Drawing.Size(82, 24);
            this.bt_palfon.TabIndex = 3;
            this.bt_palfon.UseVisualStyleBackColor = true;
            this.bt_palfon.Click += new System.EventHandler(this.bt_palfon_Click);
            // 
            // bt_scan
            // 
            this.bt_scan.Location = new System.Drawing.Point(100, 51);
            this.bt_scan.Name = "bt_scan";
            this.bt_scan.Size = new System.Drawing.Size(100, 24);
            this.bt_scan.TabIndex = 3;
            this.bt_scan.UseVisualStyleBackColor = true;
            this.bt_scan.Click += new System.EventHandler(this.bt_scan_Click);
            // 
            // label_progdat
            // 
            this.label_progdat.AutoSize = true;
            this.label_progdat.Location = new System.Drawing.Point(12, 94);
            this.label_progdat.Name = "label_progdat";
            this.label_progdat.Size = new System.Drawing.Size(0, 13);
            this.label_progdat.TabIndex = 2;
            // 
            // bt_browse
            // 
            this.bt_browse.Location = new System.Drawing.Point(12, 51);
            this.bt_browse.Name = "bt_browse";
            this.bt_browse.Size = new System.Drawing.Size(82, 24);
            this.bt_browse.TabIndex = 3;
            this.bt_browse.UseVisualStyleBackColor = true;
            this.bt_browse.Click += new System.EventHandler(this.bt_browse_Click);
            // 
            // cdialog
            // 
            this.cdialog.Color = System.Drawing.SystemColors.Control;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 192);
            this.Controls.Add(this.label_palfon);
            this.Controls.Add(this.label_palbg);
            this.Controls.Add(this.bt_browse);
            this.Controls.Add(this.bt_scan);
            this.Controls.Add(this.bt_palfon);
            this.Controls.Add(this.bt_palbg);
            this.Controls.Add(this.label_progdat);
            this.Controls.Add(this.data_sapath);
            this.Controls.Add(this.label_sapath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SA Toolpack: Setup";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_sapath;
        private System.Windows.Forms.TextBox data_sapath;
        private System.Windows.Forms.Button bt_palbg;
        private System.Windows.Forms.Label label_palbg;
        private System.Windows.Forms.Label label_palfon;
        private System.Windows.Forms.Button bt_palfon;
        private System.Windows.Forms.Button bt_scan;
        private System.Windows.Forms.Label label_progdat;
        private System.Windows.Forms.Button bt_browse;
        private System.Windows.Forms.ColorDialog cdialog;
        private System.Windows.Forms.FolderBrowserDialog fbd;

    }
}


namespace carcolsedit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.data_color = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.data_clist = new System.Windows.Forms.ComboBox();
            this.bt_changecol = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_about = new System.Windows.Forms.Button();
            this.pre1_1 = new System.Windows.Forms.Panel();
            this.pre2_1 = new System.Windows.Forms.Panel();
            this.pre2_2 = new System.Windows.Forms.Panel();
            this.cdd = new System.Windows.Forms.ColorDialog();
            this.bt_addcol = new System.Windows.Forms.Button();
            this.data_carcol1 = new System.Windows.Forms.NumericUpDown();
            this.data_carcol2 = new System.Windows.Forms.NumericUpDown();
            this.bt_delcol = new System.Windows.Forms.Button();
            this.data_vcollist = new System.Windows.Forms.ListBox();
            this.data_car = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ch_clist = new System.Windows.Forms.CheckBox();
            this.ch_carcol = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_carcol1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_carcol2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 1;
            // 
            // data_color
            // 
            this.data_color.AutoSize = true;
            this.data_color.Location = new System.Drawing.Point(65, 65);
            this.data_color.Name = "data_color";
            this.data_color.Size = new System.Drawing.Size(31, 13);
            this.data_color.TabIndex = 2;
            this.data_color.Text = "0,0,0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 2;
            // 
            // data_clist
            // 
            this.data_clist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.data_clist.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.data_clist.FormattingEnabled = true;
            this.data_clist.Location = new System.Drawing.Point(65, 6);
            this.data_clist.Name = "data_clist";
            this.data_clist.Size = new System.Drawing.Size(194, 20);
            this.data_clist.TabIndex = 3;
            this.data_clist.SelectedIndexChanged += new System.EventHandler(this.data_clist_SelectedIndexChanged);
            // 
            // bt_changecol
            // 
            this.bt_changecol.Location = new System.Drawing.Point(12, 81);
            this.bt_changecol.Name = "bt_changecol";
            this.bt_changecol.Size = new System.Drawing.Size(84, 24);
            this.bt_changecol.TabIndex = 4;
            this.bt_changecol.UseVisualStyleBackColor = true;
            this.bt_changecol.Click += new System.EventHandler(this.bt_changecol_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(12, 206);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(256, 24);
            this.bt_save.TabIndex = 5;
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_about
            // 
            this.bt_about.Location = new System.Drawing.Point(274, 206);
            this.bt_about.Name = "bt_about";
            this.bt_about.Size = new System.Drawing.Size(256, 24);
            this.bt_about.TabIndex = 5;
            this.bt_about.UseVisualStyleBackColor = true;
            this.bt_about.Click += new System.EventHandler(this.bt_about_Click);
            // 
            // pre1_1
            // 
            this.pre1_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pre1_1.Location = new System.Drawing.Point(15, 136);
            this.pre1_1.Name = "pre1_1";
            this.pre1_1.Size = new System.Drawing.Size(64, 64);
            this.pre1_1.TabIndex = 6;
            // 
            // pre2_1
            // 
            this.pre2_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pre2_1.Location = new System.Drawing.Point(268, 136);
            this.pre2_1.Name = "pre2_1";
            this.pre2_1.Size = new System.Drawing.Size(64, 64);
            this.pre2_1.TabIndex = 6;
            // 
            // pre2_2
            // 
            this.pre2_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pre2_2.Location = new System.Drawing.Point(338, 136);
            this.pre2_2.Name = "pre2_2";
            this.pre2_2.Size = new System.Drawing.Size(64, 64);
            this.pre2_2.TabIndex = 6;
            // 
            // bt_addcol
            // 
            this.bt_addcol.Location = new System.Drawing.Point(268, 39);
            this.bt_addcol.Name = "bt_addcol";
            this.bt_addcol.Size = new System.Drawing.Size(134, 24);
            this.bt_addcol.TabIndex = 7;
            this.bt_addcol.UseVisualStyleBackColor = true;
            this.bt_addcol.Click += new System.EventHandler(this.bt_addcol_Click);
            // 
            // data_carcol1
            // 
            this.data_carcol1.Location = new System.Drawing.Point(268, 97);
            this.data_carcol1.Maximum = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.data_carcol1.Name = "data_carcol1";
            this.data_carcol1.Size = new System.Drawing.Size(48, 20);
            this.data_carcol1.TabIndex = 8;
            this.data_carcol1.ValueChanged += new System.EventHandler(this.data_carcol1_ValueChanged);
            // 
            // data_carcol2
            // 
            this.data_carcol2.Location = new System.Drawing.Point(354, 99);
            this.data_carcol2.Maximum = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.data_carcol2.Name = "data_carcol2";
            this.data_carcol2.Size = new System.Drawing.Size(48, 20);
            this.data_carcol2.TabIndex = 8;
            this.data_carcol2.ValueChanged += new System.EventHandler(this.data_carcol2_ValueChanged);
            // 
            // bt_delcol
            // 
            this.bt_delcol.Location = new System.Drawing.Point(268, 69);
            this.bt_delcol.Name = "bt_delcol";
            this.bt_delcol.Size = new System.Drawing.Size(134, 24);
            this.bt_delcol.TabIndex = 7;
            this.bt_delcol.UseVisualStyleBackColor = true;
            this.bt_delcol.Click += new System.EventHandler(this.bt_delcol_Click);
            // 
            // data_vcollist
            // 
            this.data_vcollist.FormattingEnabled = true;
            this.data_vcollist.Location = new System.Drawing.Point(408, 39);
            this.data_vcollist.Name = "data_vcollist";
            this.data_vcollist.Size = new System.Drawing.Size(122, 160);
            this.data_vcollist.TabIndex = 9;
            this.data_vcollist.SelectedIndexChanged += new System.EventHandler(this.data_vcollist_SelectedIndexChanged);
            // 
            // data_car
            // 
            this.data_car.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.data_car.FormattingEnabled = true;
            this.data_car.Location = new System.Drawing.Point(336, 6);
            this.data_car.Name = "data_car";
            this.data_car.Size = new System.Drawing.Size(194, 21);
            this.data_car.TabIndex = 3;
            this.data_car.SelectedIndexChanged += new System.EventHandler(this.data_car_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 10;
            // 
            // ch_clist
            // 
            this.ch_clist.AutoSize = true;
            this.ch_clist.Location = new System.Drawing.Point(85, 183);
            this.ch_clist.Name = "ch_clist";
            this.ch_clist.Size = new System.Drawing.Size(15, 14);
            this.ch_clist.TabIndex = 11;
            this.ch_clist.UseVisualStyleBackColor = true;
            // 
            // ch_carcol
            // 
            this.ch_carcol.AutoSize = true;
            this.ch_carcol.Location = new System.Drawing.Point(165, 183);
            this.ch_carcol.Name = "ch_carcol";
            this.ch_carcol.Size = new System.Drawing.Size(15, 14);
            this.ch_carcol.TabIndex = 11;
            this.ch_carcol.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 237);
            this.Controls.Add(this.ch_carcol);
            this.Controls.Add(this.ch_clist);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.data_vcollist);
            this.Controls.Add(this.data_carcol2);
            this.Controls.Add(this.data_carcol1);
            this.Controls.Add(this.bt_delcol);
            this.Controls.Add(this.bt_addcol);
            this.Controls.Add(this.pre2_2);
            this.Controls.Add(this.pre2_1);
            this.Controls.Add(this.pre1_1);
            this.Controls.Add(this.bt_about);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_changecol);
            this.Controls.Add(this.data_car);
            this.Controls.Add(this.data_clist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.data_color);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_carcol1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_carcol2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label data_color;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox data_clist;
        private System.Windows.Forms.Button bt_changecol;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_about;
        private System.Windows.Forms.Panel pre1_1;
        private System.Windows.Forms.Panel pre2_1;
        private System.Windows.Forms.Panel pre2_2;
        private System.Windows.Forms.ColorDialog cdd;
        private System.Windows.Forms.Button bt_addcol;
        private System.Windows.Forms.NumericUpDown data_carcol1;
        private System.Windows.Forms.NumericUpDown data_carcol2;
        private System.Windows.Forms.Button bt_delcol;
        private System.Windows.Forms.ListBox data_vcollist;
        private System.Windows.Forms.ComboBox data_car;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ch_clist;
        private System.Windows.Forms.CheckBox ch_carcol;
    }
}


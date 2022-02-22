namespace surfedit
{
    partial class Form2
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
            this.bt_save = new System.Windows.Forms.Button();
            this.data1 = new System.Windows.Forms.ComboBox();
            this.data2 = new System.Windows.Forms.ComboBox();
            this.bt_about = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            //this.label1.Text = "Felület neve";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            //this.label2.Text = "Felület hangja";
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(12, 33);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(256, 24);
            this.bt_save.TabIndex = 2;
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // data1
            // 
            this.data1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.data1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.data1.FormattingEnabled = true;
            this.data1.Location = new System.Drawing.Point(83, 6);
            this.data1.Name = "data1";
            this.data1.Size = new System.Drawing.Size(164, 17);
            this.data1.TabIndex = 3;
            this.data1.SelectedIndexChanged += new System.EventHandler(this.data1_SelectedIndexChanged);
            // 
            // data2
            // 
            this.data2.FormattingEnabled = true;
            this.data2.Location = new System.Drawing.Point(332, 6);
            this.data2.Name = "data2";
            this.data2.Size = new System.Drawing.Size(195, 21);
            this.data2.TabIndex = 4;
            // 
            // bt_about
            // 
            this.bt_about.Location = new System.Drawing.Point(274, 33);
            this.bt_about.Name = "bt_about";
            this.bt_about.Size = new System.Drawing.Size(256, 24);
            this.bt_about.TabIndex = 2;
            this.bt_about.UseVisualStyleBackColor = true;
            this.bt_about.Click += new System.EventHandler(this.bt_about_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 67);
            this.Controls.Add(this.data2);
            this.Controls.Add(this.data1);
            this.Controls.Add(this.bt_about);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //this.Text = "SA Toolpack: Surface Audio Editor";
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.ComboBox data1;
        private System.Windows.Forms.ComboBox data2;
        private System.Windows.Forms.Button bt_about;
    }
}
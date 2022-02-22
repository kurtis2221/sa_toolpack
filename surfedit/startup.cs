using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using toolpack;

namespace surfedit
{
    public partial class startup : Form
    {
        //Configuration manager
        FCM cfg = new FCM();
        LNG lan = new LNG();
        DataMGR mangr = new DataMGR();
        Form1 frm = new Form1();
        Form2 frm2 = new Form2();

        const string configfile = "sa_toolpack.ini";
        bool isbtclose = false;

        public startup()
        {
            InitializeComponent();
            FormSetting.SetIconFromDLL(this);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frm.Show();
            isbtclose = true;
            this.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frm2.Show();
            isbtclose = true;
            this.Dispose();
        }

        private void startup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isbtclose)
                Application.Exit();
            else
                isbtclose = false;
        }

        private void startup_Shown(object sender, EventArgs e)
        {
            //Check if everything is ok and set Language
            lan.SetLangFile(TPCore.CheckStartup(configfile));
            FormSetting.LoadOptions(this, configfile);

            //Load language strings
            this.Text = lan.getlng(7) + " " + lan.getlng(44);
            label1.Text = lan.getlng(46);
            label2.Text = lan.getlng(44);
            label3.Text = lan.getlng(45);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using toolpack;

namespace surfedit
{
    public partial class Form2 : Form
    {
        //Configuration manager
        FCM cfg = new FCM();
        LNG lan = new LNG();
        DataMGR mangr = new DataMGR();

        const string configfile = "sa_toolpack.ini";
        const string targetfile = @"data\surfaud.dat";

        //Temporary variables
        string tmpstr = null;

        string[] data = new string[256];
        string[] tmpdata = new string[10];
        int[] dataline = new int[256];

        public Form2()
        {
            InitializeComponent();
            FormSetting.SetIconFromDLL(this);
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            //Check if everything is ok and set Language
            lan.SetLangFile(TPCore.CheckStartup(configfile, targetfile));
            FormSetting.LoadOptions(this, configfile);
            this.Text = lan.getlng(7) + " " + lan.getlng(45);
            label1.Text = lan.getlng(47);
            label2.Text = lan.getlng(80);
            bt_save.Text = lan.getlng(42);
            bt_about.Text = lan.getlng(43);
            LoadData();
            for (int i = 0; i < data.Length; i++)
            {
                data1.Items.Add(data[i].Substring(0, data[i].IndexOf(' ')));
            }
            if (File.Exists("surfedit.txt"))
                mangr.SetDataSource("surfedit.txt");
            else
            {
                MessageBox.Show(lan.getlng(9) + "surfedit.txt\n" + lan.getlng(4),
                    lan.getlng(1), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            data2.Items.AddRange(mangr.ReadDataBlock("audio"));
            data2.SelectedIndex = 0;
            data1.SelectedIndex = 0;
        }

        private void LoadData()
        {
            data = null;
            data = new string[256];
            dataline = null;
            dataline = new int[256];
            TPCore.ReadData3(
                cfg.ReadData(configfile, "sapath") + targetfile,
                0,
                null,
                null,
                out data,
                out dataline,
                true,
                null);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            tmpstr = null;
            tmpstr += data1.Text + " ";
            for (int i = 0; i < tmpdata.Length-1; i++)
            {
                if (i == data2.SelectedIndex)
                    tmpstr += "1 ";
                else
                    tmpstr += "0 ";
            }
            this.Enabled = false;
            TPCore.SaveFile(
                cfg.ReadData(configfile, "sapath") + targetfile,
                cfg.ReadData(configfile, "sapath") + @"data\surfaud.tmp",
                dataline[data1.SelectedIndex],
                tmpstr);
            this.Enabled = true;
            LoadData();
            data1_SelectedIndexChanged(sender, e);
        }

        private void bt_about_Click(object sender, EventArgs e)
        {
            TPCore.ShowAboutBox(cfg.ReadData(configfile, "lang") == "hu");
        }

        private void data1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmpdata = null;
            tmpdata = data[data1.SelectedIndex].Split(' ');
            for (int i = 0; i < tmpdata.Length; i++)
            {
                if (tmpdata[i] == "1")
                {
                    data2.SelectedIndex = i - 1;
                    break;
                }
                if (tmpdata[i] != "1" && i == tmpdata.Length - 1)
                    data2.SelectedIndex = i;
            }
        }
    }
}

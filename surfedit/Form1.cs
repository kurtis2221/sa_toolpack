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
    public partial class Form1 : Form
    {
        //Configuration manager
        FCM cfg = new FCM();
        LNG lan = new LNG();
        DataMGR mangr = new DataMGR();

        const string configfile = "sa_toolpack.ini";
        const string targetfile = @"data\surfinfo.dat";

        //Temporary variables
        string tmpstr = null;

        string[] data = new string[256];
        string[] tmpdata = new string[36];
        int[] dataline = new int[256];

        Control[] lngcontrols;
        Control[] datasources;

        public Form1()
        {
            InitializeComponent();
            FormSetting.SetIconFromDLL(this);
            lngcontrols = new Control[]
            {
                label1, label2, label3, label4, label5, label51, data6, data7, data8,
                label9_17, data9, data10, data11, data12, data13, data14, data15,
                data16, data17, label18, label19, data20, data21, data22, data23,
                data24, data25, label26_31, data32, data33, data34, label35, label36
            };
            datasources = new Control[]
            {
                data2,data3,data4,data5,data51,data6,data7,data8,data9,
                data10,data11,data12,data13,data14,data15,data16,data17,data18,
                data19,data20,data21,data22,data23,data24,data25,data26,data27,
                data28,data29,data30,data31,data32,data33,data34,data35,data36
            };
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //Check if everything is ok and set Language
            lan.SetLangFile(TPCore.CheckStartup(configfile, targetfile));
            FormSetting.LoadOptions(this, configfile);

            //Load language strings
            this.Text = lan.getlng(7) + " " + lan.getlng(44);
            for (int i = 0; i < lngcontrols.Length; i++)
            {
                lngcontrols[i].Text = lan.getlng(i + 47);
            }
            bt_save.Text = lan.getlng(42);
            bt_about.Text = lan.getlng(43);
            LoadData();
            for(int i = 0; i < data.Length; i++)
            {
                data1.Items.Add(data[i].Substring(0,data[i].IndexOf(' ')));
            }
            if (File.Exists("surfedit.txt"))
                mangr.SetDataSource("surfedit.txt");
            else
            {
                MessageBox.Show(lan.getlng(9) + "surfedit.txt\n" + lan.getlng(4),
                    lan.getlng(1), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            data2.Items.AddRange(mangr.ReadDataBlock("ad_grp"));
            data5.Items.AddRange(mangr.ReadDataBlock("skidmark"));
            data51.Items.AddRange(mangr.ReadDataBlock("fr_effect"));
            data35.Items.AddRange(mangr.ReadDataBlock("bullet_fx"));
            data2.SelectedIndex = 0;
            data5.SelectedIndex = 0;
            data51.SelectedIndex = 0;
            data35.SelectedIndex = 0;
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

        private void bt_save_Click(object sender, EventArgs e)
        {
            tmpstr = null;
            tmpstr += data1.Text + " ";
            for (int i = 0; i < datasources.Length; i++)
            {
                if (datasources[i] is CheckBox)
                    tmpstr += (((CheckBox)datasources[i]).Checked ? "1" : "0") + " ";
                else if (datasources[i] is RadioButton)
                    tmpstr += (((RadioButton)datasources[i]).Checked ? "1" : "0") + " ";
                else
                    tmpstr += datasources[i].Text.Replace(",", ".") + " ";
            }
            this.Enabled = false;
            TPCore.SaveFile(
                cfg.ReadData(configfile, "sapath") + targetfile,
                cfg.ReadData(configfile, "sapath") + @"data\surfinfo.tmp",
                dataline[data1.SelectedIndex],
                tmpstr);
            this.Enabled = true;
            //Reload application data
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

            for (int i = 0; i < datasources.Length; i++)
            {
                if(datasources[i] is CheckBox)
                    ((CheckBox)datasources[i]).Checked = (tmpdata[i + 1] == "1" ? true : false);
                else if (datasources[i] is RadioButton)
                    ((RadioButton)datasources[i]).Checked = (tmpdata[i + 1] == "1" ? true : false);
                else
                    datasources[i].Text = tmpdata[i + 1].Replace(".", ",");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
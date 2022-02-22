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

namespace gtadatedit
{
    public partial class Form1 : Form
    {
        //Configuration manager
        FCM cfg = new FCM();
        LNG lan = new LNG();
        DataMGR mangr = new DataMGR();

        const string configfile = "sa_toolpack.ini";
        const string targetfile = @"data\gta.dat";

        string[] data = new string[96];
        string[] tmpdata = new string[2];
        int[] dataline = new int[96];
        string[] sequence = new string[] 
        { "IMG", "TEXDICTION", "MODELFILE", "COLFILE",
          "HIERFILE", "IDE", "IPL", "SPLASH" };

        FileStream fs;
        StreamWriter sw;

        public Form1()
        {
            InitializeComponent();
            FormSetting.SetIconFromDLL(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Check if everything is ok and set Language
            lan.SetLangFile(TPCore.CheckStartup(configfile, targetfile));
            FormSetting.LoadOptions(this, configfile);

            //Load language strings
            this.Text = lan.getlng(7) + " " + lan.getlng(81);
            data1.Columns[0].HeaderText = lan.getlng(82);
            data1.Columns[1].HeaderText = lan.getlng(83);
            bt_save.Text = lan.getlng(42);
            bt_about.Text = lan.getlng(43);
            LoadData();
            for (int i = 0; i < data.Length; i++)
            {
                tmpdata = data[i].Split(' ');
                data1.Rows.Add();
                data1.Rows[i].Cells[0].Value = tmpdata[0];
                data1.Rows[i].Cells[1].Value = tmpdata[1];
            }
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
            this.Enabled = false;
            fs = new FileStream(cfg.ReadData(configfile, "sapath") + targetfile,
                    FileMode.Truncate, FileAccess.Write);
            sw = new StreamWriter(fs, Encoding.Default);
            for (int i = 0; i < sequence.Length; i++)
            {
                for (int i2 = 0; i2 < data1.Rows.Count-1; i2++)
                {
                    if (data1.Rows[i2].Cells[0].Value.ToString() == sequence[i])
                        sw.WriteLine(data1.Rows[i2].Cells[0].Value + " " +
                            data1.Rows[i2].Cells[1].Value);
                }
            }
            sw.Close();
            fs.Close();
            this.Enabled = true;
            LoadData();
            data1.Rows.Clear();
            for (int i = 0; i < data.Length; i++)
            {
                tmpdata = data[i].Split(' ');
                data1.Rows.Add();
                data1.Rows[i].Cells[0].Value = tmpdata[0];
                data1.Rows[i].Cells[1].Value = tmpdata[1];
            }
        }

        private void bt_about_Click(object sender, EventArgs e)
        {
            TPCore.ShowAboutBox(cfg.ReadData(configfile, "lang") == "hu");
        }
    }
}

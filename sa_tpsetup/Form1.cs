using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

//Written by me
using toolpack;

namespace sa_tpsetup
{
    public partial class Form1 : Form
    {
        //Configuration manager
        FCM cfg = new FCM();
        LNG lan = new LNG();
        string tmp = null;

        const string configfile = "sa_toolpack.ini";

        public Form1()
        {
            InitializeComponent();
            FormSetting.SetIconFromDLL(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Check if everything is ok with startup
            if (File.Exists("setup_en.lng") && File.Exists("setup_hu.lng"))
            {
                //Check the two language files
                lan.SetLangFile("setup_hu.lng");
                if (lan.getlng(18) == null)
                {
                    MessageBox.Show(
                        "Language file corrupted, program shutting down.\n" +
                        "Nyelvi fájl sérült, a program leáll.",
                        "Fatal Error / Végzetes Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                lan.SetLangFile("setup_en.lng");
                if (lan.getlng(18) == null)
                {
                    MessageBox.Show(
                        "Language file corrupted, program shutting down.\n" +
                        "Nyelvi fájl sérült, a program leáll.",
                        "Fatal Error / Végzetes Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                //If config file missing
                if (!File.Exists(configfile))
                {
                    if (MessageBox.Show("Angol nyelv? / English language?", "Question / Kérdés", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        lan.SetLangFile("setup_en.lng");
                    else lan.SetLangFile("setup_hu.lng");
                    MessageBox.Show(lan.getlng(5) + "\n" + lan.getlng(6), lan.getlng(3), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Generation code
                    FileStream fs = new FileStream(configfile,FileMode.Create,FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs,Encoding.Default);
                    sw.WriteLine("lang=" + lan.GetLangFile().Replace("setup_","").Replace(".lng",""));
                    sw.WriteLine("sapath=");
                    sw.WriteLine("back=");
                    sw.WriteLine("font=");
                    sw.Close();
                    fs.Close();
                    sw.Dispose();
                    fs.Dispose();
                }
                else
                {
                    //Check language if config found
                    if (cfg.ReadData(configfile, "lang") == "hu") lan.SetLangFile("setup_hu.lng");
                    else lan.SetLangFile("setup_en.lng");
                        MessageBox.Show(lan.getlng(18), lan.getlng(2), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(
                    "Language files are missing, program shutting down!\n" +
                    "Nyelvi fájlok hiányoznak, a program leáll.",
                    "Fatal Error / Végzetes Hiba",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
            }
            //Load language text from files
            label_sapath.Text = lan.getlng(8);
            label_progdat.Text = lan.getlng(7);
            label_palbg.Text = lan.getlng(9);
            label_palfon.Text = lan.getlng(10);
            bt_browse.Text = lan.getlng(12);
            bt_scan.Text = lan.getlng(13);
            bt_palbg.Text = lan.getlng(11);
            bt_palfon.Text = lan.getlng(11);
            //Load Path
            if (cfg.ReadData(configfile, "sapath").Length > 0)
                data_sapath.Text = cfg.ReadData(configfile, "sapath");
            FormSetting.LoadOptions(this, configfile);
        }

        //Button Events
        private void bt_palbg_Click(object sender, EventArgs e)
        {
            if (cdialog.ShowDialog() == DialogResult.OK)
            {
                cfg.ChangeData(configfile,"back", cdialog.Color.ToArgb().ToString());
                this.BackColor = cdialog.Color;
            }
        }

        private void bt_palfon_Click(object sender, EventArgs e)
        {
            if (cdialog.ShowDialog() == DialogResult.OK)
            {
                cfg.ChangeData(configfile, "font", cdialog.Color.ToArgb().ToString());
                this.ForeColor = cdialog.Color;
            }
        }

        private void bt_browse_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fbd.SelectedPath + "\\gta_sa.exe"))
                {
                    MessageBox.Show(lan.getlng(15), lan.getlng(2),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    data_sapath.Text = fbd.SelectedPath;
                    cfg.ChangeData(configfile,"sapath",data_sapath.Text + (data_sapath.Text[data_sapath.Text.Length-1] != '\\' ? "\\" : null));
                }
                else
                    MessageBox.Show(lan.getlng(16), lan.getlng(1),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_scan_Click(object sender, EventArgs e)
        {
            tmp = Convert.ToString( Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Rockstar Games\GTA San Andreas\Installation", "ExePath", null));
            //64 bit, just in case
            if (tmp == null || !tmp.Contains(@"\"))
                tmp = Convert.ToString( Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Rockstar Games\GTA San Andreas\Installation", "ExePath", null));

            if (tmp != null && tmp.Contains(@"\"))
            {
                if (File.Exists(tmp.Substring(1, tmp.LastIndexOf(@"\", tmp.Length)) + "gta_sa.exe"))
                {
                    MessageBox.Show(lan.getlng(15), lan.getlng(2),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    data_sapath.Text = tmp.Substring(1,tmp.LastIndexOf(@"\",tmp.Length));
                    cfg.ChangeData(configfile, "sapath", data_sapath.Text + (data_sapath.Text[data_sapath.Text.Length - 1] != '\\' ? "\\" : null));
                }
                else
                    MessageBox.Show(lan.getlng(15) + "\n" + lan.getlng(16), lan.getlng(1),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(lan.getlng(17), lan.getlng(1),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
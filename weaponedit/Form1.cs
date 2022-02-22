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

namespace weaponedit
{
    public partial class Form1 : Form
    {
        //Configuration manager
        FCM cfg = new FCM();
        LNG lan = new LNG();
        DataMGR mangr = new DataMGR();

        const string configfile = "sa_toolpack.ini";
        const string targetfile = @"data\weapon.dat";

        //Temporary variables
        int tmp = 0;
        string tmpstr = null;

        string[] data = new string[96];
        string[] tmpdata = new string[32];
        int[] dataline = new int[96];

        //Collections
        CheckBox[,] flags;
        Control[] datasources;
        Control[] datasourcesA;
        Control[] datasourcesB;
        Control[] lngcontrols;

        public Form1()
        {
            InitializeComponent();
            FormSetting.SetIconFromDLL(this);
            //Load Control Collections, will make our program easier later
            lngcontrols = new Control[] 
            {
                label_A, label_B, label_C, label_D, label_E, label_F, label_I,
                label_J1, label_K1, label_L1, label_MNO, label_M1, label_N,
                label_O, label_P, label_Q, label_R, label_S, label_TUV, label_WXY,
                label_T, label_U, label_V, label_W, label_X, label_Y, label_Z,
                label_AA, label_BB, label_CC, label_DD, label_EE, label_J2,
                label_K2, label_M2, bt_save, bt_about
            };
            flags = new CheckBox[,]
            {
                {flag_11, flag_12, flag_13, flag_14},
                {flag_21, flag_22, null, null},
                {flag_31, flag_32, flag_33, flag_34},
                {flag_41, flag_42, flag_43, flag_44},
                {flag_51, flag_52, flag_53, null}
            };
            datasources = new Control[]
            {
                data_B,data_C,data_D,data_E,data_F,data_I
            };
            datasourcesA = new Control[]
            {
                data_J1,data_K1,data_L1,data_M1,data_N,data_O,data_P,data_Q,data_R,
                data_S,data_T, data_U,data_V,data_W,data_X,data_Y,data_Z,null,data_BB,
                data_CC,data_DD,data_EE
            };
            datasourcesB = new Control[]
            {
                data_J2,data_K2,null,data_M2
            };
            //null is for flags
        }

        private void EnableGuns(bool istrue)
        {
            for (int i = 0; i < datasourcesA.Length; i++)
            {
                if (datasourcesA[i] == null) continue;
                datasourcesA[i].Enabled = istrue;
            }

            for (int i = 0; i < datasourcesB.Length; i++)
            {
                if (datasourcesB[i] == null) continue;
                datasourcesB[i].Enabled = !istrue;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Check if everything is ok and set Language
            lan.SetLangFile(TPCore.CheckStartup(configfile,targetfile));
            FormSetting.LoadOptions(this, configfile);

            //Load language strings
            this.Text = lan.getlng(7) + " " + lan.getlng(8);
            tmp = 0;
            for (int i = 0; i < lngcontrols.Length; i++)
            {
                if (lngcontrols[i].Name == "label_W")
                    tmp = 1;

                if (tmp == 0)
                    lngcontrols[i].Text = lan.getlng(i + 10);
                else
                    lngcontrols[i].Text = lan.getlng(i + 7);
            }

            //Load DB
            LoadData();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == null) continue;
                data_A.Items.Add(data[i].Substring(0, data[i].IndexOf(' ', 2)));
            }
            if (File.Exists("weaponedit.txt"))
                mangr.SetDataSource("weaponedit.txt");
            else
            {
                MessageBox.Show(lan.getlng(9) + "weaponedit.txt\n" + lan.getlng(4),
                    lan.getlng(1),MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
            }
            data_B.Items.AddRange(mangr.ReadDataBlock("firetype"));
            data_J1.Items.AddRange(mangr.ReadDataBlock("anim_gun"));
            data_J2.Items.AddRange(mangr.ReadDataBlock("anim_melee"));
            data_M2.Items.AddRange(mangr.ReadDataBlock("anim_st"));
            //Set all items to index 0
            data_B.SelectedIndex = 0;
            data_J1.SelectedIndex = 0;
            data_A.SelectedIndex = 0;
        }

        private void LoadData()
        {
            data = null;
            data = new string[96];
            dataline = null;
            dataline = new int[96];
            TPCore.ReadData(
                cfg.ReadData(configfile, "sapath") + targetfile,
                new char[] { 'Ł', '$' },
                null,
                "ENDWEAPONDATA",
                out data,
                out dataline,
                true);
        }

        //Load selected data
        private void data_weapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmpdata = null;
            tmpdata = data[data_A.SelectedIndex].Split(' ');

            for (int i = 0; i < datasources.Length; i++)
            {
                datasources[i].Text = tmpdata[i + 2].Replace(".", ",");
            }
            if (data_A.Text[0] == '$')
            {
                EnableGuns(true);
                for (int i = 0; i < datasourcesA.Length; i++)
                {
                    if (datasourcesA[i] == null) continue;
                    datasourcesA[i].ResetText();
                }
                for (int i = 0; i < datasourcesA.Length; i++)
                {
                    if (datasourcesA[i] == null)
                    {
                        TPCore.ReadHex(this, tmpdata[i + 8], "flag_");
                        continue;
                    }
                    if (tmpdata.Length <= i + 8)
                        datasourcesA[i].Enabled = false;
                    else
                    {
                        datasourcesA[i].Enabled = true;
                        datasourcesA[i].Text = tmpdata[i + 8].Replace(".", ",");
                    }
                }
            }
            else
            {
                EnableGuns(false);
                for (int i = 0; i < datasourcesB.Length; i++)
                {
                    if (datasourcesB[i] == null) continue;
                    datasourcesB[i].ResetText();
                }
                for (int i = 0; i < datasourcesB.Length; i++)
                {
                    if (datasourcesB[i] == null)
                    {
                        TPCore.ReadHex(this, tmpdata[i + 8], "flag_");
                        continue;
                    }
                    if (tmpdata.Length <= i + 8)
                        datasourcesB[i].Enabled = false;
                    else
                    {
                        datasourcesB[i].Enabled = true;
                        datasourcesB[i].Text = tmpdata[i + 8].Replace(".", ",");
                    }
                }
            }
        }

        private void bt_about_Click(object sender, EventArgs e)
        {
            TPCore.ShowAboutBox(cfg.ReadData(configfile, "lang") == "hu");
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            tmpstr = null;
            tmpstr += data_A.Text + " ";
            for (int i = 0; i < datasources.Length; i++)
            {
                tmpstr += datasources[i].Text.Replace(",", ".") + " ";
            }

            if (data_A.Text[0] == '$')
            {
                for (int i = 0; i < datasourcesA.Length; i++)
                {
                    //Null is for HEX
                    if (datasourcesA[i] == null)
                    {
                        tmpstr += TPCore.SaveHex(this, "flag_", 5, 4);
                        continue;
                    }
                    tmpstr += datasourcesA[i].Text.Replace(",", ".") + " ";
                }
            }
            else
            {
                for (int i = 0; i < datasourcesB.Length; i++)
                {
                    //Null is for HEX
                    if (datasourcesB[i] == null)
                    {
                        tmpstr += TPCore.SaveHex(this, "flag_", 5, 4);
                        continue;
                    }
                    tmpstr += datasourcesB[i].Text.Replace(",", ".") + " ";
                }
            }
            this.Enabled = false;
            TPCore.SaveFile(
                cfg.ReadData(configfile, "sapath") + targetfile,
                cfg.ReadData(configfile, "sapath") + @"data\weapon.tmp",
                dataline[data_A.SelectedIndex],
                tmpstr);
            this.Enabled = true;
            //Reload application data
            LoadData();
            data_weapon_SelectedIndexChanged(sender, e);
        }
    }
}
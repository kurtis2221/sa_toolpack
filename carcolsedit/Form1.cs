using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using toolpack;

namespace carcolsedit
{
    public partial class Form1 : Form
    {
        //Configuration manager
        FCM cfg = new FCM();
        LNG lan = new LNG();
        DataMGR mangr = new DataMGR();

        const string configfile = "sa_toolpack.ini";
        const string targetfile = @"data\carcols.dat";

        //Temporary variables
        string tmpstr = null;
        string tmpstr2 = null;

        string[] data = new string[128];
        string[] tmpdata = new string[32];
        string[] tmpcolor = new string[3];
        int[] dataline = new int[128];

        string[] data2 = new string[256];
        string[] tmpdata2 = new string[256];
        int[] dataline2 = new int[256];

        bool crossprotect = false;

        Control[] lngcontrols;

        public Form1()
        {
            InitializeComponent();
            FormSetting.SetIconFromDLL(this);
            lngcontrols = new Control[]
            {
                label1, label2, label3, label5,
                bt_changecol, bt_addcol, bt_delcol, label6,
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Check if everything is ok and set Language
            lan.SetLangFile(TPCore.CheckStartup(configfile, targetfile));
            FormSetting.LoadOptions(this, configfile);

            //Load language strings
            this.Text = lan.getlng(7) + " " + lan.getlng(84);
            for (int i = 0; i < lngcontrols.Length; i++)
            {
                lngcontrols[i].Text = lan.getlng(i + 85);
            }
            label4.Text = label3.Text;
            ch_clist.Text = label1.Text;
            ch_carcol.Text = label2.Text;
            bt_save.Text = lan.getlng(42);
            bt_about.Text = lan.getlng(43);
            LoadData();
            for (int i = 0; i < data.Length; i++)
            {
                data_clist.Items.Add(data[i].Substring(data[i].IndexOf(' ') + 1,
                data[i].Length - data[i].IndexOf(' ') - 1));
            }
            for (int i = 0; i < data2.Length; i++)
            {
                data_car.Items.Add(data2[i].Substring(0, data2[i].IndexOf(',')));
            }
            data_clist.SelectedIndex = 0;
            data_car.SelectedIndex = 0;
            data_vcollist.SelectedIndex = 0;
            data_carcol1.Maximum = data_clist.Items.Count - 1;
            data_carcol2.Maximum = data_clist.Items.Count - 1;
        }

        private void LoadData()
        {
            data = null;
            data = new string[128];
            dataline = null;
            dataline = new int[128];
            data2 = null;
            data2 = new string[256];
            dataline2 = null;
            dataline2 = new int[256];

            TPCore.ReadData3(
                cfg.ReadData(configfile, "sapath") + targetfile,
                1,
                "col",
                "end",
                out data,
                out dataline,
                true,
                null);
            TPCore.ReadData3(
                cfg.ReadData(configfile, "sapath") + targetfile,
                0,
                "car",
                "end",
                out data2,
                out dataline2,
                true,
                null);
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (ch_clist.Checked || ch_carcol.Checked)
            {
                tmpstr = null;
                if (ch_clist.Checked)
                {
                    tmpstr += data_color.Text + " ";
                    tmpstr += data_clist.Text;
                    TPCore.SaveFile(
                        cfg.ReadData(configfile, "sapath") + targetfile,
                        cfg.ReadData(configfile, "sapath") + @"data\surfinfo.tmp",
                        dataline[data_clist.SelectedIndex],
                        tmpstr);
                }
                tmpstr = null;
                if (ch_carcol.Checked)
                {
                    if (data_vcollist.Items.Count > 0)
                    {
                        tmpstr += data_car.Text + ", ";
                        for (int i = 0; i < data_vcollist.Items.Count; i++)
                        {
                            if (i == data_vcollist.Items.Count - 1)
                                tmpstr += data_vcollist.Items[i].ToString();
                            else
                                tmpstr += data_vcollist.Items[i].ToString() + ", ";
                        }
                        TPCore.SaveFile(
                        cfg.ReadData(configfile, "sapath") + targetfile,
                        cfg.ReadData(configfile, "sapath") + @"data\surfinfo.tmp",
                        dataline2[data_car.SelectedIndex],
                        tmpstr);
                    }
                    else
                    {
                        MessageBox.Show(lan.getlng(94), lan.getlng(1),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto end;
                    }
                }
                this.Enabled = false;
                this.Enabled = true;
                LoadData();
                data_clist_SelectedIndexChanged(sender, e);
                data_car_SelectedIndexChanged(sender, e);
            }
            else MessageBox.Show(lan.getlng(93), lan.getlng(1),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        end: { }
        }

        private void bt_about_Click(object sender, EventArgs e)
        {
            TPCore.ShowAboutBox(cfg.ReadData(configfile, "lang") == "hu");
        }

        private void bt_changecol_Click(object sender, EventArgs e)
        {
            cdd.Color = pre1_1.BackColor;
            if (cdd.ShowDialog() == DialogResult.OK)
            {
                pre1_1.BackColor = cdd.Color;
                data_color.Text = cdd.Color.R + "," + cdd.Color.G + "," + cdd.Color.B;
            }
        }

        private void data_clist_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmpstr = data[data_clist.SelectedIndex];
            data_color.Text = tmpstr.Substring(0, tmpstr.IndexOf(' '));
            tmpcolor = data_color.Text.Split(new char[] { ',', '.' });
            pre1_1.BackColor =
                Color.FromArgb(
                Convert.ToInt32(tmpcolor[0]),
                Convert.ToInt32(tmpcolor[1]),
                Convert.ToInt32(tmpcolor[2])
                );
        }

        private void data_car_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Very paranoid mode thanks to R*
            tmpdata2 = null;
            tmpdata2 = new string[256];
            data_vcollist.Items.Clear();
            tmpstr = data2[data_car.SelectedIndex];
            tmpstr = tmpstr.Substring(tmpstr.IndexOf(',') + 1,
                tmpstr.Length - tmpstr.IndexOf(',') - 1);
            for (int i = 0; i < tmpstr.Length; i++)
            {
                if (i + 2 == tmpstr.Length - 1) break;
                if (tmpstr[i] != ' ' && tmpstr[i] != ','
                    && tmpstr[i + 1] == ' ' &&
                    tmpstr[i + 2] != ' ' && tmpstr[i + 2] != ',')
                    tmpstr = ReplaceCharInString(tmpstr, i + 1, ',');
            }
            tmpdata2 = tmpstr.Replace(" ", "").Split(',');
            for (int i = 0; i < tmpdata2.Length; i += 2)
            {
                if (tmpdata2[i] != "" && tmpdata2[i + 1] != "")
                    data_vcollist.Items.Add(tmpdata2[i] + "," + tmpdata2[i + 1]);
            }
            if (data_vcollist.Items.Count > 0)
                data_vcollist.SelectedIndex = 0;
        }

        private void data_vcollist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!crossprotect)
            {
                //crossprotect = no error because 2 events at once
                crossprotect = true;
                tmpstr2 = data_vcollist.SelectedItem.ToString().Replace(".", ",");
                data_carcol1.Text = tmpstr2.Substring(0, tmpstr2.IndexOf(','));
                tmpstr = data[Convert.ToInt32(tmpstr2.Substring(0, tmpstr2.IndexOf(',')))];
                tmpstr2 = tmpstr.Substring(0, tmpstr.IndexOf(' '));
                data_carcol1.Text = tmpstr2;
                tmpcolor = tmpstr2.Split(new char[] { ',', '.' });
                pre2_1.BackColor =
                    Color.FromArgb(
                    Convert.ToInt32(tmpcolor[0]),
                    Convert.ToInt32(tmpcolor[1]),
                    Convert.ToInt32(tmpcolor[2])
                    );
                tmpstr2 = data_vcollist.SelectedItem.ToString().Replace(".", ",");
                data_carcol2.Text = tmpstr2.Substring(tmpstr2.IndexOf(',') + 1,
                    tmpstr2.Length - tmpstr2.IndexOf(',') - 1);
                tmpstr = data[Convert.ToInt32(tmpstr2.Substring(tmpstr2.IndexOf(',') + 1,
                    tmpstr2.Length - tmpstr2.IndexOf(',') - 1))];
                tmpstr2 = tmpstr.Substring(0, tmpstr.IndexOf(' '));
                data_carcol2.Text = tmpstr2;
                tmpcolor = tmpstr2.Split(new char[] { ',', '.' });
                pre2_2.BackColor =
                    Color.FromArgb(
                    Convert.ToInt32(tmpcolor[0]),
                    Convert.ToInt32(tmpcolor[1]),
                    Convert.ToInt32(tmpcolor[2])
                    );
                crossprotect = false;
            }
        }

        private string ReplaceCharInString(string input, int index, char character)
        {
            string output = null;
            for (int i = 0; i < input.Length; i++)
            {
                if (i == index)
                {
                    output += character;
                    continue;
                }
                output += input[i];
            }
            return output;
        }

        private void bt_addcol_Click(object sender, EventArgs e)
        {
            data_vcollist.Items.Add((int)data_carcol1.Value + ","
                + (int)data_carcol2.Value);
        }

        private void bt_delcol_Click(object sender, EventArgs e)
        {
            crossprotect = true;
            data_vcollist.Items.RemoveAt(data_vcollist.SelectedIndex);
            crossprotect = false;
            if (data_vcollist.Items.Count > 0)
                data_vcollist.SelectedIndex = 0;
        }

        private void data_carcol1_ValueChanged(object sender, EventArgs e)
        {
            if (!crossprotect)
            {
                tmpstr = data[(int)data_carcol1.Value];
                tmpstr2 = tmpstr.Substring(0, tmpstr.IndexOf(' '));
                data_carcol2.Text = tmpstr2;
                tmpcolor = tmpstr2.Split(new char[] { ',', '.' });
                pre2_1.BackColor =
                    Color.FromArgb(
                    Convert.ToInt32(tmpcolor[0]),
                    Convert.ToInt32(tmpcolor[1]),
                    Convert.ToInt32(tmpcolor[2])
                    );
            }
        }

        private void data_carcol2_ValueChanged(object sender, EventArgs e)
        {
            if (!crossprotect)
            {
                tmpstr = data[(int)data_carcol2.Value];
                tmpstr2 = tmpstr.Substring(0, tmpstr.IndexOf(' '));
                data_carcol2.Text = tmpstr2;
                tmpcolor = tmpstr2.Split(new char[] { ',', '.' });
                pre2_2.BackColor =
                    Color.FromArgb(
                    Convert.ToInt32(tmpcolor[0]),
                    Convert.ToInt32(tmpcolor[1]),
                    Convert.ToInt32(tmpcolor[2])
                    );
            }
        }
    }
}
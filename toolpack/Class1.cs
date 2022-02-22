using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace toolpack
{
    public partial class FormSetting
    {
        static FCM cfg = new FCM();

        public static void LoadOptions(Form targetform, string config)
        {
            //Load BG and FONT
            if (cfg.ReadData(config, "back").Length > 0)
                targetform.BackColor = Color.FromArgb(Convert.ToInt32(cfg.ReadData(config, "back")));
            if (cfg.ReadData(config, "font").Length > 0)
                targetform.ForeColor = Color.FromArgb(Convert.ToInt32(cfg.ReadData(config, "font")));
        }
        public static void SetIconFromDLL(Form inform)
        {
            inform.Icon = Properties.Resources.toolpack;
        }
    }

    public partial class FCM
    {
        string cfgmark = "=";

        /// <summary>
        /// Change the "=" mark to something else if needed only 1 character will be read
        /// </summary>
        /// <param name="mark">A character that separates the data name and the data itself</param>
        public void SetMark(string mark)
        {
            cfgmark = mark[0].ToString();
        }

        /// <summary>
        /// Reading Data from a file
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The name of the data in the file</param>
        /// <returns>The value of the data</returns>
        public string ReadData(string filename, string data)
        {
            string line = null;
            int i = 0;
            while (true)
            {
                i += 1;
                line = GetLine(filename, i);
                if (line == null || line.Length <= 0) break;
                if (line[0].ToString() == "#") continue;

                if (!line.StartsWith(data + cfgmark)) continue;
                else if (line.StartsWith(data + cfgmark))
                    return line.Substring(data.Length + 1, line.Length - (data.Length + 1));
            }
            return null;
        }

        /// <summary>
        /// Checks if the data exist
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The name of the data in the file</param>
        /// <returns></returns>
        public bool CheckData(string filename, string data)
        {
            string line = null;
            int i = 0;
            while (true)
            {
                i += 1;
                line = GetLine(filename, i);
                if (line == null || line.Length <= 0) break;
                if (!line.StartsWith(data)) continue;
                else if (line.StartsWith(data)) return true;
            }
            return false;
        }

        /// <summary>
        /// Deleting the whole file, only use if you aren't using comments in original
        /// </summary>
        /// <param name="filename">The name of the file</param>
        public void DeleteData(string filename)
        {
            if (File.Exists(filename)) File.Delete(filename);
            File.Create(filename).Close();
        }

        /// <summary>
        /// Changing data without regenerating the whole file
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The data needed to be changed</param>
        /// <param name="newval">The new value</param>
        public void ChangeData(string filename, string data, string newval)
        {
            string value = null;
            if (CheckData(filename, data) == true)
            {
                value = ReadData(filename, data);
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs,Encoding.Default);
                string tmp = sr.ReadToEnd().Replace("\n" + data + cfgmark + value, "\n" + data + cfgmark + newval);
                sr.Close();
                fs.Close();
                fs = new FileStream(filename, FileMode.Truncate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs,Encoding.Default);
                sw.Write(tmp);
                sw.Close();
                fs.Close();
            }
            else WriteData(filename, data, newval);
        }

        /// <summary>
        /// Add new data if it isn't exist, need to be programmed before
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <param name="data">The name of the data needed to be added</param>
        /// <param name="value">The value</param>
        public void WriteData(string filename, string data, string value)
        {
            FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs,Encoding.Default);
            sw.WriteLine(data + cfgmark + value);
            sw.Close();
            fs.Close();
        }

        public string GetLine(string fileName, int line)
        {
            using (var sr = new StreamReader(fileName, Encoding.Default))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }
    }

    public partial class TPCore
    {
        //Little challenging, but it's worth the code
        public static void SaveFile(string targetfile, string tmpfile, int line, string data)
        {
            FCM cfg = new FCM();

            if (File.Exists(tmpfile))
                File.Delete(tmpfile);
            FileStream fs = new FileStream(tmpfile, FileMode.CreateNew, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);

            for (int i = 1; i < line; i++)
            {
                sw.WriteLine(cfg.GetLine(targetfile, i));
            }
            //Without this the program can cause a lot of trouble
            if (data[data.Length - 1] != ' ')
                sw.WriteLine(data);
            else
                sw.WriteLine(data.Substring(0,data.Length-1));
            for (int i = line + 1; i > 0; i++)
            {
                if (cfg.GetLine(targetfile, i) == null) break;
                sw.WriteLine(cfg.GetLine(targetfile, i));
            }
            sw.Close();
            fs.Close();
            File.Delete(targetfile);
            File.Copy(tmpfile, targetfile);
            File.Delete(tmpfile);
        }

        public static Control FindByName(Form target, string name)
        {
            foreach (Control c in target.Controls)
            {
                if (c.Name == name)
                    return c;
            }
            return null;
        }

        public static void ReadHex(Form target, string input, string sign)
        {
            int tmp = 0, tmp2 = 0;
            string tmpstr = null;
            for (int i = 1; i <= 5; i++)
                for (int i2 = 1; i2 <= 4; i2++)
                    if (TPCore.FindByName(target, sign + i.ToString() + i2.ToString()) != null)
                        ((CheckBox)TPCore.FindByName(target, sign + i.ToString() + i2.ToString())).Checked = false;
            tmp = 1;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                tmp2 = Convert.ToInt32(input[i].ToString(), 16);
                tmpstr = Convert.ToString(tmp2, 2);
                tmpstr = TPCore.ReverseString(tmpstr);
                for (int i2 = 0; i2 < tmpstr.Length; i2++)
                {
                    if (TPCore.FindByName(target, sign + tmp.ToString() + (i2 + 1).ToString()) != null)
                        ((CheckBox)TPCore.FindByName(target, sign + tmp.ToString() + (i2 + 1).ToString())).Checked =
                            (tmpstr[i2] == '1' ? true : false);
                }
                tmp++;
            }
        }

        public static string SaveHex(Form target, string sign, int rows, int maxdata)
        {
            string tmpstr = null;
            int tmp = 0;
            for (int i = 1; i <= rows; i++)
            {
                tmp = 0;
                for (int i2 = 1; i2 <= maxdata; i2++)
                {
                    if (TPCore.FindByName(target, sign + i.ToString() + i2.ToString()) != null)
                        if (((CheckBox)(FindByName(target, sign + i.ToString() + i2.ToString()))).Checked)
                            tmp += (int)Math.Pow(2, i2 - 1);
                }
                tmpstr += tmp.ToString();
            }
            tmpstr = TPCore.ReverseString(tmpstr);
            for (int i = 0; i < tmpstr.Length; i++)
            {
                if (tmpstr[i] == '0')
                {
                    if (i + 1 == tmpstr.Length) break;
                    if (tmpstr[i + 1] != '0')
                    {
                        tmpstr = tmpstr.Substring(i + 1, tmpstr.Length - (i + 1));
                        break;
                    }
                }
            }
            if (tmpstr.Length > 0)
                return tmpstr + " ";
            else
                return "0 ";
        }

        public static void ReadData(string filename, char[] filter, string start, string end,
            out string[] data, out int[] linenumbs, bool collapse)
        {
            FCM cfg = new FCM();
            int tmp = 0;
            bool started = false;
            string tmpstr = null;

            List<int> intlist = new List<int>();
            List<string> stringlist = new List<string>();

            while (true)
            {
                tmp++;
                tmpstr = cfg.GetLine(filename, tmp);
                if (!started && tmpstr == start)
                {
                    started = true;
                    continue;
                }
                if (tmpstr == end && (started || start == null)) break;
                if (tmpstr == null || tmpstr.Length <= 0) continue;
                if (start != null && !started) continue;

                for (int i = 0; i < filter.Length; i++)
                {
                    if (tmpstr[0] == filter[i])
                    {
                        if (collapse) tmpstr = TPCore.CollapseSpaces(tmpstr);
                        if (tmpstr == " ") continue; //Just in case
                        intlist.Add(tmp);
                        stringlist.Add(tmpstr);
                    }
                }
            }
            data = stringlist.ToArray();
            linenumbs = intlist.ToArray();
        }

        public static void ReadData2(string filename, char[] filter, string start, string end,
            out string[] data, out int[] linenumbs, bool collapse)
        {
            FCM cfg = new FCM();
            int tmp = 0;
            bool started = false;
            string tmpstr = null;

            List<int> intlist = new List<int>();
            List<string> stringlist = new List<string>();

            while (true)
            {
                tmp++;
                tmpstr = cfg.GetLine(filename, tmp);
                if (!started && tmpstr == start)
                {
                    started = true;
                    continue;
                }
                if (tmpstr == end && (started || start == null)) break;
                if (tmpstr == null || tmpstr.Length <= 0) continue;
                if (start != null && !started) continue;

                for (int i = 0; i < filter.Length; i++)
                {
                    if (tmpstr[0] != filter[i])
                    {
                        if (collapse) tmpstr = TPCore.CollapseSpaces(tmpstr);
                        if (tmpstr == " ") continue; //Just in case
                        intlist.Add(tmp);
                        stringlist.Add(tmpstr);
                    }
                }
            }
            data = stringlist.ToArray();
            linenumbs = intlist.ToArray();
        }

        public static void ReadData3(string filename, int filter, string start, string end,
            out string[] data, out int[] linenumbs, bool collapse, string[] filter2)
        {
            FCM cfg = new FCM();
            int tmp = 0;
            bool started = false;
            string tmpstr = null;

            List<int> intlist = new List<int>();
            List<string> stringlist = new List<string>();

            while (true)
            {
            start:
                tmp++;
                tmpstr = cfg.GetLine(filename, tmp);
                if (!started && tmpstr == start)
                {
                    started = true;
                    continue;
                }
                if (tmpstr == end && (started || start == null)) break;
                if (tmpstr == null || tmpstr.Length <= 0) continue;
                if (start != null && !started) continue;

                if (filter2 != null)
                {
                    for (int i = 0; i < filter2.Length; i++)
                        if (filter2[i] == tmpstr) goto start;
                }

                if (filter == 0 && char.IsLetter(tmpstr[0]))
                {
                    if (collapse) tmpstr = TPCore.CollapseSpaces(tmpstr);
                    if (tmpstr == " ") continue;
                    intlist.Add(tmp);
                    stringlist.Add(tmpstr);
                }
                else if (filter == 1 && char.IsNumber(tmpstr[0]))
                {
                    if (collapse) tmpstr = TPCore.CollapseSpaces(tmpstr);
                    if (tmpstr == " ") continue;
                    intlist.Add(tmp);
                    stringlist.Add(tmpstr);
                }
                else if (filter == 2 && char.IsLetterOrDigit(tmpstr[0]))
                {
                    if (collapse) tmpstr = TPCore.CollapseSpaces(tmpstr);
                    if (tmpstr == " ") continue;
                    intlist.Add(tmp);
                    stringlist.Add(tmpstr);
                }
            }
            data = stringlist.ToArray();
            linenumbs = intlist.ToArray();
        }

        public static string CheckStartup(string cfile, string fname)
        {
            FCM cfg = new FCM();
            LNG lan = new LNG();
            string language = null;

            if (File.Exists("en.lng") && File.Exists("hu.lng"))
            {
                if (File.Exists(cfile))
                {
                    //Check language if config file found
                    if (cfg.ReadData(cfile, "lang") == "hu")
                    {
                        lan.SetLangFile("hu.lng");
                        language = "hu.lng";
                    }
                    else
                    {
                        lan.SetLangFile("en.lng");
                        language = "en.lng";
                    }
                    if (!File.Exists(cfg.ReadData(cfile, "sapath") + "gta_sa.exe"))
                    {
                        MessageBox.Show(lan.getlng(5) + " " + lan.getlng(4), lan.getlng(1),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                else
                {
                    if (MessageBox.Show("Angol nyelv? / English language?", "Question / Kérdés", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        lan.SetLangFile("en.lng");
                    else
                        lan.SetLangFile("hu.lng");
                    MessageBox.Show(lan.getlng(6) + " " + lan.getlng(4), lan.getlng(1),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show(
                    "Language files are missing, program shutting down!\n" +
                    "Nyelvi fájlok hiányoznak, a program leáll.",
                    "Fatal Error / Végzetes Hiba",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (!File.Exists(cfg.ReadData(cfile, "sapath") + fname))
            {
                MessageBox.Show(lan.getlng(9) + " " + fname
                    + "\n" + lan.getlng(4), lan.getlng(1),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return language;
        }

        public static string CheckStartup(string cfile)
        {
            FCM cfg = new FCM();
            LNG lan = new LNG();
            string language = null;

            if (File.Exists("en.lng") && File.Exists("hu.lng"))
            {
                if (File.Exists(cfile))
                {
                    //Check language if config file found
                    if (cfg.ReadData(cfile, "lang") == "hu")
                    {
                        lan.SetLangFile("hu.lng");
                        language = "hu.lng";
                    }
                    else
                    {
                        lan.SetLangFile("en.lng");
                        language = "en.lng";
                    }
                    if (!File.Exists(cfg.ReadData(cfile, "sapath") + "gta_sa.exe"))
                    {
                        MessageBox.Show(lan.getlng(5) + " " + lan.getlng(4), lan.getlng(1),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                else
                {
                    if (MessageBox.Show("Angol nyelv? / English language?", "Question / Kérdés", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        lan.SetLangFile("en.lng");
                    else
                        lan.SetLangFile("hu.lng");
                    MessageBox.Show(lan.getlng(6) + " " + lan.getlng(4), lan.getlng(1),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show(
                    "Language files are missing, program shutting down!\n" +
                    "Nyelvi fájlok hiányoznak, a program leáll.",
                    "Fatal Error / Végzetes Hiba",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return language;
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static string CollapseSpaces(string value)
        {
            value = Regex.Replace(value, @"\s+", " ");
            return value;
        }

        public static void ShowAboutBox(bool ishun)
        {
            if (ishun)
            {
                MessageBox.Show(
                    Properties.Resources.aboutbox_hu,
                    "About",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
            else
            {
                MessageBox.Show(
                    Properties.Resources.aboutbox_en,
                    "About",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
        }
    }

    public partial class LNG
    {
        string filename = null;

        public void SetLangFile(string fname)
        {
            filename = fname;
        }

        public string GetLangFile()
        {
            return filename;
        }

        public string getlng(int line)
        {
            using (var sr = new StreamReader(filename, Encoding.Default))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }
    }

    public partial class DataMGR
    {
        string datasource = null;

        public void SetDataSource(string input)
        {
            datasource = input;
        }

        public string[] ReadDataBlock(string block)
        {
            int i = 0;
            List<string> tmp = new List<string>();
            while (true)
            {
                i++;
                if (GetLine(datasource, i) == "*" + block) break;
                else if (GetLine(datasource, i) == null) return null;
            }
            while (true)
            {
                i++;
                if (GetLine(datasource, i) == "***") break;
                else if (GetLine(datasource, i) == null) return null;
                tmp.Add(GetLine(datasource, i));
            }
            return tmp.ToArray();
        }

        public string GetLine(string fileName, int line)
        {
            using (var sr = new StreamReader(fileName, Encoding.Default))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }
    }
}
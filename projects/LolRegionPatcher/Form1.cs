using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LolRegionPatcher
{
    public partial class Form1 : Form
    {

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        string filePath = "C:\\Riot Games\\League of Legends\\RADS\\system\\";
        string regionTextPath = "C:\\Riot Games\\League of Legends\\RADS\\projects\\lol_patcher\\managedfiles\\0.0.0.0\\";
        StringBuilder sb = new StringBuilder();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseDown += new MouseEventHandler(panel1_MouseDown);
            this.menuStrip.MouseDown += new MouseEventHandler(panel1_MouseDown);
            fileNameTextBox.Text = filePath;
            regionPathTextBox.Text = regionTextPath;

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void customButton3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Form.ActiveForm.Close();
        }

        private void customButton2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PatchButton_Click(object sender, EventArgs e)
        {

            string value = textBox1.Text;

            switch (value)
            {
                case "LAN":
                    using (StreamWriter localFile = new StreamWriter(filePath + @"\locale.cfg"))
                    {
                        sb.AppendLine("locale = en_us");
                        localFile.Write(sb.ToString());
                        sb.Clear();
                    }
                    using (StreamWriter launcherFile = new StreamWriter(filePath + @"\launcher.cfg"))
                    {
                        sb.AppendLine("airConfigProject = lol_air_client_config_la1");
                        sb.AppendLine("airProject = lol_air_client");
                        sb.AppendLine("gameProject = lol_game_client_sln");
                        sb.AppendLine("installation_id = wanAmg==");
                        launcherFile.Write(sb.ToString());
                        sb.Clear();
                    }
                    using (StreamWriter systemFile = new StreamWriter(filePath + @"\system.cfg"))
                    {
                        sb.AppendLine("DownloadPath = /releases/live");
                        sb.AppendLine("DownloadURL = l3cdn.riotgames.com");
                        sb.AppendLine("Region = LA1");
                        systemFile.Write(sb.ToString());
                        sb.Clear();
                    }
                    using (StreamWriter systemFile = new StreamWriter(regionTextPath + @"\regions.txt"))
                    {
                        sb.AppendLine("na,            na,            en_US, ");
                        sb.AppendLine("br,            br,            pt_BR,");
                        sb.AppendLine("tr,            tr,            tr_TR,");
                        sb.AppendLine("euw,           euw,           en_GB|de_DE|es_ES|fr_FR|it_IT,");
                        sb.AppendLine("eune,          eune,          en_GB|cs_CZ|el_GR|hu_HU|pl_PL|ro_RO,");
                        sb.AppendLine("ru,            ru,            ru_RU,");
                        sb.AppendLine("la1,           la1,           es_MX|en_US,");
                        sb.AppendLine("la2,           la2,           es_MX,");
                        sb.AppendLine("oc1,           oc1,           en_AU,");
                        systemFile.Write(sb.ToString());
                        sb.Clear();
                    }
                    MessageBox.Show("League has been patched to run on LAN!");
                    break;
                case "NA":
                    using (StreamWriter localFile = new StreamWriter(filePath + @"\locale.cfg"))
                    {
                        sb.AppendLine("locale=en_us");
                        localFile.Write(sb.ToString());
                        sb.Clear();
                    }
                    using (StreamWriter launcherFile = new StreamWriter(filePath + @"\launcher.cfg"))
                    {
                        sb.AppendLine("airConfigProject = lol_air_client_config_na");
                        sb.AppendLine("airProject = lol_air_client");
                        sb.AppendLine("gameProject = lol_game_client_sln");
                        sb.AppendLine("installation_id = wanAmg==");
                        launcherFile.Write(sb.ToString());
                        sb.Clear();
                    }
                    using (StreamWriter systemFile = new StreamWriter(filePath + @"\system.cfg"))
                    {
                        sb.AppendLine("DownloadPath = /releases/live");
                        sb.AppendLine("DownloadURL = l3cdn.riotgames.com");
                        sb.AppendLine("Region = NA");
                        systemFile.Write(sb.ToString());
                        sb.Clear();
                    }
                    using (StreamWriter systemFile = new StreamWriter(regionTextPath + @"\regions.txt"))
                    {
                        sb.AppendLine("na,            na,            en_US, ");
                        sb.AppendLine("br,            br,            pt_BR,");
                        sb.AppendLine("tr,            tr,            tr_TR,");
                        sb.AppendLine("euw,           euw,           en_GB|de_DE|es_ES|fr_FR|it_IT,");
                        sb.AppendLine("eune,          eune,          en_GB|cs_CZ|el_GR|hu_HU|pl_PL|ro_RO,");
                        sb.AppendLine("ru,            ru,            ru_RU,");
                        sb.AppendLine("la1,           la1,           es_MX|en_US,");
                        sb.AppendLine("la2,           la2,           es_MX,");
                        sb.AppendLine("oc1,           oc1,           en_AU,");
                        systemFile.Write(sb.ToString());
                        sb.Clear();
                    }
                    MessageBox.Show("League has been patched to run on NA!");
                    break;

                default:
                    MessageBox.Show("Error: " + textBox1.Text + " is not a supported server!");
                    break;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = folderBrowserDialog1.SelectedPath;
                fileNameTextBox.Text = filePath;
            }
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Currently only supports the following servers: NA, LAN.");
        }

        private void customButton4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                regionTextPath = folderBrowserDialog2.SelectedPath;
                regionPathTextBox.Text = regionTextPath;
            }
        }
    }
}

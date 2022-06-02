using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using WMPLib;
using System.IO;

namespace LED_Race
{
    public partial class Player : Form
    {
        // プレイヤー名入力画面

        WindowsMediaPlayer sound = new WindowsMediaPlayer();
        string pname = "";
        string[] pname_b = new string[20] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""};
        int[] pname_f = new int[20] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pname_f2 = new int[20] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int cnt = 0;
        static int time = 0;
        Boolean name_nmax = true;

        public Player()
        {
            InitializeComponent();
        }

        private void Player_select_button_Click(object sender, EventArgs e)
        {
            sound.URL = @"Accent41-2.mp3";
            sound.controls.play(); // 効果音を再生

            Program.TransferText_pname = label2.Text;

            // プレイヤー名の初期化
            pname = "";
            for(int i = 0; i < 20; i++)
            {
                pname_b[i] = "";
            }
            cnt = 0;

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F2_Player_select_button_Click"));
            file2.Close();

            timer1.Stop();
            time = 0;

            Player_select_button.Enabled = false;

            // ゲーム説明画面の表示
            intro1 intro1 = new intro1();
            intro1.Show();
            // プレイヤー名入力画面を隠す
            //Hide();
            this.Close();
        }

        private void Player_Load(object sender, EventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F2_Load"));
            file2.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "あ";
                label2.Text = pname;
                cnt++;
                if(cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "い";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "う";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "え";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "お";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "か";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "き";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "く";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "け";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "こ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "さ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "し";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "す";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "せ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "そ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "た";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "ち";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "つ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "て";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname += "と";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "な";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "に";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ぬ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ね";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "の";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname_f2[cnt] = 1;
                pname += "は";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname_f2[cnt] = 1;
                pname += "ひ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname_f2[cnt] = 1;
                pname += "ふ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname_f2[cnt] = 1;
                pname += "へ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname_f[cnt] = 1;
                pname_f2[cnt] = 1;
                pname += "ほ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ま";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "み";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "む";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "め";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "も";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "や";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ゆ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "よ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ら";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "り";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "る";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "れ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ろ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "わ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "を";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button51_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ん";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button52_Click(object sender, EventArgs e)
        {
            cnt--;
            if (cnt < 0)
            {
                cnt = 0;
            }
            label2.Text = pname_b[cnt];
            pname = pname_b[cnt];
            name_nmax = true;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button57_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "0";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "1";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "2";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "3";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "4";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "5";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button53_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "6";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button54_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "7";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button55_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "8";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button56_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "9";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button37_Click_1(object sender, EventArgs e)
        {
            if(cnt > 0)
            {
                if (pname_f2[cnt - 1] == 1)
                {
                    if (name_nmax)
                    {
                        pname_b[cnt] = pname;
                        pname += "゜";
                        label2.Text = pname;
                        cnt++;
                        if (cnt == 20)
                        {
                            name_nmax = false;
                        }
                    }

                }
            }
        }

        private void button39_Click_1(object sender, EventArgs e)
        {
            if(cnt > 0)
            {
                if (pname_f[cnt - 1] == 1)
                {
                    if (name_nmax)
                    {
                        pname_b[cnt] = pname;
                        pname += "゛";
                        label2.Text = pname;
                        cnt++;
                        if (cnt == 20)
                        {
                            name_nmax = false;
                        }
                    }

                }
            }
        }

        private void button49_Click_1(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ょ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button48_Click_1(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ゅ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button47_Click_1(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ゃ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
            
        }

        private void button56_Click_1(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ぁ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ぃ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
        }

        private void button57_Click_1(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ぅ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ぇ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
        }

        private void button60_Click(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ぉ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
        }

        private void button55_Click_1(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "っ";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
        }

        private void button54_Click_1(object sender, EventArgs e)
        {
            if (name_nmax)
            {
                pname_b[cnt] = pname;
                pname += "ー";
                label2.Text = pname;
                cnt++;
                if (cnt == 20)
                {
                    name_nmax = false;
                }
            }
        }

        private void button53_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F2_button53_Click"));
            file2.Close();

            button53.Enabled = false;

            // メニュー画面の表示
            Program.Menu_f = 2;
            Menu menu = new Menu();
            menu.Show();
            // この画面を隠す
            this.Close();
            //Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;

            if (time > 1)
            {
                Player_select_button.Enabled = true;
            }

            if (time > 180)
            {
                time = 0;
                timer1.Stop();

                // txtファイルの書き込み
                DateTime dt = DateTime.Now;
                string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

                StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
                file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F2_time == 180"));
                file2.Close();

                // 待機画面の表示
                Wait_Window wait = new Wait_Window();
                wait.Show();
                // この画面を隠す
                this.Close();
                //Hide();
            }
        }

        private void Player_FormClosing(object sender, FormClosingEventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F2_close"));

            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    Console.WriteLine("Application.Exitによる");
                    file2.WriteLine(string.Format("Application.Exitによる"));
                    break;
                case CloseReason.FormOwnerClosing:
                    Console.WriteLine("所有側のフォームが閉じられようとしている");
                    file2.WriteLine(string.Format("所有側のフォームが閉じられようとしている"));
                    break;
                case CloseReason.MdiFormClosing:
                    Console.WriteLine("MDIの親フォームが閉じられようとしている");
                    file2.WriteLine(string.Format("MDIの親フォームが閉じられようとしている"));
                    break;
                case CloseReason.TaskManagerClosing:
                    Console.WriteLine("タスクマネージャによる");
                    file2.WriteLine(string.Format("タスクマネージャによる"));
                    break;
                case CloseReason.UserClosing:
                    Console.WriteLine("ユーザインタフェースによる");
                    file2.WriteLine(string.Format("ユーザインタフェースによる"));
                    break;
                case CloseReason.WindowsShutDown:
                    Console.WriteLine("OSのシャットダウンによる");
                    file2.WriteLine(string.Format("OSのシャットダウンによる"));
                    break;
                case CloseReason.None:
                default:
                    Console.WriteLine("未知の理由");
                    file2.WriteLine(string.Format("未知の理由"));
                    break;
            }

            file2.Close();
        }
    }
}

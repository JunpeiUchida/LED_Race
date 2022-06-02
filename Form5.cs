using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.IO;

namespace LED_Race
{
    public partial class Result : Form
    {
        WindowsMediaPlayer sound = new WindowsMediaPlayer();

        private int duration = 0;

        public Result()
        {
            InitializeComponent();

            serialPort1.PortName = Program.port2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            duration = 0;

            //sound.URL = @"C:\Users\urbtg\OneDrive\Documents\塚本寺田研究室\科学館\Visual Studio\sound\Accent41-2.mp3";
            //sound.URL = @"C:\Users\S2\OneDrive\Documents\塚本寺田研究室\科学館\Visual Studio\sound\Accent41-2.mp3";
            sound.URL = @"C:\Users\s2-de\Documents\LEDレース\sound\Accent41-2.mp3";
            sound.controls.play(); // 効果音を再生

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F5_button1_Click"));
            file2.Close();

            button1.Enabled = false;

            // 次の画面の表示
            Past_rest past = new Past_rest();
            past.Show();
            // この画面を隠す
            this.Close();
            //Hide();
            //Application.Exit();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label2.Text = Program.TransferText_rest;
            //label2.Text = Program.rest[Program.cnt].ToString(@"mm\:ss\.ff");
            string result1 = Convert.ToString(Program.rest[0]); // int型をstring型に
            serialPort1.Open();
            serialPort1.Write(result1 + "\n"); // Arduino2に1回目の時間を送信（ミリ秒表記の文字列で）
            serialPort1.Close();

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F5_Load"));
            file2.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Application.Exit();

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F5_button2_Click"));
            file2.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (duration == 1)
            {
                label1.Visible = true;
            }
            else if(duration == 2)
            {
                label2.Visible = true;
            }
            else if(duration == 3)
            {
                if(Program.cnt == 0)
                {
                    if(Program.rest[0] > Program.rest[1])
                    {
                        label3.Visible = true;
                    }
                    else if(Program.rest[0] < Program.rest[1])
                    {
                        label3.Text = "記録更新ならず..残念..";
                        label3.Visible = true;
                    }
                }
            }
            else if(duration == 7) //5秒経過すると自動で遷移
            {
                duration = 0;

                //sound.URL = @"C:\Users\urbtg\OneDrive\Documents\塚本寺田研究室\科学館\Visual Studio\sound\Accent41-2.mp3";
                //sound.URL = @"C:\Users\S2\OneDrive\Documents\塚本寺田研究室\科学館\Visual Studio\sound\Accent41-2.mp3";
                sound.URL = @"C:\Users\s2-de\Documents\LEDレース\sound\Accent41-2.mp3";
                sound.controls.play(); // 効果音を再生

                timer1.Stop();

                // 次の画面の表示
                Past_rest past = new Past_rest();
                past.Show();
                // この画面を隠す
                this.Close();
                //Hide();
            }

            if (duration > 3) // 結果は点滅
            {
                if(Program.cnt == 0)
                {
                    label3.Visible = !label3.Visible;
                }
                
            }
            duration++;
        }

        private void button53_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            duration = 0;

            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }

            // メニュー画面の表示
            Program.Menu_f = 5;
            Menu menu = new Menu();
            menu.Show();
            // この画面を隠す
            this.Close();
            //Hide();
        }

        private void Result_FormClosing(object sender, FormClosingEventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F5_close"));

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

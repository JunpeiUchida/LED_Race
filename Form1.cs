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
    public partial class Wait_Window : Form
    {
        // 待機画面

        WindowsMediaPlayer sound = new WindowsMediaPlayer();
        string ledflag1 = "3";
        string ledflag2 = "0";
        string ledflag3 = "7";
        static int time = 0;

        public Wait_Window()
        {
            InitializeComponent();
            Program.first_check++;
            if(Program.first_check > 2)
            {
                Program.first_check = 2;
            }

            serialPort1.PortName = Program.port1;
            serialPort2.PortName = Program.port2;
        }

        private void Wait_Window_Load(object sender, EventArgs e)
        {
            timer1.Start();

            Program.cnt = 0;
            Program.end_f = false;

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F1_Load"));
            file2.Close();

            serialPort1.Open();
            string wait = Convert.ToString(ledflag1); // int型をstring型に
            serialPort1.Write(wait + "\n"); // 送信データを書き込み(COM番号注意!)
            serialPort1.Close(); //このタイミングでポートを閉じる

            serialPort2.Open();
            string wait2 = Convert.ToString(ledflag2); // int型をstring型に
            serialPort2.Write(wait2 + "\n"); // 送信データを書き込み(COM番号注意!)
            serialPort2.Close(); //このタイミングでポートを閉じる
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if (time == 60) // 60秒ごとに同期
            {
                time = 0;
                serialPort1.Open();
                string wait = Convert.ToString(ledflag1); // int型をstring型に
                serialPort1.Write(wait + "\n"); // 送信データを書き込み(COM番号注意!)
                serialPort1.Close(); //このタイミングでポートを閉じる

                serialPort2.Open();
                string wait2 = Convert.ToString(ledflag2); // int型をstring型に
                serialPort2.Write(wait2 + "\n"); // 送信データを書き込み(COM番号注意!)
                serialPort2.Close(); //このタイミングでポートを閉じる

                // txtファイルの書き込み
                DateTime dt = DateTime.Now;
                string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

                StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
                file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F1_time_passed"));
                file2.Close();
            }
            label1.Visible = !label1.Visible; // ラベルの表示・非表示を1秒おきに入れ替える（点滅のアニメーション）
        }

        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            serialPort1.Open();
            string wait_close = Convert.ToString(ledflag3); // int型をstring型に
            serialPort1.Write(wait_close + "\n"); // 送信データを書き込み(COM番号注意!)
            serialPort1.Close(); //このタイミングでポートを閉じる

            serialPort2.Open();
            string wait_close2 = Convert.ToString(ledflag3); // int型をstring型に
            serialPort2.Write(wait_close2 + "\n"); // 送信データを書き込み(COM番号注意!)
            serialPort2.Close(); //このタイミングでポートを閉じる

            sound.URL = @"Accent41-2.mp3";
            sound.controls.play(); // 効果音を再生

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F1_label1_Click"));
            file2.Close();

            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Close();
            }

            label1.Enabled = false;

            // プレイヤー名入力画面の表示
            Player player = new Player();
            player.Show();
            // 待機画面を隠す
            this.Close();
        }

        private void Wait_Window_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            serialPort1.Open();
            string wait_close = Convert.ToString(ledflag3); // int型をstring型に
            serialPort1.Write(wait_close + "\n"); // 送信データを書き込み(COM番号注意!)
            serialPort1.Close(); //このタイミングでポートを閉じる

            serialPort2.Open();
            string wait_close2 = Convert.ToString(ledflag3); // int型をstring型に
            serialPort2.Write(wait_close2 + "\n"); // 送信データを書き込み(COM番号注意!)
            serialPort2.Close(); //このタイミングでポートを閉じる

            sound.URL = @"Accent41-2.mp3";
            sound.controls.play(); // 効果音を再生

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F1_Wait_Window_Click"));
            file2.Close();

            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Close();
            }

            // プレイヤー名入力画面の表示
            Player player = new Player();
            player.Show();
            // 待機画面を隠す
            this.Close();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            serialPort1.Open();
            string wait_close = Convert.ToString(ledflag3); // int型をstring型に
            serialPort1.Write(wait_close + "\n"); // 送信データを書き込み(COM番号注意!)
            serialPort1.Close(); //このタイミングでポートを閉じる

            serialPort2.Open();
            string wait_close2 = Convert.ToString(ledflag3); // int型をstring型に
            serialPort2.Write(wait_close2 + "\n"); // 送信データを書き込み(COM番号注意!)
            serialPort2.Close(); //このタイミングでポートを閉じる

            sound.URL = @"Accent41-2.mp3";
            sound.controls.play(); // 効果音を再生

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F1_Wait_Window_Click"));
            file2.Close();

            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Close();
            }

            panel1.Enabled = false;

            // プレイヤー名入力画面の表示
            Player player = new Player();
            player.Show();
            // 待機画面を隠す
            this.Close();
        }

        private void Wait_Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F1_close"));

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

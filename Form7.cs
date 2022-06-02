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
    public partial class Next : Form
    {
        // 折り返し画面

        static int time = 0;

        WindowsMediaPlayer sound = new WindowsMediaPlayer();

        public Next()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sound.URL = @"C:\Users\s2-de\Documents\LEDレース\sound\Accent41-2.mp3";
            sound.controls.play(); // 効果音を再生

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F7_button1_Click"));
            file2.Close();

            timer1.Stop();
            time = 0;

            button1.Enabled = false;

            // ゲーム2の説明画面の表示
            game2_intro intro_g2 = new game2_intro();
            intro_g2.Show();
            // メイン画面を隠す
            this.Close();
        }

        private void Next_Load(object sender, EventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F7_Load"));
            file2.Close();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            time = 0;

            button53.Enabled = false;

            // メニュー画面の表示
            Program.Menu_f = 7;
            Menu menu = new Menu();
            menu.Show();
            // この画面を隠す
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;

            if (time > Program.delay)
            {
                button1.Enabled = true;
            }

            if(time == 3)
            {
                timer1.Stop();
                time = 0;

                // ゲーム2の説明画面の表示
                game2_intro intro_g2 = new game2_intro();
                intro_g2.Show();
                // メイン画面を隠す
                this.Close();
            }

            if (time > 180)
            {
                time = 0;
                timer1.Stop();

                // 待機画面の表示
                Wait_Window wait = new Wait_Window();
                wait.Show();
                // この画面を隠す
                this.Close();
            }
        }

        private void Next_FormClosing(object sender, FormClosingEventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F7_close"));

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

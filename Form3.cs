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
    public partial class Game_Inst : Form
    {
        static int time = 0;

        WindowsMediaPlayer sound = new WindowsMediaPlayer();

        public Game_Inst()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sound.URL = @"C:\Users\urbtg\OneDrive\Documents\塚本寺田研究室\科学館\Visual Studio\sound\Accent41-2.mp3";
            //sound.URL = @"C:\Users\S2\OneDrive\Documents\塚本寺田研究室\科学館\Visual Studio\sound\Accent41-2.mp3";
            sound.URL = @"C:\Users\s2-de\Documents\LEDレース\sound\Accent41-2.mp3";
            sound.controls.play(); // 効果音を再生

            //Application.Exit();
            // this.Close();
            // プレイヤー名入力画面の表示
            //Wait_Window wait = new Wait_Window();
            //wait.Show(this);

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3_button2_Click"));
            file2.Close();

            timer1.Stop();
            time = 0;

            button2.Enabled = false;

            /*// カウントダウン画面の表示
            CountDown countdown = new CountDown();
            countdown.Show(this);
            // ゲーム説明画面を隠す
            Hide();*/

            // メイン画面の表示
            Main main = new Main();
            main.Show();
            // カウントダウン画面を隠す
            //Hide();
            this.Close();
        }

        private void Game_Inst_Load(object sender, EventArgs e)
        {
            Player_Name.Text = Program.TransferText_pname;
            if(Program.cnt == 1)
            {
                result.Text = Program.TransferText_rest;
            }

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3_Load"));
            file2.Close();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            time = 0;

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3_button53_Click"));
            file2.Close();

            button53.Enabled = false;

            // メニュー画面の表示
            Program.Menu_f = 3;
            Menu menu = new Menu();
            menu.Show();
            // この画面を隠す
           // Hide();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;

            if (time > Program.delay)
            {
                button2.Enabled = true;
            }

            if (time > 180)
            {
                time = 0;
                timer1.Stop();

                // txtファイルの書き込み
                DateTime dt = DateTime.Now;
                string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

                StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
                file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3_time == 180"));
                file2.Close();

                // 待機画面の表示
                Wait_Window wait = new Wait_Window();
                wait.Show();
                // この画面を隠す
                this.Close();
                // Hide();
            }

            // ゲームの説明動画を表示

        }

        private void Game_Inst_FormClosing(object sender, FormClosingEventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3_close"));

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

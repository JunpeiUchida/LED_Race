using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LED_Race
{
    public partial class intro2 : Form
    {
        // ゲーム説明画面2

        static int time = 0;

        public intro2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.2_button2_Click"));
            file2.Close();

            timer1.Stop();
            time = 0;

            button2.Enabled = false;

            // 3.1画面の表示
            intro1 intro1 = new intro1();
            intro1.Show();
            // 3.2画面を隠す
            this.Close();
            //Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.2_button1_Click"));
            file2.Close();

            timer1.Stop();
            time = 0;

            button1.Enabled = false;

            // 3.3画面の表示
            game1_intro intro_g1 = new game1_intro();
            intro_g1.Show();
            // 3.2画面を隠す
            this.Close();
            //Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;

            if (time > Program.delay)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }

            if(time == 10)
            {
                // txtファイルの書き込み
                DateTime dt = DateTime.Now;
                string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

                StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
                file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.2_time == 4"));
                file2.Close();

                timer1.Stop();
                time = 0;

                // 3.3画面の表示
                game1_intro intro_g1 = new game1_intro();
                intro_g1.Show();
                // 3.2画面を隠す
                this.Close();
                //Hide();
            }

            if (time > 180)
            {
                time = 0;
                timer1.Stop();

                // txtファイルの書き込み
                DateTime dt = DateTime.Now;
                string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

                StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
                file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.2_time == 180"));
                file2.Close();

                // 待機画面の表示
                Wait_Window wait = new Wait_Window();
                wait.Show();
                // この画面を隠す
                this.Close();
                //Hide();
            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.2_button53_Click"));
            file2.Close();

            timer1.Stop();

            button53.Enabled = false;

            // メニュー画面の表示
            Program.Menu_f = 3.2;
            Menu menu = new Menu();
            menu.Show();
            // この画面を隠す
            this.Close();
            //Hide();
        }

        private void intro2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.2_close"));

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

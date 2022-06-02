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
    public partial class intro1 : Form
    {
        // ゲーム説明画面1

        static int time = 0;

        public intro1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.1_button1_Click"));
            file2.Close();

            timer1.Stop();
            time = 0;

            button1.Enabled = false;

            // 3.2画面の表示
            intro2 intro2 = new intro2();
            intro2.Show();
            // ゲーム説明画面を隠す
            this.Close();
            //Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;

            if(time > Program.delay)
            {
                button1.Enabled = true;
            }
            
            if(time == 10)
            {
                timer1.Stop();
                time = 0;

                // txtファイルの書き込み
                DateTime dt = DateTime.Now;
                string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

                StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
                file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.1_time == 4"));
                file2.Close();

                // 3.2画面の表示
                intro2 intro2 = new intro2();
                intro2.Show();
                // ゲーム説明画面を隠す
                this.Close();
                //Hide();
            }

            if (time > 180)
            {
                // txtファイルの書き込み
                DateTime dt = DateTime.Now;
                string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

                StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
                file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.1_time == 180"));
                file2.Close();

                time = 0;
                timer1.Stop();

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
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.1_button53_Click"));
            file2.Close();

            timer1.Stop();

            button53.Enabled = false;

            // メニュー画面の表示
            Program.Menu_f = 3.1;
            Menu menu = new Menu();
            menu.Show();
            // この画面を隠す
            this.Close();
            //Hide();
        }

        private void intro1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.1_close"));

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

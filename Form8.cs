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
using WMPLib;

namespace LED_Race
{
    public partial class End : Form
    {
        WindowsMediaPlayer sound = new WindowsMediaPlayer();

        static int cnt = 0;

        public End()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Program.end_f = false;

            DateTime dt = DateTime.Now;

            //string filename = @"C:\Users\urbtg\OneDrive\Documents\塚本寺田研究室\科学館\Visual Studio\csv\" + dt.ToString("yyyyMMddHHmmss") + ".csv";
            //string filename = @"C:\Users\S2\OneDrive\Documents\塚本寺田研究室\科学館\Visual Studio\csv\" + dt.ToString("yyyyMMddHHmmss") + ".csv";
            string filename = @"C:\Users\s2-de\Documents\LEDレース\csv\" + dt.ToString("yyyyMMddHHmmss") + ".csv";
            StreamWriter file = new StreamWriter(filename, false, Encoding.UTF8);

            file.WriteLine(string.Format("{0}, {1}", "player_name", Program.TransferText_pname));
            file.WriteLine(string.Format("{0}, {1}", "cnt", "Result"));
            for (int i = 0; i < 2; i++)
            {
                file.WriteLine(string.Format("{0},{1}", i + 1, Program.rest[i]));
            }

            file.WriteLine(string.Format("{0}, {1}, {2}", "cnt", "today", "past"));
            for (int i = 0; i < 5; i++)
            {
                file.WriteLine(string.Format("{0}, {1}, {2}", i + 1, Program.today[i], Program.past[i]));
            }
            file.WriteLine(string.Format("{0}, {1}", "mode", Program.startf2));
            file.WriteLine("{0}, {1}, {2}", "time", "1回目", "2回目");
            for (int i = 0; i < Program.data_num; i++) // ボタンを押したタイミングをすべて記録
            {
                file.WriteLine(string.Format("{0}, {1}, {2}", i + 1, Program.rest_t1[i].Replace("\n", "").Replace("\r", ""), Program.rest_t2[i].Replace("\n", "").Replace("\r", ""))); // 何回かボタンを押した後Form4のまま放置されて待機画面に戻った場合、Program.rest_t2[]はnullなのでオブジェクト参照エラーが起きる
                Console.WriteLine(Program.rest_t1[i].Replace("\n", "").Replace("\r", "")); // 改行文字の削除
                Console.WriteLine(Program.rest_t2[i].Replace("\n", "").Replace("\r", ""));
            }
            file.Close();

            // txtファイルの書き込み
            DateTime dt1 = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt1.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt1.ToString("yyyyMMddHHmmss"), "F8_Load"));
            file2.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
            cnt++;

            if(cnt == 5)    // 5秒経過したら
            {
                timer1.Stop();
                cnt = 0;

                // 待機画面へ
                Wait_Window wait = new Wait_Window();
                wait.Show();
                // この画面を隠す
                this.Close();
                //Hide();
            }
        }

        private void End_FormClosing(object sender, FormClosingEventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F8_close"));

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

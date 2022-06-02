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
    public partial class CountDown : Form
    {
        WindowsMediaPlayer sound = new WindowsMediaPlayer();

        private int duration = 3;

        public CountDown()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(duration == 0)
            {
                timer1.Stop();
                duration = 3;

                // メイン画面の表示
                Main main = new Main();
                main.Show();
                // カウントダウン画面を隠す
                //Hide();
                this.Close();
            }
            else if(duration == 1)
            {
                label1.Text = "";
                label2.Text = "スタート！";
                duration--;
            }
            else if(duration > 1)
            {
                duration--;
                label1.Text = duration.ToString();
            }
        }

        private void CountDown_Load(object sender, EventArgs e)
        {
            timer1.Start();

            //sound.URL = @"C:\Users\urbtg\OneDrive\Documents\塚本寺田研究室\科学館\Visual Studio\sound\Countdown06-2.mp3";
            //sound.URL = @"C:\Users\S2\OneDrive\Documents\塚本寺田研究室\科学館\Visual Studio\sound\Countdown06-2.mp3";
            sound.URL = @"C:\Users\s2-de\Documents\LEDレース\sound\Countdown06-2.mp3";
            sound.controls.play(); // 効果音を再生
            //new EventHandler(timer1_Tick);

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.5_Load"));
            file2.Close();
        }

        private void CountDown_FormClosing(object sender, FormClosingEventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F3.5_close"));

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

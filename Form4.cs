using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using WMPLib;
using System.IO;

namespace LED_Race
{
    public partial class Main : Form
    {
        // ゲーム画面

        static int time = 0;

        WindowsMediaPlayer sound = new WindowsMediaPlayer();

        public string str;
        string startflag1 = "1";
        string startflag2 = "2";
        //static int cnt = 0;
        static int cn = 0;
        static Boolean tstart = false;

        //時間経過をはかるためのクラス
        Stopwatch myStopWatch = new Stopwatch();


        public Main()
        {
            InitializeComponent();

            serialPort1.PortName = Program.port1;
            serialPort2.PortName = Program.port2;
            //serialPort1.Open();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Player_Name.Text = Program.TransferText_pname;
            if(Program.cnt == 1)
            {
                result.Text = Program.TransferText_rest;
            }
            label4.Visible = true;

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F4_Load"));
            file2.Close();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            str = serialPort1.ReadLine(); 
            if(Program.cnt == 0)
            {
                Program.rest_t1[cn] = str; 
                Console.WriteLine(Program.rest_t1[cn]);
            }
            else if(Program.cnt == 1)
            {
                Program.rest_t2[cn] = str; 
                Console.WriteLine(Program.rest_t2[cn]);
            }
            
            cn++; // 

            //時間計測中の場合
            if (cn == Program.data_num) // sw == true
            {
                cn = 0;

                //計測終了
                myStopWatch.Stop();
                //表示固定
                timer1.Stop();
                //結果保存
                Program.rest[Program.cnt] = myStopWatch.ElapsedMilliseconds; // 経過時間をミリ秒単位で取得
                Console.WriteLine(Program.rest[Program.cnt]);
                serialPort1.Close(); //このタイミングでポートを閉じる

                this.Invoke(new EventHandler(Check_input));
            }

            //this.Invoke(new EventHandler(Check_input));
        }

        private void Check_input(object sender, EventArgs e)
        {
            Program.TransferText_rest = myStopWatch.Elapsed.ToString(@"mm\:ss\.ff"); // 結果をstring型で保持
            Console.WriteLine(Program.TransferText_rest);
            Console.WriteLine("rest[{0}] = {1}", Program.cnt, Program.rest[Program.cnt]); // コンソールに表示
            Program.cnt++;
            if(Program.cnt == 2)
            {
                Program.cnt = 0;
            }

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F4_Check_input"));
            file2.Close();

            time = 0;
            timer1.Stop();

            // 結果画面の表示
            Result result = new Result();
            result.Show();
            // メイン画面を隠す
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Application.Exit();

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F4_button2_Click"));
            file2.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            //label6.Text = Convert.ToString(time);

            if(time == 10)
            {
                label4.Text = "よーい";
                label4.Visible = true;
            }
            else if(time == 20)
            {
                label5.Text = "スタート！";
                label4.Visible = false;
                label5.Visible = true;

                if(Program.cnt == 1)
                {
                    Random flag2 = new System.Random();
                    Program.startf2 = flag2.Next(2, 7);
                    string start2 = Convert.ToString(Program.startf2); 
                    serialPort2.Open();
                    serialPort2.Write(start2 + "\n");
                    serialPort2.Close();
                }

                sound.URL = @"C:\Users\s2-de\Documents\LEDレース\sound\Countdown06-6.mp3";
                sound.controls.play(); // 効果音を再生
            }
            else if(time == 30)
            {
                tstart = true;
                label5.Visible = false;
                label3.Visible = true;
            }

            if (tstart)
            {
                if (Program.cnt == 0)
                {
                    string start = Convert.ToString(startflag1); // int型をstring型に
                    serialPort1.Open();
                    serialPort1.Write(start + "\n"); // 送信データを書き込み
                }
                else if (Program.cnt == 1)
                {
                    //result.Text = Program.TransferText_rest;
                    Program.end_f = true;
                    string start1 = Convert.ToString(startflag2); // int型をstring型に
                    serialPort1.Open();
                    serialPort1.Write(start1 + "\n"); // 送信データを書き込み
                }

                //時間計測開始
                myStopWatch.Start();
                //表示更新タイマー開始
                timer1.Start();
                //スイッチon
                //sw = true;

                tstart = false;
            }

            if(time > 30)
            {
                //label3にスタートから現在までの時間を表示させる
                label3.Text = myStopWatch.Elapsed.ToString(@"mm\:ss\.ff");

                if(time > 1800) 
                {
                    time = 0;
                    timer1.Stop();
                    serialPort1.Close(); 
                    cn = 0; 
                    Program.cnt = 0; 

                    // txtファイルの書き込み
                    DateTime dt = DateTime.Now;
                    string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

                    StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
                    file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F4_time == 180"));
                    file2.Close();

                    // 待機画面の表示
                    Wait_Window wait = new Wait_Window();
                    wait.Show();
                    // この画面を隠す
                    this.Close();
                }
            }

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F4_close"));

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

        private void button53_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            time = 0;
            cn = 0;
            if(serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Close();
            }

            button53.Enabled = false;

            // メニュー画面の表示
            Program.Menu_f = 4;
            Menu menu = new Menu();
            menu.Show();
            // この画面を隠す
            this.Close();
        }
    }
}

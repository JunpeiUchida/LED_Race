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
        static int time = 0;

        WindowsMediaPlayer sound = new WindowsMediaPlayer();

        //private string sendData = "";
        //public Player player;
        public string str;
        string startflag1 = "1";
        string startflag2 = "2";
        //static int cnt = 0;
        static int cn = 0;
        static Boolean tstart = false;

        //時間経過をはかるためのクラス
        Stopwatch myStopWatch = new Stopwatch();
        //スタート・ストップボタン用
        //Boolean sw = false;


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

            //Console.WriteLine(Program.cnt);

            /*string start = Convert.ToString(startflag1); // int型をstring型に
            serialPort1.Write(start); // 送信データを書き込み(COM番号注意!)
            serialPort1.Close();*/

            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F4_Load"));
            file2.Close();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            str = serialPort1.ReadLine(); // arduino側でのボタン押下タイム
            //int str_i = Convert.ToInt32(str); // 
            if(Program.cnt == 0)
            {
                Program.rest_t1[cn] = str; // 
                Console.WriteLine(Program.rest_t1[cn]);
            }
            else if(Program.cnt == 1)
            {
                Program.rest_t2[cn] = str; // 
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
                //cnt++;
                //スイッチoff
                //sw = false;
                ////リセットボタン使用可
                //button2.Enabled = true;
                //「ストップ」だったラベル4の表示を「スタート」に変更
                //label4.Text = "スタート";
                serialPort1.Close(); //このタイミングでポートを閉じる

                this.Invoke(new EventHandler(Check_input));
            }

            //this.Invoke(new EventHandler(Check_input));
        }

        private void Check_input(object sender, EventArgs e)
        {
            /*if (Convert.ToDouble(str) < 100) // LEDが全点灯するまでの時間が100s以内であればアプリを閉じる
            {
                
            }*/

            //Program.TransferText_rest = label3.Text; // 結果をstring型で保持
            Program.TransferText_rest = myStopWatch.Elapsed.ToString(@"mm\:ss\.ff"); // 結果をstring型で保持
            Console.WriteLine(Program.TransferText_rest);
            //Program.rest[cnt] = Convert.ToDouble(label3.Text); // 結果をint型で保持（1回目と2回目それぞれ）
            //Program.rest[cnt] = myStopWatch.ElapsedMilliseconds; // 経過時間をミリ秒単位で取得
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
            //Hide();
            //Application.Exit();
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
                    string start2 = Convert.ToString(Program.startf2); // int型をstring型に
                    serialPort2.Open(); // arduino1とarduino2の同期をより正確にするために
                    serialPort2.Write(start2 + "\n"); // arduinoのsignal(1:d4-2:d3)は使わずにシリアル通信
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
                    serialPort1.Write(start + "\n"); // 送信データを書き込み(COM番号注意!)
                }
                else if (Program.cnt == 1)
                {
                    //result.Text = Program.TransferText_rest;
                    Program.end_f = true;
                    string start1 = Convert.ToString(startflag2); // int型をstring型に
                    serialPort1.Open();
                    serialPort1.Write(start1 + "\n"); // 送信データを書き込み(COM番号注意!)
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

                if(time > 1800) // timerイベントは100msごとに実行されるので、180ではなく1800!!!
                {
                    time = 0;
                    timer1.Stop();
                    serialPort1.Close(); // ここでポートを閉じないと待機画面遷移後にポートエラーが起きる
                    cn = 0; // cnをリセットしないと、何回か押した後に放置された場合に次にやる時ボタンを50回より少ない回数押すとクリアになってしまう
                    Program.cnt = 0; // これもリセットしないと、待機画面に戻った次のタイミングでエラーが起きる（例えば、2回目のForm4で180秒経過し待機画面に戻った場合、Program.cntは1のままなので、データがすべて2回目のほうとして記録され（クリアはしていない）、end_fはForm4でtrueになるのでForm6で2回目のクリアタイムを使おうとするが、クリアタイムがないため0と表示され、Form8（Form7にはいかない）でcsv保存する時にデータがなくてオブジェクト参照エラー（null参照エラー）が起きる）

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
                    // Hide();
                }
            }

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) //フォームが閉じられようとしている理由をコンソールに表示
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
            //Hide();
        }

        /*private void Main_shown(object sender, EventArgs e)
        {
            Player_Name.Text = Program.TransferText;
        }*/
    }
}

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
    public partial class Past_rest : Form
    {
        //WindowsMediaPlayer sound = new WindowsMediaPlayer();
        private System.Windows.Forms.Label[] tlabel;

        static int cnt = 0;
        static int cnt1 = 0;
        static int cnt2 = 0;

        public Past_rest()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt++;

            if(cnt == 3)
            {
                for (int n = 0; n < 5; n++) // 更新された記録の表示
                {
                    tlabel[n].Text = Program.today_name[n];
                    tlabel[n + 10].Text = Program.past_name[n];
                    if (Program.today[n] == -1)
                    {
                        tlabel[n + 5].Text = "-";
                    }
                    else
                    {
                        tlabel[n + 5].Text = Convert.ToString(Math.Round(Program.today[n] / 1000.00, 2, MidpointRounding.AwayFromZero));
                    }

                    if (Program.past[n] == -1)
                    {
                        tlabel[n + 15].Text = "-";
                    }
                    else
                    {
                        tlabel[n + 15].Text = Convert.ToString(Math.Round(Program.past[n] / 1000.00, 2, MidpointRounding.AwayFromZero));
                    }
                }
            }

            else if(cnt == 7)   // 7秒経過したら
            {
                timer1.Stop();
                cnt = 0;

                // 次の画面の表示
                if(Program.end_f == true)
                {
                    // 終了画面へ
                    End end = new End();
                    end.Show();
                    // この画面を隠す
                    this.Close();
                    //Hide();
                }
                else if(Program.end_f == false)
                {
                    // もう一度画面へ
                    Next next = new Next();
                    next.Show();
                    // この画面を隠す
                    this.Close();
                    //Hide();
                }
            }
        }

        private void Past_rest_Load(object sender, EventArgs e)
        {
            // cnt = 0;
            timer1.Start();

            this.tlabel = new System.Windows.Forms.Label[20];

            this.tlabel[0] = this.label1;
            this.tlabel[1] = this.label2;
            this.tlabel[2] = this.label3;
            this.tlabel[3] = this.label4;
            this.tlabel[4] = this.label5;
            this.tlabel[5] = this.label6;
            this.tlabel[6] = this.label7;
            this.tlabel[7] = this.label8;
            this.tlabel[8] = this.label9;
            this.tlabel[9] = this.label10;
            this.tlabel[10] = this.label11;
            this.tlabel[11] = this.label12;
            this.tlabel[12] = this.label13;
            this.tlabel[13] = this.label14;
            this.tlabel[14] = this.label15;
            this.tlabel[15] = this.label16;
            this.tlabel[16] = this.label17;
            this.tlabel[17] = this.label18;
            this.tlabel[18] = this.label19;
            this.tlabel[19] = this.label20;

            // pastファイルの読み込み
            //string filename = @"C:\Users\S2\OneDrive\Documents\塚本寺田研究室\科学館\Visual Studio\csv\result.csv";
            //string filename = @"C:\Users\urbtg\OneDrive\Documents\塚本寺田研究室\科学館\Visual Studio\csv\result.csv";
            string filename = @"C:\Users\s2-de\Documents\LEDレース\csv\past.csv";
            StreamReader file = new StreamReader(filename);

            int i = 0;

            while (!file.EndOfStream) // past.csvから過去のtop5を読み込み
            {
                string line = file.ReadLine();
                string[] values = line.Split(',');

                if (i == 1)
                {
                    for (int j = 1; j < 6; j++)
                    {
                        Program.past_name[j - 1] = values[j].Trim(); // 空白文字を取り除く（csvに出力すると先頭に空白文字が付いてしまうため）
                    }
                }
                else if (i == 2)
                {
                    cnt1 = 0;

                    for (int j = 1; j < 6; j++)
                    {
                        Program.past[j - 1] = Convert.ToInt32(values[j]);
                        if (Program.past[j - 1] == -1)
                        {
                            cnt1++; // 5 - cnt1個のデータをソートする
                        }
                    }
                }

                i++;
            }
            file.Close();

            // todayファイルの読み込み
            DateTime dt = DateTime.Now;
            string filename1 = @"C:\Users\s2-de\Documents\LEDレース\csv\result" + dt.ToString("yyyyMMdd") + ".csv";

            if (File.Exists(filename1)) // todayファイルが存在する場合
            {
                StreamReader file1 = new StreamReader(filename1);

                int i1 = 0;
                while (!file1.EndOfStream) // result.csvから今日のtop5と過去のtop5を読み込み
                {
                    string line = file1.ReadLine();
                    string[] values = line.Split(',');

                    if (i1 == 1)
                    {
                        for (int j = 1; j < 6; j++)
                        {
                            Program.today_name[j - 1] = values[j].Trim(); // 空白文字を取り除く（csvに出力すると先頭に空白文字が付いてしまうため）
                        }
                    }
                    else if (i1 == 2)
                    {
                        cnt2 = 0;

                        for (int j = 1; j < 6; j++)
                        {
                            Program.today[j - 1] = Convert.ToInt32(values[j]);
                            if (Program.today[j - 1] == -1)
                            {
                                cnt2++;
                            }
                        }
                    }

                    i1++;
                }
                file1.Close();
            }
            else // todayファイルが存在しない場合
            {
                for (int n = 0; i < 6; i++) // 初期化
                {
                    Program.today_name[n] = "-";
                    Program.today[n] = -1;
                }


                StreamWriter file1 = new StreamWriter(filename1, false, Encoding.UTF8);
                file1.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}", "cnt", 1, 2, 3, 4, 5));
                file1.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}", "today", Program.today_name[0], Program.today_name[1], Program.today_name[2], Program.today_name[3], Program.today_name[4]));
                file1.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}", "", Program.today[0], Program.today[1], Program.today[2], Program.today[3], Program.today[4]));
                file1.Close();

                cnt2 = 5;
            }




            for (int n = 0; n < 5; n++) // 記録の表示
            {
                tlabel[n].Text = Program.today_name[n];
                tlabel[n + 10].Text = Program.past_name[n];
                if (Program.today[n] == -1)
                {
                    tlabel[n + 5].Text = "-";
                }
                else
                {
                    tlabel[n + 5].Text = Convert.ToString(Math.Round(Program.today[n] / 1000.00, 2, MidpointRounding.AwayFromZero));
                }

                if (Program.past[n] == -1)
                {
                    tlabel[n + 15].Text = "-";
                }
                else
                {
                    tlabel[n + 15].Text = Convert.ToString(Math.Round(Program.past[n] / 1000.00, 2, MidpointRounding.AwayFromZero));
                }
            }

            // 今回の結果を配列の最後尾に追加
            if (Program.end_f == false)
            {
                Program.today[5 - cnt2] = Program.rest[0];
                Program.past[5 - cnt1] = Program.rest[0];
                Program.today_name[5 - cnt2] = Program.TransferText_pname;
                Program.past_name[5 - cnt1] = Program.TransferText_pname;
                sort(cnt1, cnt2);
            }
            else if (Program.end_f == true)
            {
                if (Program.rest[0] > Program.rest[1])
                {
                    bool f1 = true;
                    bool f2 = true;

                    for(int j = 0; j < 5 - cnt2; j++)
                    { 
                        if(Program.today[j] == Program.rest[0] && Program.today_name[j] == Program.TransferText_pname)
                        {
                            Program.today[j] = Program.rest[1];
                            cnt2 = 5 - j; // ソートする必要があるのは前回の順位以上のデータのみ
                            f2 = false;
                        }
                        if(Program.past[j] == Program.rest[0] && Program.past_name[j] == Program.TransferText_pname)
                        {
                            Program.past[j] = Program.rest[1];
                            cnt1 = 5 - j;
                            f1 = false;
                        }
                    }
                    if(f1) // top5にない場合
                    {
                        Program.past[5 - cnt1] = Program.rest[1];
                        Program.past_name[5 - cnt1] = Program.TransferText_pname;
                    }
                    if(f2)
                    {
                        Program.today[5 - cnt2] = Program.rest[1];
                        Program.today_name[5 - cnt2] = Program.TransferText_pname;
                    }
                                       
                    sort(cnt1, cnt2);
                }
                else if (Program.rest[0] < Program.rest[1])
                {
                    // ソートしない
                }
                //Program.today_name[5 - cnt2] = Program.TransferText_pname;
                //Program.past_name[5 - cnt1] = Program.TransferText_pname;
            }

            // txtファイルの書き込み
            DateTime dt1 = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt1.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt1.ToString("yyyyMMddHHmmss"), "F6_Load"));
            file2.Close();
        }

        private void sort(int cnt1, int cnt2)
        {
            string filename = @"C:\Users\s2-de\Documents\LEDレース\csv\past.csv";

            // todayファイルの読み込み
            DateTime dt = DateTime.Now;
            string filename1 = @"C:\Users\s2-de\Documents\LEDレース\csv\result" + dt.ToString("yyyyMMdd") + ".csv";

            for (int n = 0; n < 5 - cnt2; n++) // todayのtop5と今の結果をソート
            {
                int min1 = n;

                for (int m = n + 1; m < 6 - cnt2; m++)
                {
                    if (Program.today[min1] > Program.today[m])
                    {
                        min1 = m;
                    }
                }

                long a = Program.today[min1];
                Program.today[min1] = Program.today[n];
                Program.today[n] = a;
                // 名前もソート
                string name1 = Program.today_name[min1];
                Program.today_name[min1] = Program.today_name[n];
                Program.today_name[n] = name1;
            }

            for (int n = 0; n < 5 - cnt1; n++) // pastのtop5と今の結果をソート
            {
                int min2 = n;

                for (int v = n + 1; v < 6 - cnt1; v++)
                {
                    if (Program.past[min2] > Program.past[v])
                    {
                        min2 = v;
                    }
                }

                long b = Program.past[min2];
                Program.past[min2] = Program.past[n];
                Program.past[n] = b;
                // 名前もソート
                string name2 = Program.past_name[min2];
                Program.past_name[min2] = Program.past_name[n];
                Program.past_name[n] = name2;

            }


            // past.csvを更新
            StreamWriter file_w = new StreamWriter(filename, false, Encoding.UTF8);
            file_w.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}", "cnt", 1, 2, 3, 4, 5));
            file_w.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}", "past", Program.past_name[0], Program.past_name[1], Program.past_name[2], Program.past_name[3], Program.past_name[4]));
            file_w.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}", "", Program.past[0], Program.past[1], Program.past[2], Program.past[3], Program.past[4]));
            file_w.Close();

            // today.csvを更新
            StreamWriter file_w1 = new StreamWriter(filename1, false, Encoding.UTF8);
            file_w1.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}", "cnt", 1, 2, 3, 4, 5));
            file_w1.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}", "today", Program.today_name[0], Program.today_name[1], Program.today_name[2], Program.today_name[3], Program.today_name[4]));
            file_w1.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}, {5}", "", Program.today[0], Program.today[1], Program.today[2], Program.today[3], Program.today[4]));
            file_w1.Close();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            //timer1.Stop();
            cnt = 0;
            button53.Enabled = false;

            // メニュー画面の表示
            Program.Menu_f = 6;
            Menu menu = new Menu();
            menu.Show();
            // この画面を隠す
            this.Close();
            //Hide();
        }

        private void button1_Click(object sender, EventArgs e) // 次へボタン
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F6_button1_Click"));
            file2.Close();

            timer1.Stop();
            cnt = 0;

            // 次の画面の表示
            if (Program.end_f == true)
            {
                button1.Enabled = false;

                // 終了画面へ
                End end = new End();
                end.Show();
                // この画面を隠す
                this.Close();
                //Hide();
            }
            else if (Program.end_f == false)
            {
                button1.Enabled = false;

                // もう一度画面へ
                Next next = new Next();
                next.Show();
                // この画面を隠す
                this.Close();
                //Hide();
            }
        }

        private void Past_rest_FormClosing(object sender, FormClosingEventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F6_close"));

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

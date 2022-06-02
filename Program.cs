using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LED_Race
{
    static class Program
    {
        static public string TransferText_pname;
        static public string TransferText_rest;
        static public long[] today = new long[6] { -1, -1, -1, -1, -1, -1}; // 今日のtop5+1（今回の結果は要素の最後尾に追加してソートする）
        static public long[] past = new long[6] { -1, -1, -1, -1, -1, -1}; // 過去のtop5+1（今回の結果は要素の最後尾に追加してソートする）
        static public long[] rest = new long[2] { 0, 0 }; // 今回の結果（2回分）
        static public string[] today_name = new string[6] { "-", "-", "-", "-", "-" , "-" }; // todayのtop5のプレイヤー名
        static public string[] past_name = new string[6] { "-", "-", "-", "-", "-", "-" }; // pastのtop5のプレイヤー名
        static public bool end_f = false;
        static public int cnt = 0;
        static public int data_num = 50;
        static public double delay = 0.5;
        static public string[] rest_t1 = new string[51];
        static public string[] rest_t2 = new string[51];
        static public double Menu_f = 2;
        static public int first_check = 0;
        static public int startf2 = 2;
        static public string port1 = "COM3";
        static public string port2 = "COM4";
        
        //static public Player player = new Player();

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ミューテックス作成
            Mutex app_mutex = new Mutex(false, "MYSOFTWARE_001");

            // ミューテックスの所有権を要求する
            if(app_mutex.WaitOne(0, false) == false)
            {
                MessageBox.Show("このアプリケーションは複数起動できません。");
                return;
            }

            //Application.SetHighDpiMode()
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Wait_Window());
            Application.Run(new Port_select());
        }
    }
}

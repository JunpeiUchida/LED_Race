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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F0_button1_Click"));
            file2.Close();

            // 前のフォームに戻る
            switch (Program.Menu_f)
            {
                case 2:
                    // プレイヤー名入力画面の表示
                    Player player = new Player();
                    player.Show();
                    // 待機画面を隠す
                    this.Close();
                    //Hide();
                    break;
                case 3.1:
                    // ゲーム説明画面の表示
                    intro1 intro1 = new intro1();
                    intro1.Show();
                    // プレイヤー名入力画面を隠す
                    this.Close();
                    //Hide();
                    break;
                case 3.2:
                    // 3.2画面の表示
                    intro2 intro2 = new intro2();
                    intro2.Show();
                    // ゲーム説明画面を隠す
                    this.Close();
                    //Hide();
                    break;
                case 3.3:
                    // 3.3画面の表示
                    game1_intro intro_g1 = new game1_intro();
                    intro_g1.Show();
                    // 3.2画面を隠す
                    this.Close();
                    //Hide();
                    break;
                case 3:
                    // inst画面の表示
                    Game_Inst inst = new Game_Inst();
                    inst.Show();
                    // 3.3画面を隠す
                    this.Close();
                    //Hide();
                    break;
                case 4:
                    // メイン画面の表示
                    Main main = new Main();
                    main.Show();
                    // カウントダウン画面を隠す
                    this.Close();
                    //Hide();
                    break;
                case 5:
                    // 結果画面の表示
                    Result result = new Result();
                    result.Show();
                    // メイン画面を隠す
                    this.Close();
                    //Hide();
                    break;
                case 6:
                    // 次の画面の表示
                    Past_rest past = new Past_rest();
                    past.Show();
                    // この画面を隠す
                    this.Close();
                    //Hide();
                    break;
                case 7:
                    // 次の画面の表示
                    Next next = new Next();
                    next.Show();
                    // この画面を隠す
                    this.Close();
                    //Hide();
                    break;
                case 3.4:
                    // ゲーム2の説明画面の表示
                    game2_intro intro_g2 = new game2_intro();
                    intro_g2.Show();
                    // メイン画面を隠す
                    this.Close();
                    //Hide();
                    break;
                default:
                    break;
            }
            //Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F0_button2_Click"));
            file2.Close();

            // 待機画面の表示
            Wait_Window wait = new Wait_Window();
            wait.Show();
            // メニュー画面を隠す
            //Hide();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F0_button3_Click"));
            file2.Close();

            // パスワード入力画面の表示
            Passward pass = new Passward();
            pass.Show();
            // この画面を隠す
            //this.Close();
            //Hide();
            //Application.Exit();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // txtファイルの書き込み
            DateTime dt = DateTime.Now;
            string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

            StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
            file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "F0_close"));

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
